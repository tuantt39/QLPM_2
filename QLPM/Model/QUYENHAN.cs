using QLPM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLPM.Model
{
    public class QUYENHAN
    {
        public QUYENHAN()
        {
            this.GIANGVIENs = new HashSet<GIANGVIEN>();
            this.TAIKHOANs = new HashSet<TAIKHOAN>();
        }
        [Key]
        public string MAQH { get; set; }
        public string TENQH { get; set; }

        public virtual ICollection<GIANGVIEN> GIANGVIENs { get; set; }
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }
    }
}
