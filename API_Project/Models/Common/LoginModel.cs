using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_Project.Models
{
    public class LoginModel : BaseModel<LoginData>
    {
    }
    public class LoginData
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; } = 0;
        public List<string> Rules { get; set; }
        public int UserType { get; set; } = 0;
        public string Fullname { get; set; }
        public string Token { get; set; }
        public string isMessageError { get; set; }
        public bool? isEnableError { get; set; }
    }
    public class LoginViewModel
    {
        public LoginViewModel() { }
        [Required(ErrorMessage = "Vui nhập tên đăng nhập.")]
        [MaxLength(99, ErrorMessage = "Tài khoản tối đa 99 ký tự.")]
        [DisplayName("Tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Ghi nhớ")]
        public bool isPersistent { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class LoginAPIModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}