using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    public class EnvironmentModel
    {
        public IEnumerable<KeyValuePair<string, string>> VcapVariables { get; set; }
    }
}