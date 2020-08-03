using System;
using System.Collections.Generic;
using System.Text;

namespace REST_Client
{
    interface IModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
