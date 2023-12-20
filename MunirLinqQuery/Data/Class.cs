using System.ComponentModel.DataAnnotations;

namespace MunirLinqQuery.Data
{
    public class Class
    {
        [Key]
        public int cid { get; set; }
        public string? name { get; set; }
        public int roomNo { get; set; }
        public int fid { get; set; }

        public virtual Faculty? Faculty { get; set; }
        public virtual IList<Student>? students { get; set; }
    }
}
