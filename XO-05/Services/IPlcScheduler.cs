using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO_05.Services
{
    interface IPlcScheduler : IDisposable
    {
        Task<T> Enqueue<T>(Func<T> job); //需要回傳值
        Task Enqueue(Action job); //不需回傳值
    }
}
