using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05
{
    interface IpageLifecycle
    {
        void OnPageVisible();
        void OnPageHidden();

        List<PlcReadBlock> GetPlcReadRequests(out Dictionary<string, byte[]> resultsTable);

        void UpdateUi(Dictionary<string, short[]> plcdata);
    }
}
