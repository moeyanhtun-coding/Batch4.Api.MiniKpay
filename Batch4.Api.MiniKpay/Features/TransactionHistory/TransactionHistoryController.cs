using Batch4.Api.MiniKpay.Models.TransactionHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.MiniKpay.Features.TransactionHistory;

[Route("api/[controller]")]
[ApiController]
public class TransactionHistoryController : ControllerBase
{
    private readonly BL_TransactionHistory _bL_TransactionHistory;

    public TransactionHistoryController(BL_TransactionHistory bL_TransactionHistory)
    {
        _bL_TransactionHistory = bL_TransactionHistory;
    }

    [HttpPost]
    public async Task<IActionResult> TransactionHistory(TransactionHistoryRequestModel requestModel)
    {
        try
        {
            var result = requestModel.IsValid();
            if (!result) 
            {
                return BadRequest("Invalid CustomerCode");
            }
            var model = await _bL_TransactionHistory.TransactionHistory(requestModel);
            return Ok(model);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
