using AshrafsAdvancedSweetShop.Models.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsAdvancedSweetShop.Models
{
    public class ShoppingCart
    {
        private readonly CandyDbContext _candyDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(CandyDbContext candyDbContext)
        {
            _candyDbContext = candyDbContext;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<CandyDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Candy candy, int amount)
        {
            var shoppingCartItem = _candyDbContext.ShoppingCartItems
                                    .SingleOrDefault(s => s.Candy.CandyId == candy.CandyId
                                    && s.ShoppingCartId == ShoppingCartId);

            //If item not found in shopping cart you will neeed to add one otherwise you modify amount
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Candy = candy,
                    Amount = amount
                };

                _candyDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _candyDbContext.SaveChanges();
        }

        public int RemoveFromCart(Candy candy)
        {
            var shoppingCartItem = _candyDbContext.ShoppingCartItems
                                    .SingleOrDefault(s => s.Candy.CandyId == candy.CandyId
                                    && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _candyDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _candyDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _candyDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Candy)
                    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _candyDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _candyDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _candyDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _candyDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                        .Select(c => c.Candy.Price * c.Amount).Sum();

            return total;
        }
    }
}
