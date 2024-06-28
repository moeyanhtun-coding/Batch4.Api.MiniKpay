using Batch4.Api.MiniKpay.Models;
using Dapper;
using System.Data;

namespace Batch4.Api.MiniKpay.Features.TransactionHistory;

public class DA_TransactionHistory
{
    private readonly IDbConnection _db;

    public DA_TransactionHistory(IDbConnection db)
    {
        _db = db;
    }

    public async Task<bool> IsExistCustomerCode(string customerCode)
    {
        string query = @"select * from Tbl_Customer with (nolock) where CustomerCode = @CustomerCode";
        var item = await _db.QueryFirstOrDefaultAsync<CustomerModel>(query, new { CustomerCode = customerCode });
        return item != null;
    }

    public async Task<List<CustomerTransactionHistoryModel>> TransactionHistoryByCustomerCode(string customerCode)
    {
        string query = @"select CTH.* from [dbo].[Tbl_CustomerTransactionHistory] CTH
                                       inner join Tbl_Customer C on CTH.FromMobileNo = C.MobileNo
                                                    where CustomerCode = @CustomerCode";
        var lst = await _db.QueryAsync<CustomerTransactionHistoryModel>(query, new { CustomerCode = customerCode });
        return lst.ToList();
    }
}
