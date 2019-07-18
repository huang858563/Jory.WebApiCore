using System;

namespace Jory.Model.Entities
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        /// <value></value>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        /// <value></value>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        /// <value></value>
        public string UserPwd { get; set; }
    }
}
