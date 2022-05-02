
using Demo.Repository.Implement;
using Demo.Repository.Implement.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Base
{
    /// <summary>
    /// Base
    /// </summary>
    public partial class UnitDbConext : OracleConnBase, IUnitDbContext
    {
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
        public UnitDbConext(IConfiguration configuration) : base(configuration)
#pragma warning restore CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
        {
        }

        public void RollBack()
        {
            try
            {
                Transction.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                Transction.Dispose();
                Transction = Connection.BeginTransaction();
            }
        }

        public void SaveChange()
        {
            try
            {
                Transction.Commit();

            }
            catch
            {
                Transction.Rollback();
                throw;
            }
            finally
            {
                Transction.Dispose();
                Transction = Connection.BeginTransaction();
            }
        }

        bool disposeValue = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDispose)
        {
            if (disposeValue)
                return;

            if (isDispose)
            {
                Transction?.Dispose();
                Connection?.Dispose();
            }

            disposeValue = true;
        }

        ~UnitDbConext()
        {
            Dispose(false);
        }
    }

    /// <summary>
    /// Set Property
    /// </summary>
    public partial class UnitDbConext
    {
        IProductRepository _productRepository;
        public IProductRepository ProductRepository { get { return _productRepository ??= new ProductRepository(Transction); } }
    }
}
