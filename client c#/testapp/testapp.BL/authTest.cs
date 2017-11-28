using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testapp.BL
{
    public interface IAuth
    {
        bool auth(string login, string passwd);
    }
    public class authTest : IAuth
    {
        public bool auth(string login, string passwd)
        {
            if(login == "paramonod" && passwd == "12345")
            {
                return true;
            } 
            return false;
        }
    }
}
