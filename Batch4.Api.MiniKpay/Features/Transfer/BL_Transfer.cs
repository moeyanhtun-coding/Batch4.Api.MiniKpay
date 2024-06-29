using Batch4.Api.MiniKpay.Models.Transfar;

namespace Batch4.Api.MiniKpay.Features.Transfer;

public class BL_Transfer
{
    private readonly DA_Transfer _dA_Transfar;

    public BL_Transfer(DA_Transfer dA_Transfar)
    {
        _dA_Transfar = dA_Transfar;
    }

    public async Task<string> Transfer(TransferRequestModel reqModel)
    {
        var result = await _dA_Transfar.ValidateMobileNumber(reqModel.FromMobileNo);
        if (result == null)
            throw new Exception("FromMobile No is Invalid!");

        result = await _dA_Transfar.ValidateMobileNumber(reqModel.ToMobileNo);
        if (result == null)
            throw new Exception("ToMobile No is Invalid!");

        result = await _dA_Transfar.HandleInsufficientBalance(reqModel.FromMobileNo, reqModel.Amount);
        if (result == null)
            throw new Exception("Something Invalid From Mobile No or Amount");

        await _dA_Transfar.DecreaseAmount(reqModel.FromMobileNo, reqModel.Amount);
        await _dA_Transfar.IncreaseAmount(reqModel.ToMobileNo, reqModel.Amount);
        await _dA_Transfar.CreateTransaction(reqModel);

        return ("Opearation Successful");
    }
}
