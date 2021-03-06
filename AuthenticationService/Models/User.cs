﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class User
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

		[JsonProperty("userName")]
		public string UserName { get; set; }

		[JsonProperty("email")]
		public string EMail { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        
    }
}
