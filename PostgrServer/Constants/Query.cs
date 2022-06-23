using System;
using System.Collections.Generic;
using System.Text;

namespace PostgrServer.Constants
{
    public struct Query
    {
        public const string VerifyUser = "SELECT login, password, role FROM checkuser.managers where login = :login";
    }
}
