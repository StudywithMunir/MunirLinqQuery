using System.ComponentModel.DataAnnotations;

namespace MunirLinqQuery.Data
{
    public class Department
    {
            [Key]
            public int deptid { get; set; }
            public string deptName { get; set; }
        
    }
}
