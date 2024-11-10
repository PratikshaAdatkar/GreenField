using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public interface IOrderService
    {
        List<Order> GetAll();//generic class symbol<> //abstract method
        Order Get(int orderid);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}