using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomizedControls;

namespace XO_05
{
    public class Page : UserControl

    {  
        
        PageTools _pageTools;
        List<PLCBuffer> _readPlcBuffers;
        public List<PLCBuffer> ReadPlcBuffersList { get { return _readPlcBuffers; } private set { } }
        List<PlcInteractable> _plcInteractableControls;
        public List<PlcInteractable> PlcInteractableControls { get { return _plcInteractableControls; } private set { } }
        List<PlcMappingInfo> _plcMappingInfoTable;
        public List<PlcMappingInfo> PlcMappingInfoTable { get { return _plcMappingInfoTable; } private set { } }


        public Page()
        {   
            _pageTools = new PageTools();
            _readPlcBuffers = new List<PLCBuffer>();
            _plcMappingInfoTable = new List<PlcMappingInfo>();
            _plcInteractableControls = new List<PlcInteractable>();

        }



        /// <summary>
        /// (私有輔助函式) 遞迴地尋找 UserControl。
        /// </summary>
        /// <param name="container">目前正在搜尋的容器。</param>
        /// <param name="listToFill">要將結果加入的列表。</param>
        public void FindAllPlcInteractables(Control container)
        {
            // 遍歷目前容器中的每一個子控制項
            foreach (Control c in container.Controls)
            {

                // 檢查這個子控制項的型別是否為 PlcInteractable
                if (c is PlcInteractable) // 步驟 1: 先檢查 c 是不是 PlcInteractable
                {
                    // 如果是，手動轉型
                    PlcInteractable plcInteractableControl = (PlcInteractable)c;

       
                    _plcInteractableControls.Add(plcInteractableControl);
                }

                // 不論子控制項是什麼類型，只要它裡面還有其他控制項...
                if (c.HasChildren)
                {
                    // ...就對它呼叫同樣的函式，繼續往下尋找 
                    FindAllPlcInteractables(c);
                }
            }
            
        }

        
        public void GetAllReadPlcBuffers() 
        {   
         
            HashSet<Tuple<string,int>> _seenKeys = new HashSet<Tuple<string,int>>();
            foreach (var plcInteractableControl in _plcInteractableControls)
            {
                _seenKeys.Clear();
                _readPlcBuffers.Clear();
                _plcMappingInfoTable.Clear();


                foreach (var unit in _plcInteractableControls)
                {
                    //if (unit.ReadBufferCount <= 0) continue;

                    foreach (var buf in unit.ReadPlcBuffers)
                    {
                        var key = Tuple.Create(buf.DeviceType, buf.Address);
                        

                        if (_seenKeys.Add(key))
                        {
                            _readPlcBuffers.Add(buf);                         
                        }
                        
                        buf.UsedByList.Add(unit);                       
                                             
                    }
                }
            }
            
        }

        protected void EnqueueWrite(PlcWriteBlock block, Action<bool, Exception> callback = null)
        {
            var list = new List<PlcWriteBlock> { block };
            PlcWriteService.Instance.Enqueue(new PlcWriteCommand(list, callback));
        }

        protected void EnqueueWrite(List<PlcWriteBlock> blocks, Action<bool, Exception> callback = null)
        {
            PlcWriteService.Instance.Enqueue(new PlcWriteCommand(blocks, callback));
        }

 

        public void OnPageVisible(){}
        public void OnPageHidden(){}
    }
}
