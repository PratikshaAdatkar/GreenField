using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
using Specification;

namespace Services
{
    public class OrderService : IOrderService
    {
        private List<Order> _orderList;
        public OrderService()
        {
            this._orderList = new List<Order>();

        }
        public bool Delete(int OrderId)
        {
            Order theOrder = this.Get(OrderId);
            return this._orderList.Remove(theOrder);
        }

        public Order Get(int OrderId)
        {
            foreach (var order in _orderList)
            {
                if (order.Id == OrderId) return order;
            }
            return null;
        }

        public List<Order> GetAll()
        {
            return _orderList;
        }

        public bool Insert( Order order)
        {
            this._orderList.Add(order);
            return true;
        }

        public bool Update(Order order)
        {
            Order theOrder = this.Get(order.Id); //-id, order date, amount, status-cancel, delivered
            theOrder.Id = order.Id;
            theOrder.Id = order.Id;
            theOrder.Amount = order.Amount;
            return true;
           
        }
    }
}
