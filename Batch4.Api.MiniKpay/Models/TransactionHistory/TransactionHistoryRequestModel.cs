namespace Batch4.Api.MiniKpay.Models.TransactionHistory;

public class TransactionHistoryRequestModel
{
    public string? CustomerCode { get; set; }

    public bool IsValid()
    {
        try
        {
            if (string.IsNullOrEmpty(CustomerCode))
                throw new Exception("Invalid CustomerCode");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return true;
    }
}
