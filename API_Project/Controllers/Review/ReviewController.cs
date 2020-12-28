using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Project.Assets;
using API_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Controllers
{
    [Route("api/review")]
    [EnableCors("DA2Policy")]
    public class ReviewController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DA2_DBContext _context;
        private LoginController _account;

        public ReviewController(IHostingEnvironment hostingEnvironment)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _hostingEnvironment = hostingEnvironment;
            _account = new LoginController();
        }

        #region
        [Route("add")]
        [HttpPost]
        [Authorize]
        public BaseModel<object> Add([FromBody] Review data)
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
                _context.Database.BeginTransaction();
                DBReview item = new DBReview();
                item.IdAccount = loginData.IdAccount;
                item.IdTransactionDetail = data.IdTransactionDetail;
                item.IdItem = data.IdItem;
                item.Text = data.Text;
                item.Rate = data.Rate;
                item.Time = DateTime.Now;

                _context.DBReview.Add(item);
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
