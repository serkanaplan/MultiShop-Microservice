using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
public class MessageController(IMessageService messageService, IUserService userService) : Controller
{
    private readonly IMessageService _messageService = messageService;
    private readonly IUserService _userService = userService;

    public async Task<IActionResult> Inbox()
    {
        var user = await _userService.GetUserInfo();
        var values = await _messageService.GetInboxMessageAsync(user.Id);
        return View(values);
    }

    public async Task<IActionResult> Sendbox()
    {
        var user = await _userService.GetUserInfo();
        var values = await _messageService.GetSendboxMessageAsync(user.Id);
        return View(values);
    }
}
