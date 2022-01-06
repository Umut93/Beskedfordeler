using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fujitsu.eDoc.SAPA.BLL.MessageHandlers
{
    public interface IMessageHandler
    {
        string MessageTypeName { get; }

        void Process(XDocument message);
    }
}
