namespace InterviewPrepration.Concepts;

internal sealed class SingletonPattern
{
    private static SingletonPattern? _singletonPattern = null;

    private SingletonPattern()
    {

    }

    public static SingletonPattern GetObject()
    {
        if (_singletonPattern == null)
        {
            _singletonPattern = new SingletonPattern();
        }
        return _singletonPattern;
    }
}
