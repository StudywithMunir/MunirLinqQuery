﻿using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MunirLinqQuery.Data
{
    public class Enrolled
    {
        [Key]
        public int eid { get; set; }
        public int fid { get; set; }
        public int sid { get; set; }
        public int cid { get; set; }

        public virtual IList<Student>? students { get; set; }
        public virtual Faculty faculty { get; set; }
        public virtual Class clas { get; set; }
    }
}
