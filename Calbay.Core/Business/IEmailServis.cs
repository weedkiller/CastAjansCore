using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Calbay.Core.Business
{
    public interface IEmailServis
    {
        bool SendEmail(string To, string subject, string message, string Cc = "", List<KeyValuePair<string, Stream>> eklentiler = null);
    }
}
