using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05
{
    public class PlcDataChangedEventArgs : EventArgs
    {
        public IList<PLCBuffer> ChangedItems { get; private set; }

        public PlcDataChangedEventArgs(IList<PLCBuffer> changedItems)
        {
            ChangedItems = changedItems;
        }
    }
}
