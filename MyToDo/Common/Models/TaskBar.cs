﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Common.Models
{
    /// <summary>
    /// 任务栏
    /// </summary>
    public class TaskBar : BindableBase
    {
        private string icon;
        /// <summary>
        /// 图表
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

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

        private string color;
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private string target;
        /// <summary>
        /// 目标
        /// </summary>
        public string Target
        {
            get { return target; }
            set { target = value; }
        }


    }
}
