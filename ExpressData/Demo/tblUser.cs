using Dapper.Contrib.Extensions;

namespace Demo
{
    [Table("tblUser")]
    public class tblUser
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Computed]
        public string Fullname { get; set; }
    }
}
