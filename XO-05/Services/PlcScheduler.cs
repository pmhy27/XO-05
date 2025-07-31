using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace XO_05.Services
{
    public sealed class PlcScheduler : IPlcScheduler
    {
        private readonly BlockingCollection<Func<Task>> _queue = new BlockingCollection<Func<Task>>(new ConcurrentQueue<Func<Task>>());

        private readonly Task _worker;

        public PlcScheduler()
        {
            _worker = Task.Factory.StartNew(ProcessLoop, TaskCreationOptions.LongRunning);
        }

        private void ProcessLoop()
        {
            foreach (var work in _queue.GetConsumingEnumerable())
            {
                try
                {
                    work().Wait();
                }
                catch (AggregateException ae)
                {
                    Trace.WriteLine(ae.Flatten().InnerException);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                }
            }
        }

        public Task<T> Enqueue<T>(Func<T> job)
        { 
            var tcs = new TaskCompletionSource<T>();
            _queue.Add
            (
                () =>
                {
                    return Task.Factory.StartNew
                    (
                        () =>
                        {
                            try
                            {
                                var result = job();
                                tcs.SetResult(result);
                            }
                            catch (Exception ex)
                            {
                                tcs.SetException(ex);
                            }
                        }
                    );
                }
            );
            return tcs.Task;
        }

        public Task Enqueue(Action job)
        {
            var tcs = new TaskCompletionSource<Object>();
            _queue.Add
            (
                () =>
                {
                    return Task.Factory.StartNew
                    (
                        () =>
                        {
                            try
                            {
                                job();
                                tcs.SetResult(null);
                            }
                            catch(Exception ex)
                            {
                                tcs.SetException(ex);
                            }
                        }
                    );
                }
            );
            return tcs.Task;
        }

        public void Dispose()
        {
            _queue.CompleteAdding();
            try
            {
                _worker.Wait();
            }
            catch 
            {
                _queue.Dispose();
            }
        }

    }

}
