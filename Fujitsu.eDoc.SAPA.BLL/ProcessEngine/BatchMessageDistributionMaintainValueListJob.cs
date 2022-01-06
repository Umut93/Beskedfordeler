
using Fujitsu.eDoc.SAPA.MsgDistributorService;
using Fujitsu.eDoc.SAPA.MsgDistributorService.Helper;
using System;
using System.Linq;
using System.Net;

namespace Fujitsu.eDoc.SAPA.BLL.ProcessEngine
{
    public static class BatchMessageDistributionMaintainValueListJob
    {
        private const string LogName = "MsgDistributor";

        public static void MainTainValueList()
        {
            //Get token first
            //SecurityToken token = TokenFetcher.IssueToken(ConfigVariables.ServiceEntityId);
            //sletvaerdilisteRequest slet = new sletvaerdilisteRequest { SletInput = new UuidNoteInputType { UUIDIdentifikator = "777a7183-e1ab-48c9-bebe-79b115d5ffde" } };
            //channel.sletvaerdiliste(slet);
            //BeskedfordelerPortType channel2 = CreateChannel(token);
            
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false;
                var channel = SF1460BClient.CreateChannel();

                bool isCreated = MaintainValueHelper.IsMainTainListCreated(channel);
                var edocSocialSecurityNumbers = MaintainValueHelper.LoadSocialSecurityNumbersInEdoc();

                if (isCreated)
                {
                    string[] MsgDistributorMaintainValues = MaintainValueHelper.FetchMaintainListValues(channel);
                    MaintainValueHelper.MaintainSocialSecurityNumbers(edocSocialSecurityNumbers, MsgDistributorMaintainValues,channel);
                }

                else
                {
                    if (edocSocialSecurityNumbers.Any())
                    {
                        var request = MaintainValueHelper.CreateMainTainList(edocSocialSecurityNumbers);
                        var response = channel.opretvaerdiliste(request);
                        if (response.OpretOutput.StandardRetur.StatusKode == "20")
                            Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionMaintainValueListJob).FullName, LogName, $"MaintainList has been succesfully created.", System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }

            catch (Exception ex)
            {
                Fujitsu.eDoc.Core.Common.SimpleEventLogging(typeof(BatchMessageDistributionMaintainValueListJob).FullName, LogName, $"The job execution failed for maintaining the list - {System.Environment.NewLine} {ex}", System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}