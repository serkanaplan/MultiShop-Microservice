using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService) : Controller
{
    private readonly ICatalogStatisticService _catalogStatisticService = catalogStatisticService;
    private readonly IUserStatisticService _userStatisticService = userStatisticService;
    private readonly ICommentService _commentService = commentService;
    private readonly IDiscountStatisticService _discountStatisticService = discountStatisticService;
    private readonly IMessageStatisticService _messageStatisticService = messageStatisticService;

    public async Task<IActionResult> Index()
    {
        var getBrandCount = await _catalogStatisticService.GetBrandCount();
        var getProductCount = await _catalogStatisticService.GetProductCount();
        var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
        var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
        var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

        var getUserCount = await _userStatisticService.GetUsercount();

        var getTotalCommentCount = await _commentService.GetTotalCommentCount();
        var getActiveCommentCount = await _commentService.GetActiveCommentCount();
        var getPassiveCommentCount = await _commentService.GetPAssiveCommentCount();

        var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

        var getMessageTotalCount = await _messageStatisticService.GetTotalMessageCount();

        ViewBag.getBrandCount = getBrandCount;
        ViewBag.getProductCount = getProductCount;
        ViewBag.getCategoryCount = getCategoryCount;
        ViewBag.getMaxPriceProductName = getMaxPriceProductName;
        ViewBag.getMinPriceProductName = getMinPriceProductName;

        ViewBag.getUserCount = getUserCount;

        ViewBag.getTotalCommentCount = getTotalCommentCount;
        ViewBag.getActiveCommentCount = getActiveCommentCount;
        ViewBag.getPassiveCommentCount = getPassiveCommentCount;

        ViewBag.getDiscountCouponCount = getDiscountCouponCount;

        ViewBag.getMessageTotalCount = getMessageTotalCount;

        return View();
    }
}
