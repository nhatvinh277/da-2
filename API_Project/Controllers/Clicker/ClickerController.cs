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

namespace API_Project.Controllers
{
    [Route("api/rate")]
    [EnableCors("DA2Policy")]
    public class ClickerController: ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DA2_DBContext _context;
        private LoginController _account;

        public ClickerController(IHostingEnvironment hostingEnvironment)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _hostingEnvironment = hostingEnvironment;
            _account = new LoginController();
        }

        #region
        [Route("add")]
        [HttpGet]
        public BaseModel<object> Add(Clicker data)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();

            string Token = _account.GetHeader(Request);
            try
            {
                DBClicker item = new DBClicker();
                item.IdAccount = data.IdAccount;
                item.IdTransactionDetail = data.IdTransactionDetail;
                item.IdItem = data.IdItem;
                item.Click = data.Click;
                item.Time = DateTime.Now;

                _context.DBClicker.Add(item);
                _context.SaveChanges();

                _context.Database.CommitTransaction();

                data.Id = item.Id;
                _baseModel.status = 1;
                _baseModel.data = data;
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
