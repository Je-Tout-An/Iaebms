using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iaebms.Tool.IaebmsModels
{
    public class ResultData
    {

        /// <summary>
        /// 数据返回状态码 0 -失败 ；1 -成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回数据状态 000001，000002 错误状态
        /// </summary>
        public string status { get; set; }
        
        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public Object resultData { get; set; }
    }
}
