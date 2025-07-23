using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05
{
    interface IpageLifecycle
    {
        List<PlcMappingInfo>  UnitsTable { get; }

        void OnPageVisible();
        void OnPageHidden();

        //List<PlcReadBlock> GetPlcReadRequests(List<PlcMappingInfo> unitsTable);
        //Dictionary<string, short> GetPlcDataMapppingTable(List<PlcReadBlock> unitsTable, short[] resultsFromPlc);

    }
}
