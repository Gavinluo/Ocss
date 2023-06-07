using System.ComponentModel.DataAnnotations;

namespace Ocss.Web.DataTransferModel
{
	/// <summary>
	/// 用来接受登录时提交的表单数据
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[Required]
		public string UserName { get; set; }
		/// <summary>
		/// 密码
		/// </summary>
		[Required]
		public string Password { get; set; }

		/// <summary>
		/// 登录类型
		/// </summary>
		public string Type { set; get; }
	}
}
