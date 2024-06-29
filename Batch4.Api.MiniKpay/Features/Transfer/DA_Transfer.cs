using Batch4.Api.MiniKpay.Models;
using Batch4.Api.MiniKpay.Models.Transfar;
using Dapper;
using System.Data;

namespace Batch4.Api.MiniKpay.Features.Transfer;

public class DA_Transfer
{
    private readonly IDbConnection _db;

    public DA_Transfer(IDbConnection db)
    {
        _db = db;
    }

    public async Task<string> HandleInsufficientBalance(string mobileNo, decimal amount)
    {
        string query =
            @"select * from Tbl_CustomerBalance
            where MobileNo = @MobileNo";

        var result = await _db.QueryAsync<CustomerBalanceModel>(query, new { MobileNo = mobileNo });
        var item = result.FirstOrDefault();

        if (item is null)
            throw new Exception("Invalid Mobile Number");
        if (amount > item.Balance)
            throw new Exception("Insufficient Balance");

        return ("Operation Successful");
    }

    public async Task<string> ValidateMobileNumber(string mobileNo)
    {
        string query = "select * from Tbl_Customer with (nolock) where MobileNo = @MobileNo";
        var queryResult = await _db.QueryAsync<CustomerModel>(query, new { MobileNo = mobileNo });
        var item = queryResult.FirstOrDefault();

        if (item is null)
            throw new Exception("Invalid Mobile Number");

        return ("Operation Successful");
    }

    public async Task<string> DecreaseAmount(string mobileNo, decimal amount)
    {
        string query = "Update Tbl_CustomerBalance Set Balance = Balance - @Balance where MobileNo = @MobileNo";
        var queryResult = await _db.ExecuteAsync(query, new { MobileNo = mobileNo, Balance = amount });

        return ("Operation Successful");
    }

    public async Task<string> IncreaseAmount(string mobileNo, decimal amount)
    {
        string query = "Update Tbl_CustomerBalance Set Balance = Balance + @Balance where MobileNo = @MobileNo";
        var queryResult = await _db.ExecuteAsync(query, new { MobileNo = mobileNo, Balance = amount });

        return ("Operation Successful");
    }

    public async Task<string> CreateTransaction(TransferRequestModel reqModel)
    {
        string query = @"insert into Tbl_CustomerTransactionHistory (
        FromMobileNo, ToMobileNo, Amount, TransactionDate)
values (@FromMobileNo, @ToMobileNo, @Amount, @TransactionDate);";

        var queryResult = await _db.ExecuteAsync(query, new 
        {
            FromMobileNo = reqModel.FromMobileNo,
            ToMobileNo = reqModel.ToMobileNo,
            Amount = reqModel.Amount,
            TransactionDate = DateTime.Now
        });
        return ("Operation Successful");
    }
}
