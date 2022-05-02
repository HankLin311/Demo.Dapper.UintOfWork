using Demo.Repository.Implement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Base
{
    public partial interface IUnitDbContext : IDisposable
    {
        public void SaveChange();
        public void RollBack();
    }

    public partial interface IUnitDbContext 
    {
        public IProductRepository ProductRepository { get; }
    }
}
