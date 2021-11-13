using MVC_CRUD.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.Entities.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }

        private DateTime _createTime = DateTime.Now;
        public DateTime CreateDate { get => _createTime; set => _createTime = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteTime { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}