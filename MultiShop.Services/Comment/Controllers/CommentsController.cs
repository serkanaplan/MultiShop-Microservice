using Comment.Context;
using Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentsController(CommentContext context) : ControllerBase
{
    private readonly CommentContext _context = context;

    [HttpGet]
    public IActionResult CommentList()
    {
        var values = _context.UserComments.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateComment(UserComment userComment)
    {
        _context.UserComments.Add(userComment);
        _context.SaveChanges();
        return Ok("Yorum başarıyla eklendi");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        var value = _context.UserComments.Find(id);
        _context.UserComments.Remove(value);
        _context.SaveChanges();
        return Ok("Yorum başarıyla silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        var value = _context.UserComments.Find(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateComment(UserComment userComment)
    {
        _context.UserComments.Update(userComment);
        _context.SaveChanges();
        return Ok("Yorum başarıyla güncellendi");
    }

    [HttpGet("CommentListByProductId/{id}")]
    public IActionResult CommentListByProductId(string id)
    {
        var value = _context.UserComments.Where(x => x.ProductId == id).ToList();
        return Ok(value);
    }

    [HttpGet("GetActiveCommentCount")]
    public IActionResult GetActiveCommentCount()
    {
        int value = _context.UserComments.Where(x => x.Status == true).Count();
        return Ok(value);
    }

    [HttpGet("GetPassiveCommentCount")]
    public IActionResult GetPassiveCommentCount()
    {
        int value = _context.UserComments.Where(x => x.Status == false).Count();
        return Ok(value);
    }

    [HttpGet("GetTotalCommentCount")]
    public IActionResult GetTotalCommentCount()
    {
        int value = _context.UserComments.Count();
        return Ok(value);
    }
}
