using API_Project.Assets;
using API_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Controllers
{
    [Route("api/user")]
    [EnableCors("DA2Policy")]
    public class UserController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DA2_DBContext _context;
        private LoginController _account;

        public UserController(IHostingEnvironment hostingEnvironment)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _hostingEnvironment = hostingEnvironment;
            _account = new LoginController();
        }

        #region Danh sách phiếu yêu cầu
        /// <summary>
        /// Lấy danh sách phiếu yêu cầu
        /// </summary>
        /// <param name="_query"></param>
        /// <returns></returns>
        // GET: api/RD_PhieuYeuCau_List
        [Route("User_List")]
        [HttpGet]
        public BaseModel<object> User_List(QueryParams _query)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();
            string _keywordSearch = "";
            bool _orderBy_ASC = false;

            string Token = _account.GetHeader(Request);
            try
            {
                Func<UserModel, object> _orderByExpression = x => x.IdUser;
                Dictionary<string, Func<UserModel, object>> _sortableFields = new Dictionary<string, Func<UserModel, object>>
                {
                    { "Fullname", x => x.Fullname }
                };

                if (!string.IsNullOrEmpty(_query.sortField) && _sortableFields.ContainsKey(_query.sortField))
                {
                    _orderBy_ASC = ("desc".Equals(_query.sortOrder) ? false : true);
                    _orderByExpression = _sortableFields[_query.sortField];
                }

                List<UserModel> _data = (from user in _context.DBUser
                                        select new UserModel
                                        {
                                            IdUser = user.IdUser,
                                            Fullname = user.Fullname,
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


        [HttpPost]
        //[Authorize]
        [Route("GetMenu")]
        public BaseModel<object> GetMenu()
        {
            BaseModel<object> _baseModel = new BaseModel<object>();


            var data = from m in _context.DBMainMenu
                       where !m.IsDisabled
                       orderby m.Position
                       select new
                       {
                           IdMain = m.Id_Main,
                           Title = m.Title,
                           Summary = m.Summary,
                           Link = m.Link,
                           Position = m.Position,
                           Icon = m.Icon,
                           GroupName = m.GroupName,
                           Target = m.Target
                       };


            _baseModel.status = 1;
            _baseModel.data = data;
            return _baseModel;
        }
    }
}
