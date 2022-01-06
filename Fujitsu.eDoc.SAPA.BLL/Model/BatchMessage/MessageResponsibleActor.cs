
using System;
using System.Collections.Generic;

namespace Fujitsu.eDoc.SAPA.BLL.Model.BatchMessage
{
    public enum MessageResponsibleActor
    {
        Unknown = 0,
        DigitalPost = 1,
        Strålfors = 2,
        Edora = 3,
        KMDCharlieTango = 4,

    }

    public class MessageActor
    {
        public static Dictionary<int, Guid> MessageResponsibleActors = new Dictionary<int, Guid>()
    {
        {(int)MessageResponsibleActor.Unknown, Guid.Empty },
        {(int)MessageResponsibleActor.DigitalPost, Guid.Parse("96514e13-afdd-44d6-95a8-adc2ca19b127")},
        {(int)MessageResponsibleActor.Strålfors, Guid.Parse("afd21f3d-11c7-4f51-b2a6-f31d6480a9fb")},
        {(int)MessageResponsibleActor.Edora, Guid.Parse("ae5b9a93-c923-40d7-a41a-1eec18374e27")},
        {(int)MessageResponsibleActor.KMDCharlieTango, Guid.Parse("6b12182a-4268-4130-bd3e-159f8862c0a1")}
    };
    }
}
