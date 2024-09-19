using Comment.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comment.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CommentStatisticsController(CommentContext commentContext) : ControllerBase
{
    private readonly CommentContext _commentContext = commentContext;

    [HttpGet]
    public async Task<IActionResult> GetCommentCount()
    {
        int values = await _commentContext.UserComments.CountAsync();
        return Ok(values);
    }
}
