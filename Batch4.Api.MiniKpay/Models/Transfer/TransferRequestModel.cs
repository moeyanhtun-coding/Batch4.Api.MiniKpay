namespace Batch4.Api.MiniKpay.Models.Transfar;

public class TransferRequestModel
{
    public string FromMobileNo { get; set; }
    public string ToMobileNo { get; set; }
    public decimal Amount { get; set; }

    public void IsValid()
    {
        try
        {
            if (string.IsNullOrEmpty(FromMobileNo))
                throw new Exception("Invalid From Mobile No.");
            if (string.IsNullOrEmpty(ToMobileNo))
                throw new Exception("Invalid To Mobile No.");
            if (Amount <= 0)
                throw new Exception("Invalid Amount");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
