using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MunirLinqQuery.Data
{
    public class Faculty
    {
        [Key]
        public int fid { get; set; }
        public string fname { get; set; }
        public string standing { get; set; }

        public int deptid { get; set; }
    }
}
