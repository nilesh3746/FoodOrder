using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class ShoppingCartSession 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ShoppingCartSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ShoppingCartId 
        {
            get
            {
                var _shoppingCardId = _session.GetString("CartId");
                if (string.IsNullOrEmpty(_shoppingCardId))
                {
                    return null;
                }

                return _shoppingCardId;
            }
        }
    }
}
