using System;
using System.Collections.Generic;
using System.Text;

namespace TCPInteract
{
    public enum ExecuteCode : byte
    {
        VerificationUser = 1,
        VerificationSuccess = 2,
        VerificationFail = 3,
        Post = 100,
        Get = 200,
        Update = 210,
        UpdateError = 211
    }
}
