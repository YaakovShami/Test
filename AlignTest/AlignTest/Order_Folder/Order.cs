using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignTest.Order_Folder
{
    class Order
    {
        public int id;
        public int petID;
        public int quantity;
        public string shipDate;
        public OrderStatus status;
        public bool complete;

        public Order(int id, int petID, int quantity, string shipDate, OrderStatus status, bool complete)
        {
            this.id = id;
            this.petID = petID;
            this.quantity = quantity;
            this.shipDate = shipDate;
            this.status = status;
            this.complete = complete;
        }



    }
}
