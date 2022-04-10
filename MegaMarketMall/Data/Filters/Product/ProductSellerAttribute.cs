using System;
using System.Threading.Tasks;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MegaMarketMall.Data.Filters.Product
{
    public class ProductSellerAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IUserService _user;

        public ProductSellerAttribute(IUserService user)=>_user = user;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var query = context.HttpContext.Request.Query["id"].ToString();
            
            if (int.TryParse(query, out var id))
            {
                var checker = await _user.CheckSellerByProductIdAsync(id);
                if (checker)
                    await next.Invoke();
            }
            context.Result = new BadRequestObjectResult("You are not ad's owner");
        }
    }
}