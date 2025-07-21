using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05
{
    class PageTools
    {
        #region 
        //將頁面中的元件作分組及排序，建立一個列表準備詢問plc以取得數值
        public List<PlcReadBlock> CreateReadBlocks(List<PlcMappingInfo> unitsTable)
        {
            var request = new List<PlcReadBlock>();

            if (unitsTable == null || unitsTable.Count == 0)
            {
                return request;
            }

            //LINQ GroupBy語法，以DeviceType做分組
            var groupByType = unitsTable.GroupBy(m => m.DeviceType);

            foreach (var group in groupByType)
            {
                //各組再分別以LINQ OrderBy語法排序，完成排序後放在一個新的分組
                var orderMapping = group.OrderBy(m => m.address).ToList();

                if (orderMapping.Count == 0) { continue; }

                PlcReadBlock currentBlock = null;

                //如果是bit類型的話要一次以16個為單位問
                if (group.First().isBitType)
                {
                    var alignedBlockAddresses = new HashSet<int>();
                    //  遍歷這個群組中的每一個 mapping
                    foreach (var mapping in group)
                    {
                        //  為每一個 mapping 計算它所屬的、16 點對齊的起始位址。
                        //    例如 M17 -> 16, M31 -> 16, M33 -> 32
                        int alignedAddress = mapping.address - (mapping.address % 16);

                        //  嘗試將這個對齊後的位址加入 HashSet。
                        //    HashSet 的 .Add() 方法只有在項目「首次」加入時才會回傳 true。
                        //    如果是重複的項目，它會回傳 false，並且什麼都不做。
                        if (alignedBlockAddresses.Add(alignedAddress))
                        {
                            //  只有在這是我們第一次遇到這個 16 點區塊時，
                            //  才建立一個新的 PlcReadBlock 並加入到最終的請求列表中。
                            request.Add(new PlcReadBlock(mapping.DeviceType, alignedAddress, 16));
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

                        if (currentBlock == null) //新組起始
                        {
                            currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.address, 1);
                        }
                        else
                        {
                            if (mapping.address == currentBlock.StartAddress + currentBlock.PointsToRead) //檢查是否連續
                            {
                                currentBlock.PointsToRead++;
                            }
                            else //發現不連續，把前一組做一個結尾，再起新組
                            {
                                request.Add(currentBlock);
                                currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.address, 1);
                            }

                        }
                    }


                }

                if (currentBlock != null) //最後一組別忘了加
                {
                    request.Add(currentBlock);
                }

            }

            return request;

        }
        #endregion



        #region 
        public Dictionary<string, short> CreateResultsMappingTablle(List<PlcMappingInfo> unitTable, short[] resultsFromPlc)
        {
            // 1. 初始化最終要回傳的結果字典
            var finalResults = new Dictionary<string, short>();
            if (unitTable == null || resultsFromPlc == null)
            {
                return finalResults;
            }

            // 2. 【核心】我們需要知道原始的請求是如何被最佳化的。
            //    因此，我們再次呼叫 CreateReadBlocks 來「重演」這個過程，
            //    以取得最佳化後的讀取區塊列表 (optimizedRequests)。
            List<PlcReadBlock> optimizedRequests = this.CreateReadBlocks(unitTable);

            int bufferIndex = 0; // 一個指標，用來追蹤我們在 resultsFromPlc 陣列中的當前位置

            // 3. 遍歷每一個「最佳化後」的讀取區塊
            foreach (var block in optimizedRequests)
            {
                // 4. 對於每個區塊，我們再回頭去遍歷「原始的」、詳細的資料對應表
                foreach (var mapping in unitTable)
                {
                    // 5. 檢查這個 UI 元件的資料是否位於當前處理的 PLC 數據塊中
                    if (mapping.DeviceType == block.DeviceType &&
                        mapping.address >= block.StartAddress &&
                        mapping.address < block.StartAddress + block.PointsToRead)
                    {
                        // 6. 計算此位址在當前區塊 buffer 中的相對位置 (偏移量)
                        int offset = mapping.address - block.StartAddress;

                        // 7. 從 PLC 回傳的原始數據中，根據指標和偏移量，取出對應的 16-bit Word 值
                        //    加上 try-catch 增加穩健性，防止索引超出範圍
                        try
                        {
                            short wordValue = resultsFromPlc[bufferIndex + offset];

                            // 8. 根據對應關係是 Bit 還是 Word，進行最終的解析
                            if (mapping.isBitType)
                            {
                                // 進行位元運算，解析出 bool 值
                                bool bitStatus = (wordValue & (1 << mapping.BitIndex)) != 0;
                                finalResults[mapping.UniqueKey] = bitStatus; // 將解析後的 bool 值存入
                            }
                            else
                            {
                                // 直接將 short 值存入
                                finalResults[mapping.UniqueKey] = wordValue;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // 如果發生索引錯誤，可能是 PLC 回傳的資料長度不如預期
                            // 可以在此處記錄錯誤日誌
                            Console.WriteLine("警告: 嘗試存取 resultsFromPlc 時索引超出範圍。Key: " + mapping.UniqueKey);
                        }
                    }
                }

                // 9. 當處理完一個區塊後，將指標向前推進這個區塊的長度
                bufferIndex += block.PointsToRead;
            }

            return finalResults;
        }
        #endregion


    }
}
