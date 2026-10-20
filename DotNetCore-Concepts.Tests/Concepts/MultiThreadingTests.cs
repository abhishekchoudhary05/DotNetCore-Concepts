using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore_Concepts.Concepts;
using Xunit;

namespace DotNetCore_Concepts.Tests.Concepts;

/// <summary>
/// Tests for the <see cref="MultiThreading"/> class demonstrating:
/// - Thread class (Classic threading approach)
/// - ThreadPool (Managed thread pool queue)
/// - Task Parallel Library (Modern TPL Task.Run)
/// - Thread synchronization and coordination (Join, Wait)
/// </summary>
public class MultiThreadingTests
{
    private static readonly object ConsoleLock = new();

    /// <summary>
    /// Helper method to capture console output safely with thread synchronization.
    /// </summary>
    private static string CaptureConsoleOutput(Action action)
    {
        lock (ConsoleLock)
        {
            var originalOut = Console.Out;
            using var sw = new StringWriter();
            try
            {
                Console.SetOut(sw);
                action();
                return sw.ToString();
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
    }

    /// <summary>
    /// Tests that the MultiThreading class can be instantiated successfully.
    /// </summary>
    [Fact]
    public void MultiThreading_CanBeInstantiated_Successfully()
    {
        var instance = new MultiThreading();
        Assert.NotNull(instance);
    }

    /// <summary>
    /// Tests that RunDemo executes to completion without throwing any exceptions.
    /// </summary>
    [Fact]
    public void RunDemo_ExecutesSuccessfully_WithoutExceptions()
    {
        var multiThreading = new MultiThreading();
        var exception = Record.Exception(() => multiThreading.RunDemo());
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that RunDemo completes within a reasonable timeout and does not hang or deadlock.
    /// </summary>
    [Fact]
    public async Task RunDemo_CompletesWithinTimeout_NoDeadlock()
    {
        var multiThreading = new MultiThreading();
        var task = Task.Run(() => multiThreading.RunDemo());
        var completedTask = await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(10)));

        Assert.Equal(task, completedTask);
        Assert.True(task.IsCompletedSuccessfully);
    }

    /// <summary>
    /// Tests that RunDemo prints expected header and status messages to the console.
    /// </summary>
    [Fact]
    public void RunDemo_WritesExpectedOutputToConsole()
    {
        var multiThreading = new MultiThreading();

        var output = CaptureConsoleOutput(() =>
        {
            multiThreading.RunDemo();
            // Allow a small grace period for ThreadPool work item to finish printing
            Thread.Sleep(600);
        });

        Assert.Contains("--- Multi-Threading Demo ---", output);
        Assert.Contains("1. Starting a thread using Thread class:", output);
        Assert.Contains("2. Queuing work to ThreadPool:", output);
        Assert.Contains("3. Starting a Task:", output);
        Assert.Contains("All threads/tasks completed.", output);

        // Verify output from Method1 (Thread class)
        Assert.Contains("Method1 (Thread Class) is executing: 1", output);
        Assert.Contains("Method1 (Thread Class) is executing: 2", output);
        Assert.Contains("Method1 (Thread Class) is executing: 3", output);

        // Verify output from Method3 (Task)
        Assert.Contains("Method3 (Task) is executing: 1", output);
        Assert.Contains("Method3 (Task) is executing: 2", output);
        Assert.Contains("Method3 (Task) is executing: 3", output);
    }

    /// <summary>
    /// Tests the private Method1 directly via reflection to verify iteration and console output.
    /// </summary>
    [Fact]
    public void Method1_PrivateMethod_ExecutesAndOutputsIterations()
    {
        var multiThreading = new MultiThreading();
        var method1Info = typeof(MultiThreading).GetMethod("Method1", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.NotNull(method1Info);

        var output = CaptureConsoleOutput(() =>
        {
            method1Info.Invoke(multiThreading, null);
        });

        Assert.Contains("Method1 (Thread Class) is executing: 1", output);
        Assert.Contains("Method1 (Thread Class) is executing: 2", output);
        Assert.Contains("Method1 (Thread Class) is executing: 3", output);
    }

    /// <summary>
    /// Tests the private Method2 directly via reflection with null state (WaitCallback signature).
    /// </summary>
    [Fact]
    public void Method2_PrivateMethod_WithNullState_ExecutesAndOutputsIterations()
    {
        var multiThreading = new MultiThreading();
        var method2Info = typeof(MultiThreading).GetMethod("Method2", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.NotNull(method2Info);

        var output = CaptureConsoleOutput(() =>
        {
            method2Info.Invoke(multiThreading, new object?[] { null });
        });

        Assert.Contains("Method2 (ThreadPool) is executing: 1", output);
        Assert.Contains("Method2 (ThreadPool) is executing: 2", output);
        Assert.Contains("Method2 (ThreadPool) is executing: 3", output);
    }

    /// <summary>
    /// Tests the private Method2 directly via reflection with a non-null state object.
    /// </summary>
    [Fact]
    public void Method2_PrivateMethod_WithCustomState_ExecutesAndOutputsIterations()
    {
        var multiThreading = new MultiThreading();
        var method2Info = typeof(MultiThreading).GetMethod("Method2", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.NotNull(method2Info);

        var output = CaptureConsoleOutput(() =>
        {
            method2Info.Invoke(multiThreading, new object?[] { "customState" });
        });

        Assert.Contains("Method2 (ThreadPool) is executing: 1", output);
        Assert.Contains("Method2 (ThreadPool) is executing: 2", output);
        Assert.Contains("Method2 (ThreadPool) is executing: 3", output);
    }

    /// <summary>
    /// Tests the private Method3 directly via reflection to verify iteration and console output.
    /// </summary>
    [Fact]
    public void Method3_PrivateMethod_ExecutesAndOutputsIterations()
    {
        var multiThreading = new MultiThreading();
        var method3Info = typeof(MultiThreading).GetMethod("Method3", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.NotNull(method3Info);

        var output = CaptureConsoleOutput(() =>
        {
            method3Info.Invoke(multiThreading, null);
        });

        Assert.Contains("Method3 (Task) is executing: 1", output);
        Assert.Contains("Method3 (Task) is executing: 2", output);
        Assert.Contains("Method3 (Task) is executing: 3", output);
    }

    /// <summary>
    /// Tests that RunDemo can be invoked multiple times sequentially without side effects.
    /// </summary>
    [Fact]
    public void RunDemo_CanBeExecutedMultipleTimes_Sequentially()
    {
        var multiThreading = new MultiThreading();

        var exception1 = Record.Exception(() => multiThreading.RunDemo());
        var exception2 = Record.Exception(() => multiThreading.RunDemo());

        Assert.Null(exception1);
        Assert.Null(exception2);
    }
}
