using Dapper;
using Demo.Common.Do;
using Demo.Repository.Implement.Interface;
using System.Data;

namespace Demo.Repository.Implement
{
    public class ProductRepository : IProductRepository
    {
        readonly IDbTransaction _trans;
        readonly IDbConnection _conn;
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
        public ProductRepository(IDbTransaction trans)
#pragma warning restore CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
        {
            _trans = trans;
#pragma warning disable CS8601 // 可能有 Null 參考指派。
            _conn = trans.Connection;
#pragma warning restore CS8601 // 可能有 Null 參考指派。
        }

        public void Add(ProductDo entity)
        {
            string sql = @"
                INSERT INTO tbl_product (
                    product_id,
                    product_name
                ) VALUES (
                    :product_id,
                    :product_name
                )
            ";
            _conn.Execute(sql, entity, transaction: _trans);
        }

        public void Delete(ProductDo entity)
        {
        }

        public IEnumerable<ProductDo> GetAll()
        {
            var sql = @"
                SELECT
                    product_id,
                    product_name
                FROM
                    tbl_product
            ";
            return _conn.Query<ProductDo>(sql, transaction: _trans);
        }

        public ProductDo GetById(ProductDo entity)
        {
            var parameters = new { product_id = entity.product_id };
            var sql = @"
                SELECT
                    product_id,
                    product_name
                FROM
                    tbl_product
                WHERE
                    product_id = :product_id
            ";
            return _conn.QueryFirstOrDefault<ProductDo>(sql, parameters, transaction: _trans);
        }

        public int GetProductQty(int id)
        {
            var parameters = new { product_id = id };
            var sql = @"
                SELECT
                    qty
                FROM
                    tbl_product
                WHERE
                    product_id = :product_id
            ";
            return _conn.QuerySingle<ProductDo>(sql, parameters, transaction: _trans).qty;
        }

        public void Update(ProductDo entity)
        {
        }
    }
}
