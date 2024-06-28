using Batch4.Api.MiniKpay.Models.Transfar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.MiniKpay.Features.Transfer;

[Route("api/[controller]")]
[ApiController]
public class TransferController : ControllerBase
{
	private readonly BL_Transfer _bL_Transfer;

    public TransferController(BL_Transfer bL_Transfer)
    {
        _bL_Transfer = bL_Transfer;
    }

    [HttpPost]
    public async Task<IActionResult> Transfer(TransferRequestModel reqModel)
    {
		try
		{
			reqModel.IsValid();
			await _bL_Transfer.Transfer(reqModel);
			return Ok("Operation Successful");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.ToString());
		}
    }
}
