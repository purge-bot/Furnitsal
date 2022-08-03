using System;
using System.Collections.Generic;
using System.Text;

namespace DbQuery
{
    public static class Constants
    {
        public const string VerifyUser = "SELECT login, password, role FROM checkuser.managers where login = :login";
    }
}

