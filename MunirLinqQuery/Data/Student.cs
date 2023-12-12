using System.ComponentModel.DataAnnotations;

namespace MunirLinqQuery.Data
{
    public class Student
    {
        [Key]
        public int sid { get; set; }
        public string sname { get; set; }
        public string major { get; set; }
        public string standing { get; set; }

        public int marks { get; set; }

        public int age { get; set; }

        public virtual IList<Faculty> faculty { get; set; }
        public virtual IList<Enrolled> enrolls { get; set; }
    }
}
