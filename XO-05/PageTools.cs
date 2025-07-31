using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XO_05
{
    class PageTools
    {

        #region
        //將頁面中的元件作分組及排序，建立一個列表準備詢問plc以取得數值
        public List<PlcReadBlock> CreateReadBlocks(List<PLCBuffer>  unitsTable)
        {
            int tempIndex = 0;
            var request = new List<PlcReadBlock>();

            if (unitsTable == null || unitsTable.Count == 0)
            {
                return request;
            }

            //先去除重複的元素
            var distinctUnitsTable = unitsTable
            .GroupBy(m => new { m.DeviceType, m.Address }) // 用 DeviceType 和 Address 作為複合鍵來分組
            .Select(g => g.First())                       // 從每個分組中只選取第一個元素
            .ToList();                                    // 將結果轉回 List

            //LINQ GroupBy語法，以DeviceType做分組
            var groupByType = unitsTable.GroupBy(m => m.DeviceType);

            foreach (var group in groupByType)
            {
                //各組再分別以LINQ OrderBy語法排序，完成排序後放在一個新的分組
                var orderMapping = group.OrderBy(m => m.Address).ToList();

                if (orderMapping.Count == 0) { continue; }

                PlcReadBlock currentBlock = null;

                //如果是bit類型的話要一次以16個為單位問
                if (PlcMappingInfo.isBitType(group.First().DeviceType))
                {
                    var alignedBlockAddresses = new HashSet<int>();
                    //  遍歷這個群組中的每一個 mapping
                    foreach (var mapping in group)
                    {
                        //  為每一個 mapping 計算它所屬的、16 點對齊的起始位址。
                        //    例如 M17 -> 16, M31 -> 16, M33 -> 32
                        int alignedAddress = mapping.Address - (mapping.Address % 16);
                        mapping.IndexInResultsArray = tempIndex;
                        mapping.BitIndexInIndexInResultsArray = (mapping.Address % 16);

                        //  嘗試將這個對齊後的位址加入 HashSet。
                        //    HashSet 的 .Add() 方法只有在項目「首次」加入時才會回傳 true。
                        //    如果是重複的項目，它會回傳 false，並且什麼都不做。
                        if (alignedBlockAddresses.Add(alignedAddress))
                        {
                            //  只有在這是我們第一次遇到這個 16 點區塊時，
                            //  才建立一個新的 PlcReadBlock 並加入到最終的請求列表中。
                            request.Add(new PlcReadBlock(mapping.DeviceType, alignedAddress, 16));
                            tempIndex += 1;
                        }
                        else
                        {
                            mapping.IndexInResultsArray -= 1;
                        }

                    }

                }

                //如果是word類型的話以單個單個為單位
                else
                {
                    //各組順序檢查元件是否連續，連續的只要調整詢問數目就可以一起問；不連續的就要再分出一個詢問組
                    for (int i = 0; i < orderMapping.Count; i++)
                    {
                        var mapping = orderMapping[i];
                        mapping.IndexInResultsArray = tempIndex;
                        tempIndex += 1;

                        if (currentBlock == null) //新組起始
                        {
                            currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.Address, 1);
                        }
                        else
                        {
                            if (mapping.Address == currentBlock.StartAddress + currentBlock.PointsToRead) //檢查是否連續
                            {
                                currentBlock.PointsToRead += 1;
                            }
                            else //發現不連續，把前一組做一個結尾，再起新組
                            {
                                request.Add(currentBlock);
                                currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.Address, 1);
                            }

                        }
                    }

                    if (currentBlock != null) //最後一組別忘了加
                    {
                        request.Add(currentBlock);
                    }

                }

            }

            return request;

        }
        #endregion



        #region
        public Dictionary<string, short> CreateResultsMappingTablle(List<PlcMappingInfo> unitTable, short[] resultsFromPlc)
        {
            return new Dictionary<string, short>();
        }
        #endregion


    }
}
