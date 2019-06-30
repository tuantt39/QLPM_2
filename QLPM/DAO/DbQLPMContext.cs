using Microsoft.EntityFrameworkCore;
using QLPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLPM.Model;

namespace QLPM.DAO
{
    public class DbQLPMContext:DbContext
    {
        
            public DbQLPMContext(DbContextOptions<DbQLPMContext> options) : base(options) { }
            public DbSet<MAYTINH> MAYTINH { get; set; }
            public DbSet<DAYMAY> DAYMAY { get; set; }
            public DbSet<LOP> LOP { get; set; }
            public DbSet<GIANGVIEN> GIANGVIEN { get; set; }
            public DbSet<TRANGTHAI> TRANGTHAI { get; set; }
            public DbSet<PHONG> PHONG { get; set; }
            public DbSet<DANGKYTIETHOC> DANGKYTIETHOC { get; set; }
            public DbSet<QLPM.Model.QUYENHAN> QUYENHAN { get; set; }
            public DbSet<QLPM.Model.TAIKHOAN> TAIKHOAN { get; set; }



    }
    

}
