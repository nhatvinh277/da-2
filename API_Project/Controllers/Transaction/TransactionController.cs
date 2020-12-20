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
    [Route("api/transaction")]
    [EnableCors("DA2Policy")]
    public class TransactionController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DA2_DBContext _context;
        private LoginController _account;

        public TransactionController(IHostingEnvironment hostingEnvironment)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _hostingEnvironment = hostingEnvironment;
            _account = new LoginController();
        }

        #region
        [Route("add")]
        [HttpGet]
        public BaseModel<object> Add(Transaction data)
        {
            BaseModel<object> _baseModel = new BaseModel<object>();
            PageModel _pageModel = new PageModel();
            ErrorModel _error = new ErrorModel();

            string Token = _account.GetHeader(Request);
            try
            {
                DBTransaction item = new DBTransaction();
                item.IdAccount = data.IdAccount;

                _context.DBTransaction.Add(item);
                _context.SaveChanges();

                foreach(ItemTransaction detail in data.items)
                {
                    DBTransactionDetail subitem = new DBTransactionDetail();
                    subitem.IdTransaction = item.IdTransaction.Value;
                    subitem.IdItem = detail.IdItem;
                    subitem.Quantity = detail.Quantity;
                    subitem.Money = detail.Money;
                     
                    _context.DBTransactionDetail.Add(subitem);
                    _context.SaveChanges();
                }




                _context.Database.CommitTransaction();

                data.IdTransaction = item.IdTransaction;
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
