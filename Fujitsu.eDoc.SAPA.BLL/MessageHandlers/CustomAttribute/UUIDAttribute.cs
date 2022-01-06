using System;


namespace Fujitsu.eDoc.SAPA.BLL.MessageHandlers
{
    public class UUIDAttribute : Attribute
    {
        public string UUID { get; set; }
        public UUIDAttribute(string uuid)
        {
            UUID = uuid;
        }
    }
}
