using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Data.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string userId {get;set;}

        public List<WorkerProduct> Products { get; set; }
    }
}
