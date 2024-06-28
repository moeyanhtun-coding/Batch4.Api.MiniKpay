namespace Batch4.Api.MiniKpay.Models.TransactionHistory;

public class TransactionHsitoryRequestModel
{
    public string? CustomerCode { get; set; }

    public void IsValid()
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
    }
}
