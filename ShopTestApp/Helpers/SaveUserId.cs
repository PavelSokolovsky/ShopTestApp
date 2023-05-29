using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTestApp.Helpers
{
    public partial class SaveUserId
    {
        public string UserLogin { get; set;}
        public string UserPassword { get; set;}

        public SaveUserId(string userLogin, string userPassword)
        {

        }
    }
}
