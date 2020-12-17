using API_Project.Assets;
using API_Project.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Controllers.Items
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
                                             IdItem = item.IdItem,
                                             IdType = item.IdType,
                                             Name = item.Name,
                                             Money = item.Money,
                                             Sales = item.Sales,
                                             RateAvg = item.RateAvg,
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
    }
}
