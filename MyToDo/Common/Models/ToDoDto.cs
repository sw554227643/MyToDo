using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Common.Models
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class ToDoDto: BaseDto
    {
        private string title;
       /// <summary>
       /// 标题
       /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; } 
        }

        private int status;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }





    }
}
