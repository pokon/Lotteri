using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lotteri.Models
{
    public class LotteriContext : DbContext
    {
        public LotteriContext (DbContextOptions<LotteriContext> options)
            : base(options)
        {
        }

        public DbSet<Lotteri.Models.LottoItemModel> LottoItemModel { get; set; }
    }
}
