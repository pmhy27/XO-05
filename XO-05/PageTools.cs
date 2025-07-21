using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05
{
    class PageTools
    {
        //將頁面中的元件作分組及排序，建立一個列表準備詢問plc以取得數值
        public List<PlcReadBlock> CreateReadBlocks(List<PlcMappingInfo> dataMappingTable, out Dictionary<string,byte[]> resultsTable)
        {
            var request = new List<PlcReadBlock>();

            if (dataMappingTable == null || dataMappingTable.Count == 0)
            {
                resultsTable = null;
                return request;
            }

            //LINQ GroupBy語法，以DeviceType做分組
            var groupByType = dataMappingTable.GroupBy(m => m.DeviceType);

            foreach (var group in groupByType)
            {
                //各組再分別以LINQ OrderBy語法排序，完成排序後放在一個新的分組
                var orderMapping = group.OrderBy(m => m.address).ToList();

                if (orderMapping.Count == 0) { continue; }

                PlcReadBlock currentBlock = null;

                //如果是bit類型的話要一次以16個為單位問
                if (group.First().isBitType)
                {
                    for (int i = 0; i < orderMapping.Count; i++)
                    {
                        var mapping = orderMapping[i];

                        if (currentBlock == null) //判斷是否新組起始
                        {
                            currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.address-(mapping.address%16), 16);
                        }
                        else
                        {
                            if (mapping.address < (mapping.address + currentBlock.PointsToRead))
                            {
                                continue;                            
                            }
                            else
                                if (mapping.address < mapping.address + currentBlock.PointsToRead + 16)
                                {
                                    currentBlock.PointsToRead += 16;
                                }
                                else
                                {
                                    request.Add(currentBlock);
                                    currentBlock = new PlcReadBlock(mapping.DeviceType, mapping.address - (mapping.address % 16), 16);
                                } 

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

    }
}
