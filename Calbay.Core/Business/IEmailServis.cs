using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calbay.Core.Business
{
    public interface IEmailServis
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
