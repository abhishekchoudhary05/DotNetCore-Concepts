namespace InterviewPrepration.Concepts;

/// <summary>Demonstrates a lazily created singleton instance.</summary>
internal sealed class SingletonPattern
{
    private static SingletonPattern? _singletonPattern = null;

    private SingletonPattern()
    {

    }

    /// <summary>Returns the shared instance, creating it on the first call.</summary>
    public static SingletonPattern GetObject()
    {
        if (_singletonPattern == null)
        {
            _singletonPattern = new SingletonPattern();
        }
        return _singletonPattern;
    }
}
