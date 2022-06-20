using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPInteraction
{
    interface IRequest
    {
        byte[] Length { get; set; }
        byte[] RequestBody { get; set; }
    }
}
