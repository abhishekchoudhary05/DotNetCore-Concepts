using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCore_Concepts.Concepts
{
    /// <summary>
    /// Demonstrates the concept of a Deadlock in multi-threading.
    /// 
    /// What is a Deadlock?
    /// A deadlock occurs when two or more threads are permanently blocked,
    /// each waiting for a resource (lock) that the other thread holds.
    /// Neither thread can proceed, and the program hangs.
    /// 
    /// The 4 conditions required for deadlock (Coffman Conditions):
    /// 1. Mutual Exclusion  : Resources cannot be shared simultaneously.
    /// 2. Hold and Wait     : A thread holds a resource while waiting for another.
    /// 3. No Preemption     : Resources cannot be forcibly taken from a thread.
    /// 4. Circular Wait     : A closed chain of threads exists where each waits for a resource held by the next.
    /// </summary>
    public class Deadlock
    {
        // Two shared resources (locks)
        private readonly object _lockA = new object();
        private readonly object _lockB = new object();

        /// <summary>
        /// Demonstrates a classic circular-wait deadlock scenario:
        /// - Thread 1 acquires Lock A, then tries to acquire Lock B.
        /// - Thread 2 acquires Lock B, then tries to acquire Lock A.
        /// Both threads end up waiting for each other indefinitely.
        /// </summary>
        public void SimulateDeadlock()
        {
            Console.WriteLine("=== Simulating Deadlock ===");
            Console.WriteLine("Thread 1 will try to lock A -> B");
            Console.WriteLine("Thread 2 will try to lock B -> A\n");

            Thread thread1 = new Thread(Thread1Action) { Name = "Thread 1" };
            Thread thread2 = new Thread(Thread2Action) { Name = "Thread 2" };

            // Start both threads
            thread1.Start();
            thread2.Start();

            // Note: If you join both threads here, the main thread will also hang!
            // thread1.Join();
            // thread2.Join();
        }

        /// <summary>
        /// Demonstrates how to avoid deadlocks by enforcing consistent lock ordering:
        /// If ALL threads acquire locks in the exact same order (e.g., always Lock A before Lock B),
        /// circular wait is impossible and deadlock cannot occur.
        /// </summary>
        public void AvoidDeadlockUsingConsistentLockOrder()
        {
            Console.WriteLine("\n=== Avoiding Deadlock (Consistent Lock Ordering) ===");
            Console.WriteLine("Both Thread 1 and Thread 2 will lock in order: Lock A -> Lock B\n");

            Thread thread1 = new Thread(SafeThread1Action) { Name = "Safe Thread 1" };
            Thread thread2 = new Thread(SafeThread2Action) { Name = "Safe Thread 2" };

            thread1.Start();
            thread2.Start();

            // Wait for both safe threads to finish
            thread1.Join();
            thread2.Join();

            Console.WriteLine("\nBoth safe threads completed successfully without deadlock!");
        }

        #region Deadlock Actions (Circular Wait)

        private void Thread1Action()
        {
            lock (_lockA)
            {
                Console.WriteLine("[Thread 1] Acquired Lock A.");
                // Sleep briefly to ensure Thread 2 has time to acquire Lock B
                Thread.Sleep(500);

                Console.WriteLine("[Thread 1] Attempting to acquire Lock B...");
                lock (_lockB)
                {
                    // This block will never be reached in a deadlock!
                    Console.WriteLine("[Thread 1] Acquired Lock B.");
                }
            }
        }

        private void Thread2Action()
        {
            lock (_lockB)
            {
                Console.WriteLine("[Thread 2] Acquired Lock B.");
                // Sleep briefly to ensure Thread 1 has time to acquire Lock A
                Thread.Sleep(500);

                Console.WriteLine("[Thread 2] Attempting to acquire Lock A...");
                lock (_lockA)
                {
                    // This block will never be reached in a deadlock!
                    Console.WriteLine("[Thread 2] Acquired Lock A.");
                }
            }
        }

        #endregion

        #region Safe Actions (Consistent Ordering)

        private void SafeThread1Action()
        {
            // Consistent order: Lock A first, then Lock B
            lock (_lockA)
            {
                Console.WriteLine("[Safe Thread 1] Acquired Lock A.");
                Thread.Sleep(200);

                lock (_lockB)
                {
                    Console.WriteLine("[Safe Thread 1] Acquired Lock B. Doing work...");
                }
            }
            Console.WriteLine("[Safe Thread 1] Released both locks.");
        }

        private void SafeThread2Action()
        {
            // Consistent order: Lock A first, then Lock B (no circular wait!)
            lock (_lockA)
            {
                Console.WriteLine("[Safe Thread 2] Acquired Lock A.");
                Thread.Sleep(200);

                lock (_lockB)
                {
                    Console.WriteLine("[Safe Thread 2] Acquired Lock B. Doing work...");
                }
            }
            Console.WriteLine("[Safe Thread 2] Released both locks.");
        }

        #endregion
    }
}
