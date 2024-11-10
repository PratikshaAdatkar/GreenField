using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty
{
    public static class PenaltyHandler
    {
        public static void ServiceDisconnectionPenaltycharges(float amount)
        {
            Console.WriteLine("disconnection charges applied=" + amount);
        }
        public static void NotificationPenaltyCharges(float amount)
        {
            Console.WriteLine("notification charges applied=" + amount);
        }
    }
}