using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Common.Models
{
    public class BaseDto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime creatDate;
            
        public DateTime CreatDate
        {
            get { return creatDate; }
            set { creatDate = value; }
        }

        private DateTime updateDate;

        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }


    }
}
