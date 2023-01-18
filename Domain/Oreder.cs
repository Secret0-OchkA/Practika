using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int Id { get; protected set; }
        public Patient Patient { get; set; }

        public List<ServiceInOrder> serviceInOrders { get; protected set; } = new List<ServiceInOrder>();
    }
    public class ServiceInOrder
    {
        public string Id { get; protected set; }
        public Blood PatientBlood { get; set; }
        public Service service { get; set; }
    }
}
