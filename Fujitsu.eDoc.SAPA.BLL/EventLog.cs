using Fujitsu.eDoc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.eDoc.SAPA.BLL
{
    public class EventLog
    {
        public static void LogToEventLog(string message, System.Diagnostics.EventLogEntryType type)
        {
            try
            {
                Core.Common.SimpleEventLogging("Fujitsu.eDoc.SAPA.BLL", "SAPA", message, type);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void LogToEventLogUserSync(string message, System.Diagnostics.EventLogEntryType type)
        {
            try
            {
                Core.Common.SimpleEventLogging("Fujitsu.eDoc.SAPA.BLL", "UserStsOrgSync", message, type);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void LogToEventLogOrgSync(string message, System.Diagnostics.EventLogEntryType type)
        {
            try
            {
                Core.Common.SimpleEventLogging("Fujitsu.eDoc.SAPA.BLL", "StsOrgSync", message, type);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
