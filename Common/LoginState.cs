using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public enum LoginState
    {
        /// <summary>
        /// 账户不存在
        /// </summary>
        NoName,
        /// <summary>
        /// 锁定时间未到
        /// </summary>
        Locking,
        /// <summary>
        /// 登录成功
        /// </summary>
        OK,
        /// <summary>
        /// 错误次数达到三次
        /// </summary>
        ErrTimes,
        /// <summary>
        /// 密码错误
        /// </summary>
        PwdErr
    }
}
