using Batch4.Api.MiniKpay.Models.TransactionHistory;

namespace Batch4.Api.MiniKpay.Features.TransactionHistory;

public class BL_TransactionHistory
{
    private readonly DA_TransactionHistory _dA_TransactionHistory;

    public BL_TransactionHistory(DA_TransactionHistory dA_TransactionHistory)
    {
        _dA_TransactionHistory = dA_TransactionHistory;
    }

    public async Task<TransactionHistoryResponseModel> TransactionHistory(
        TransactionHistoryRequestModel requestModel
    )
    {
        bool IsExit = await _dA_TransactionHistory.IsExistCustomerCode(requestModel.CustomerCode!);
        if (!IsExit)
            throw new Exception("Customer doesn't Exist");

        var lst = await _dA_TransactionHistory.TransactionHistoryByCustomerCode(requestModel.CustomerCode!);
        var model = new TransactionHistoryResponseModel()
        {
            Data = lst
        };
        return model;
    }
}
