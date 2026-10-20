using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCore_Concepts.Concepts
{
    /// <summary>
    /// Demonstrates the three main approaches to multi-threading in .NET:
    /// 1. <see cref="Thread"/>      — Classic, low-level, dedicated OS thread.
    /// 2. <see cref="ThreadPool"/>  — Efficient, runtime-managed pool of reusable threads.
    /// 3. <see cref="Task"/>        — Modern TPL wrapper; supports async/await and chaining.
    /// </summary>
    public class MultiThreading
    {
        /// <summary>
        /// Entry point that starts all three threading approaches concurrently,
        /// then waits for them to finish before printing a completion message.
        /// </summary>
        public void RunDemo()
        {
            Console.WriteLine("--- Multi-Threading Demo ---");

            // ---------------------------------------------------------------
            // APPROACH 1: Thread Class (Classic / Low-Level)
            // ---------------------------------------------------------------
            // - Creates a brand-new, dedicated OS-level thread.
            // - ThreadStart is a delegate that tells the thread which method to run.
            // - Start() kicks off the thread; it runs concurrently with Main.
            // - Downside: Creating many threads is expensive (memory + CPU).
            // ---------------------------------------------------------------
            Console.WriteLine("\n1. Starting a thread using Thread class:");
            Thread classicThread = new Thread(new ThreadStart(Method1));
            classicThread.Start();

            // ---------------------------------------------------------------
            // APPROACH 2: ThreadPool (Managed Pool)
            // ---------------------------------------------------------------
            // - Instead of a new thread, borrows one from the CLR's shared thread pool.
            // - WaitCallback is a delegate that accepts an optional `state` object
            //   (useful for passing data into the work item without closures).
            // - More efficient than raw Thread — threads are reused, not recreated.
            // - Downside: No direct handle to wait for (no Join); use
            //   ManualResetEvent or CountdownEvent if you need to wait for it.
            // ---------------------------------------------------------------
            Console.WriteLine("\n2. Queuing work to ThreadPool:");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Method2));

            // ---------------------------------------------------------------
            // APPROACH 3: Task — Task Parallel Library / TPL (Modern & Recommended)
            // ---------------------------------------------------------------
            // - Task.Run() schedules work on the ThreadPool but wraps it in a
            //   Task object, which is much richer than a raw pool work item.
            // - Supports: async/await, .ContinueWith() chaining, cancellation
            //   tokens, return values (Task<T>), and exception propagation.
            // - This is the recommended approach for all new .NET code.
            // ---------------------------------------------------------------
            Console.WriteLine("\n3. Starting a Task:");
            Task task = Task.Run(() => Method3());

            // ---------------------------------------------------------------
            // SYNCHRONIZATION: Waiting for concurrent work to finish
            // ---------------------------------------------------------------
            // - classicThread.Join() blocks the main thread until Method1 is done.
            // - task.Wait()          blocks the main thread until Method3 is done.
            // - NOTE: Method2 (ThreadPool) has no explicit wait here — in a real
            //   app you would use ManualResetEventSlim or similar to wait for it.
            // - In modern code, prefer `await task` inside an async method over
            //   task.Wait() to avoid blocking the calling thread.
            // ---------------------------------------------------------------
            classicThread.Join();
            task.Wait();

            Console.WriteLine("\nAll threads/tasks completed.");
        }

        /// <summary>
        /// Worker method run on a dedicated <see cref="Thread"/>.
        /// Simulates 3 units of work, each taking 500 ms.
        /// </summary>
        private void Method1()
        {
            // Loop 3 times to simulate iterative work (e.g., processing 3 records).
            // Because this runs on a separate thread, these iterations happen
            // concurrently with Method2 and Method3.
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Method1 (Thread Class) is executing: {i}");
                Thread.Sleep(500); // Simulate I/O or CPU-bound work taking 500 ms
            }
        }

        /// <summary>
        /// Worker method queued on the <see cref="ThreadPool"/> via <see cref="WaitCallback"/>.
        /// The <paramref name="state"/> parameter can carry any data passed by the caller;
        /// it is <c>null</c> here because no state was provided to <c>QueueUserWorkItem</c>.
        /// </summary>
        /// <param name="state">Optional state object passed from the caller. Can be null.</param>
        private void Method2(object? state)
        {
            // Same iterative pattern as Method1, but executing on a pool thread.
            // The 'state' object would allow the caller to pass data in without
            // using a closure — e.g., ThreadPool.QueueUserWorkItem(Method2, myData).
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Method2 (ThreadPool) is executing: {i}");
                Thread.Sleep(500); // Simulate work
            }
        }

        /// <summary>
        /// Worker method run inside a <see cref="Task"/> via <c>Task.Run()</c>.
        /// Internally scheduled on the ThreadPool, but wrapped with Task's
        /// richer feature set (cancellation, continuation, async/await).
        /// </summary>
        private void Method3()
        {
            // Same iterative pattern as Method1 and Method2.
            // In a real app this could be: await httpClient.GetAsync(...)
            // or any other async/awaitable operation.
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Method3 (Task) is executing: {i}");
                Thread.Sleep(500); // Simulate work
            }
        }
    }
}
