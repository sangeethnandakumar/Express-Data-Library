using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Computed]
        public string Fullname { get; set; }
    }
}
