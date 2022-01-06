using System.Collections.Generic;

namespace Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage
{
    public interface IMessageDistributorConfigSF1601
    {
        List<MessageDistributorConfigSF1601> GetSF1601Entries();
    }
}