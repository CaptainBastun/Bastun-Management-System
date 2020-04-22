namespace BMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IEmailSender
    {
        void Send(string emailAddress, string content,string emailSubject);
    }
}
