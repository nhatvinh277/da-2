using API_Project.Assets;
using API_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project.Controllers
{
    [Route("api/items")]
    [EnableCors("DA2Policy")]
    public class ItemsController: ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DA2_DBContext _context;
        private LoginController _account;

        public ItemsController(IHostingEnvironment hostingEnvironment)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _hostingEnvironment = hostingEnvironment;
            _account = new LoginController();
        }

        #region
        [Route("List")]
        [HttpGet]
        public BaseModel<object> Items_List(QueryParams _query)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();
            string _keywordSearch = "";
            bool _orderBy_ASC = false;

            string Token = _account.GetHeader(Request);
            try
            {
                Func<ItemsModel, object> _orderByExpression = x => x.IdItem;
                Dictionary<string, Func<ItemsModel, object>> _sortableFields = new Dictionary<string, Func<ItemsModel, object>>
                {
                    { "IdItem", x => x.IdItem }
                };


                if (!string.IsNullOrEmpty(_query.sortField) && _sortableFields.ContainsKey(_query.sortField))
                {
                    _orderBy_ASC = ("desc".Equals(_query.sortOrder) ? false : true);
                    _orderByExpression = _sortableFields[_query.sortField];
                }

                List<ItemsModel> _data = (from item in _context.DBItems
                                         select new ItemsModel
                                         {
                                             IdItem = item.IdItem.Value,
                                             IdType = item.IdType,
                                             Name = item.Name,
                                             Money = item.Money,
                                             Sales = item.Sales,
                                             RateAvg = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count() <= 0  ? 0 : Decimal.Divide(Decimal.Divide(_context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Select(s => s.Rate).Sum(), _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count()), 5) * 100,
                                             RateNumber = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count(),
                                             LinkImage = item.LinkImage,
                                         }).ToList();

                int _countRows = _data.Count();
                if (_countRows == 0)
                {
                    _baseModel.status = 0;
                    _error = new ErrorModel();
                    _error.message = "Không có dữ liệu hiển thị!";
                    _error.code = Constant.ERRORCODE_SQL;
                    _baseModel.error = _error;
                    return _baseModel;
                }
                _pageModel.TotalCount = _countRows;
                _pageModel.AllPage = (int)Math.Ceiling(_countRows / (decimal)_query.record);
                _pageModel.Size = _query.record;
                _pageModel.Page = _query.page;
                _pageModel.Page = _query.page;

                if (_query.more)
                {
                    _baseModel.status = 1;
                    _baseModel.error = null;
                    _baseModel.page = _pageModel;
                    _baseModel.data = _data.ToList();
                    return _baseModel;
                }

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.page = _pageModel;

                if (_orderBy_ASC)
                {
                    _baseModel.data = _data
                        .OrderBy(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }
                else
                {
                    _baseModel.data = _data
                        .OrderByDescending(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }

                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion


        #region
        [Route("Detail")]
        [HttpGet]
        public BaseModel<object> Detail(long id)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();

            string Token = _account.GetHeader(Request);
            try
            {
                Func<ItemsModel, object> _orderByExpression = x => x.IdItem;
                Dictionary<string, Func<ItemsModel, object>> _sortableFields = new Dictionary<string, Func<ItemsModel, object>>
                {
                    { "IdItem", x => x.IdItem }
                };

                ItemsModel _data = (from item in _context.DBItems
                                    where item.IdItem == id
                                          select new ItemsModel
                                          {
                                              IdItem = item.IdItem,
                                              IdType = item.IdType,
                                              Name = item.Name,
                                              Money = item.Money,
                                              Sales = item.Sales,
                                              RateAvg = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count() <= 0 ? 0 : Decimal.Divide(Decimal.Divide(_context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Select(s => s.Rate).Sum(), _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count()), 5) * 100,
                                              RateNumber = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count(),
                                              LinkImage = item.LinkImage,
                                          }).ToList().FirstOrDefault();


                _data.UserReview = _context.DBReview.Where(x => x.IdItem == id)
                                                                .Join(_context.DBAccount,
                                                                    re => re.IdAccount,
                                                                    acc => acc.IdAccount,
                                                                    (re, acc) => new { re = re, acc = acc })
                                                                .Join(_context.DBUser,
                                                                acc => acc.acc.IdUser,
                                                                user => user.IdUser,
                                                                (acc,user) => new { acc = acc, user = user})

                                                                .Select(s => new UserReview
                                                                {
                                                                    AccountName = s.user.Fullname,
                                                                    Time = s.acc.re.Time,
                                                                    Rate = Decimal.Divide(s.acc.re.Rate,5) * 100,
                                                                    Text = s.acc.re.Text
                                                                }).ToList();

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.data = _data;
                _baseModel.page = _pageModel;

                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion

        #region
        [Route("ListbyType")]
        [HttpGet]
        public BaseModel<object> Items_ListbyType(QueryParams _query)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();
            string _keywordSearch = "";
            bool _orderBy_ASC = false;

            string Token = _account.GetHeader(Request);
            try
            {
                Func<ItemsModel, object> _orderByExpression = x => x.IdItem;
                Dictionary<string, Func<ItemsModel, object>> _sortableFields = new Dictionary<string, Func<ItemsModel, object>>
                {
                    { "IdItem", x => x.IdItem }
                };

                if (!string.IsNullOrEmpty(_query.sortField) && _sortableFields.ContainsKey(_query.sortField))
                {
                    _orderBy_ASC = ("desc".Equals(_query.sortOrder) ? false : true);
                    _orderByExpression = _sortableFields[_query.sortField];
                }

                List<ItemsModel> _data = new List<ItemsModel>();
                if (!string.IsNullOrEmpty(_query.filter["type"]))
                {
                    _data = (from item in _context.DBItems
                            where item.IdType == (_context.DBTypeItems.Where(type =>
                                                                        type.IdMainMenu == _context.DBMainMenu.Where(menu =>
                                                                                                                        !menu.IsDisabled 
                                                                                                                       && menu.Link.Equals(_query.filter["type"]))
                                                                                                                .Select(s => s.Id_Main).FirstOrDefault())
                                                                       .Select(t => t.IdType).FirstOrDefault())

                             select new ItemsModel
                             {
                                 IdItem = item.IdItem,
                                 IdType = item.IdType,
                                 Name = item.Name,
                                 Money = item.Money,
                                 Sales = item.Sales,
                                 RateAvg = item.RateAvg,
                                 LinkImage = item.LinkImage
                             }).ToList();
                }

                int _countRows = _data.Count();
                if (_countRows == 0)
                {
                    _baseModel.status = 0;
                    _error = new ErrorModel();
                    _error.message = "Không có dữ liệu hiển thị!";
                    _error.code = Constant.ERRORCODE_SQL;
                    _baseModel.error = _error;
                    return _baseModel;
                }
                _pageModel.TotalCount = _countRows;
                _pageModel.AllPage = (int)Math.Ceiling(_countRows / (decimal)_query.record);
                _pageModel.Size = _query.record;
                _pageModel.Page = _query.page;
                _pageModel.Page = _query.page;

                if (_query.more)
                {
                    _baseModel.status = 1;
                    _baseModel.error = null;
                    _baseModel.page = _pageModel;
                    _baseModel.data = _data.ToList();
                    return _baseModel;
                }

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.page = _pageModel;

                if (_orderBy_ASC)
                {
                    _baseModel.data = _data
                        .OrderBy(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }
                else
                {
                    _baseModel.data = _data
                        .OrderByDescending(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }

                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion


        #region
        [HttpPost]
        [Authorize]
        [Route("Orders")]
        public BaseModel<object> Orders([FromBody] ItemsOrdersModel data)
        {
            BaseModel<object> model = new BaseModel<object>();
            ErrorModel _error = new ErrorModel();
            string Token = _account.GetHeader(Request);
            LoginData loginData = _account._GetInfoUser(Token);
            if (loginData == null)
            {
                return model = new BaseModel<object>
                {
                    data = null,
                    status = 0,
                    error = new ErrorModel
                    {
                        code = Constant.ERRORDATA,
                        message = "Phiên đăng nhập hết hạn hoặc bạn chưa truyền Token"
                    }
                };
            }

            try
            {
                _context.Database.BeginTransaction();
                DBTransaction transaction = new DBTransaction();
                transaction.IdAccount = loginData.IdAccount;
                transaction.TransactionCode = DateTime.Now.ToString("yyyyMMddHHmmss");
                _context.DBTransaction.Add(transaction);
                _context.SaveChanges();


                DBTransactionDetail detail = new DBTransactionDetail();
                detail.IdTransaction = transaction.IdTransaction;
                detail.IdItem = data.IdItem;
                detail.Money = data.Money;
                detail.Created = DateTime.Now;
                detail.Quantity = data.Quantity;


                _context.DBTransactionDetail.Add(detail);
                _context.SaveChanges();

                _context.Database.CommitTransaction();
                model.status = 1;
                model.data = data;
                return model;
            }
            catch (Exception ex)
            {
                model.status = 0;
                _error.message = "Thêm mới thất bại, vui lòng kiểm tra lại!";
                _error.code = Constant.ERRORCODE;
                model.error = _error;
                model.data = null;
                return model;
            }
        }
        #endregion

        #region
        [Route("history/List")]
        [Authorize]
        [HttpGet]
        public BaseModel<object> HistoryList(QueryParams _query)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();
            bool _orderBy_ASC = false;

            string Token = _account.GetHeader(Request);
            LoginData _loginData = _account._GetInfoUser(Token);
            try
            {
                Func<TransactionDetail, object> _orderByExpression = x => x.Created;
                Dictionary<string, Func<TransactionDetail, object>> _sortableFields = new Dictionary<string, Func<TransactionDetail, object>>
                {
                    { "IdTransaction", x => x.IdTransaction }
                };

                if (!string.IsNullOrEmpty(_query.sortField) && _sortableFields.ContainsKey(_query.sortField))
                {
                    _orderBy_ASC = ("desc".Equals(_query.sortOrder) ? false : true);
                    _orderByExpression = _sortableFields[_query.sortField];
                }

                List<TransactionDetail> _data = new List<TransactionDetail>();
                _data = _context.DBTransaction.Where(x => x.IdAccount == _loginData.IdAccount)
                                                                      .Join(_context.DBTransactionDetail,
                                                                            trans => trans.IdTransaction,
                                                                            detail => detail.IdTransaction,
                                                                            (trans,detail) => new {trans = trans, detail = detail})
                                                                      .Join(_context.DBItems,
                                                                          detail => detail.detail.IdItem,
                                                                          item => item.IdItem,
                                                                          (detail, item) => new { detail = detail, item = item})
                                                                        .Select(data => new TransactionDetail
                                                                        {
                                                                            IdTransaction = data.detail.detail.IdTransaction,
                                                                            TransactionCode = data.detail.trans.TransactionCode,
                                                                            IdTransactionDetail = data.detail.detail.IdTransactionDetail,
                                                                            IdItem = data.detail.detail.IdItem,
                                                                            Money = data.detail.detail.Money,
                                                                            Name = data.item.Name,
                                                                            Quantity = data.detail.detail.Quantity,
                                                                            Created = data.detail.detail.Created,
                                                                            TongTien = (int)(data.detail.detail.Quantity * data.detail.detail.Money),
                                                                            TrangThai = "Thành công"
                                                                        }).ToList();
                int _countRows = _data.Count();
                if (_countRows == 0)
                {
                    _baseModel.status = 0;
                    _error = new ErrorModel();
                    _error.message = "Không có dữ liệu hiển thị!";
                    _error.code = Constant.ERRORCODE_SQL;
                    _baseModel.error = _error;
                    return _baseModel;
                }
                _pageModel.TotalCount = _countRows;
                _pageModel.AllPage = (int)Math.Ceiling(_countRows / (decimal)_query.record);
                _pageModel.Size = _query.record;
                _pageModel.Page = _query.page;
                _pageModel.Page = _query.page;

                if (_query.more)
                {
                    _baseModel.status = 1;
                    _baseModel.error = null;
                    _baseModel.page = _pageModel;
                    _baseModel.data = _data.ToList();
                    return _baseModel;
                }

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.page = _pageModel;

                if (_orderBy_ASC)
                {
                    _baseModel.data = _data
                        .OrderBy(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }
                else
                {
                    _baseModel.data = _data
                        .OrderByDescending(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }

                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion

        #region
        [Route("QL_List")]
        [HttpGet]
        public BaseModel<object> QL_List(QueryParams _query)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();
            string _keywordSearch = "";
            bool _orderBy_ASC = false;

            string Token = _account.GetHeader(Request);
            try
            {
                Func<ItemsModel, object> _orderByExpression = x => x.IdItem;
                Dictionary<string, Func<ItemsModel, object>> _sortableFields = new Dictionary<string, Func<ItemsModel, object>>
                {
                    { "IdItem", x => x.IdItem }
                };


                if (!string.IsNullOrEmpty(_query.sortField) && _sortableFields.ContainsKey(_query.sortField))
                {
                    _orderBy_ASC = ("desc".Equals(_query.sortOrder) ? false : true);
                    _orderByExpression = _sortableFields[_query.sortField];
                }

                List<ItemsModel> _data = (from item in _context.DBItems
                                          join type in _context.DBTypeItems on item.IdType equals type.IdType into t
                                          from type in t.DefaultIfEmpty()
                                          select new ItemsModel
                                          {
                                              IdItem = item.IdItem.Value,
                                              IdType = item.IdType,
                                              Type = type.Name,
                                              Name = item.Name,
                                              Money = item.Money,
                                              Sales = item.Sales,
                                              RateAvg = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count() <= 0 ? 0 : Decimal.Divide(Decimal.Divide(_context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Select(s => s.Rate).Sum(), _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count()), 5) * 100,
                                              RateNumber = _context.DBReview.Where(x => x.IdItem == item.IdItem.Value).Count(),
                                              LinkImage = item.LinkImage,
                                          }).ToList();

                int _countRows = _data.Count();
                if (_countRows == 0)
                {
                    _baseModel.status = 0;
                    _error = new ErrorModel();
                    _error.message = "Không có dữ liệu hiển thị!";
                    _error.code = Constant.ERRORCODE_SQL;
                    _baseModel.error = _error;
                    return _baseModel;
                }
                _pageModel.TotalCount = _countRows;
                _pageModel.AllPage = (int)Math.Ceiling(_countRows / (decimal)_query.record);
                _pageModel.Size = _query.record;
                _pageModel.Page = _query.page;
                _pageModel.Page = _query.page;

                if (_query.more)
                {
                    _baseModel.status = 1;
                    _baseModel.error = null;
                    _baseModel.page = _pageModel;
                    _baseModel.data = _data.ToList();
                    return _baseModel;
                }

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.page = _pageModel;

                if (_orderBy_ASC)
                {
                    _baseModel.data = _data
                        .OrderBy(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }
                else
                {
                    _baseModel.data = _data
                        .OrderByDescending(_orderByExpression)
                        .Skip((_query.page - 1) * _query.record)
                        .Take(_query.record)
                        .ToList();
                }

                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion

        #region ImportFile
        /// <summary>
        /// upload file excel import xuất kho
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("ImportFile")]
        [Authorize()]
        [HttpPost]
        public BaseModel<object> ImportFile([FromBody] FileImport data)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            ErrorModel _error = new ErrorModel();

            string Token = _account.GetHeader(Request);
            LoginData loginData = _account._GetInfoUser(Token);
            if (loginData == null)
            {
                return _baseModel = new BaseModel<object>
                {
                    data = null,
                    status = 0,
                    error = new ErrorModel
                    {
                        code = Constant.ERRORDATA,
                        message = "Phiên đăng nhập hết hạn hoặc bạn chưa truyền Token"
                    }
                };
            }
            try
            {
                if (string.IsNullOrEmpty(data.base64) && data.fileByte == null)
                {
                    return _baseModel = new BaseModel<object>
                    {
                        data = null,
                        status = 0,
                        error = new ErrorModel
                        {
                            code = Constant.ERRORDATA,
                            message = "Chưa có file upload"
                        }
                    };
                }

                if (!data.extension.Equals("txt"))
                {
                    return _baseModel = new BaseModel<object>
                    {
                        data = null,
                        status = 0,
                        error = new ErrorModel
                        {
                            code = Constant.ERRORDATA,
                            message = "Sai định dạng File, vui lòng thử lại!"
                        }
                    };
                }

                byte[] _fileByte = null;

                if (data.fileByte != null)
                    _fileByte = data.fileByte;
                else
                    _fileByte = Convert.FromBase64String(data.base64);

                string _path = Constant.USER_DATA_UPLOAD_FOLDER + "/" + loginData.Id + "/Import/";

                string _targetPath = Path.Combine(_hostingEnvironment.ContentRootPath, _path);

                if (!Directory.Exists(_targetPath))
                    Directory.CreateDirectory(_targetPath);

                string _fileName = _targetPath + "Items" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + data.filename + "." + data.extension;
                System.IO.File.WriteAllBytes(_fileName, _fileByte);
                try
                {
                    string dataString = Encoding.UTF8.GetString(Convert.FromBase64String(data.base64));

                    List<ItemsImportModel> list = JsonConvert.DeserializeObject<List<ItemsImportModel>>(dataString);

                    list.ForEach(s => s.Type = _context.DBTypeItems.Where(db => db.IdType == data.idLoai).Select(se => se.Name).FirstOrDefault());

                    list.ForEach(s => s.IdType = data.idLoai);

                    _baseModel.status = 1;
                    _baseModel.data = list;
                    return _baseModel;
                }
                catch (Exception ex)
                {
                    return _baseModel = new BaseModel<object>
                    {
                        data = null,
                        status = 0,
                        error = new ErrorModel
                        {
                            code = Constant.ERRORCODE,
                            message = "Lỗi dữ liệu trong file import hoặc không đúng mẫu, không thể convert" + ex.Message
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return _baseModel = new BaseModel<object>
                {
                    data = null,
                    status = 0,
                    error = new ErrorModel
                    {
                        code = Constant.ERRORCODE,
                        message = "Upload file import thất bại: " + ex.Message
                    }
                };
            }
        }
        #endregion

        [Route("DownLoadFileImportMau")]
        [HttpGet]
        public FileResult DownLoadFileImportMau()
        {
            try
            {
                string path = Path.Combine(_hostingEnvironment.ContentRootPath, "Data/Template/import_file_template.txt");
                var fileExists = System.IO.File.Exists(path);
                return PhysicalFile(path, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "import_file_template.txt");
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #region Thêm nhiều sản phẩm
        [Route("Item_Mutiple_Insert")]
        [Authorize]
        [HttpPost]
        public BaseModel<object> Item_Mutiple_Insert([FromBody] List<ItemsSavedImportModel> data)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            ErrorModel _error = new ErrorModel();

            string Token = _account.GetHeader(Request);
            LoginData loginData = _account._GetInfoUser(Token);

            if (loginData == null)
            {
                return _baseModel = new BaseModel<object>
                {
                    data = null,
                    status = 0,
                    error = new ErrorModel
                    {
                        code = Constant.ERRORDATA,
                        message = "Phiên đăng nhập hết hạn hoặc bạn chưa truyền Token"
                    }
                };
            }

            try
            {
                List<long> res = new List<long>();
                using (var transactionCreate = _context.Database.BeginTransaction())
                {
                    foreach (var ele in data)
                    {
                        List<DBItems> l = new List<DBItems>();
                        DBItems element = new DBItems();


                        element.IdType = ele.IdType;
                        element.Name = ele.Name;
                        element.Money = ele.Money;
                        element.Sales = ele.Sales;
                        element.RateAvg = 0;
                        element.LinkImage = string.IsNullOrEmpty(ele.LinkImage) ? "" : ele.LinkImage.ToString().Trim();

                        _context.DBItems.Add(element);
                        _context.SaveChanges();
                    }
                    transactionCreate.Commit();
                }
                _baseModel.status = 1;
                _baseModel.data = res;

                return _baseModel;
            }
            catch (Exception ex)
            {
                _baseModel.status = 0;
                _error.message = "Thêm mới thất bại: " + ex;
                _error.code = Constant.ERRORCODE;
                _baseModel.error = _error;
                _baseModel.data = null;
                return _baseModel;
            }
        }
        #endregion

        #region
        [Route("Type_List")]
        [HttpGet]
        public BaseModel<object> Type_List()
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();

            try
            {
                Func<ItemsModel, object> _orderByExpression = x => x.IdItem;
                Dictionary<string, Func<ItemsModel, object>> _sortableFields = new Dictionary<string, Func<ItemsModel, object>>
                {
                    { "IdItem", x => x.IdItem }
                };


                List<TypeItemsModel> _data = (from item in _context.DBTypeItems
                                              select new TypeItemsModel
                                              {
                                                  IdMainMenu = item.IdMainMenu,
                                                  IdType = item.IdType,
                                                  Name = item.Name,
                                              }).ToList();

                

                _baseModel.status = 1;
                _baseModel.error = null;
                _baseModel.data = _data;
                _baseModel.page = _pageModel;
                return _baseModel;
            }
            catch (Exception ex)
            {
                _error = new ErrorModel();
                _error.message = "Lỗi dữ liệu hoặc bạn phải truyền Token!";
                _error.code = Constant.ERRORCODE;
                return new BaseModel<object>
                {
                    status = 0,
                    error = _error,
                    data = null,
                    page = null
                };
            }
        }
        #endregion
    }
}
