using Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Message.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserMessageStatisticsController(IUserMessageService userMessageService) : ControllerBase
{
    private readonly IUserMessageService _userMessageService = userMessageService;

    [HttpGet]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int messageCount = await _userMessageService.GetTotalMessageCount();
        return Ok(messageCount);
    }
}
