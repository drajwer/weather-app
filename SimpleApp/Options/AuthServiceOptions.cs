using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Options
{
    public class AuthServiceOptions
    {
        // This should be hashed (e.g. md5) in real app.
        public string AdminPassword { get; set; }
    }
}
