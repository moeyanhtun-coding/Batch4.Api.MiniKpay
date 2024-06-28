namespace Batch4.Api.MiniKpay.Models;

public class CustomerModel
{
    public int CustomerId { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    public string MobileNo { get; set; }
}

public class CustomerBalanceModel
{
    public int CustomerBalanceId { get; set; }
    public string CustomerCode { get; set; }
    public decimal Balance { get; set; }
}
