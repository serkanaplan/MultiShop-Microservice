using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService) : ViewComponent
{
    private readonly IMessageService _messageService = messageService;
    private readonly IUserService _userService = userService;
    private readonly ICommentService _commentService = commentService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetUserInfo();
        int messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
        ViewBag.messageCount = messageCount;

        int totalCommentcount = await _commentService.GetTotalCommentCount();
        ViewBag.totalCommentCount = totalCommentcount;  

        return View();
    }
}
