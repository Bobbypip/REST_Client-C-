using System;
using System.Collections.Generic;
using System.Text;

namespace REST_Client.Models
{
    public class GeneroGet : IModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
