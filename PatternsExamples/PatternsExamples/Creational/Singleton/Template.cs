using System;

namespace PatternsExamples.Creational.Singleton
{
    /// <summary>
    /// Thread unsafe singleton
    /// </summary>
    class SimpleSingleton
    {
        private static SimpleSingleton _instance;

        private SimpleSingleton()
        {
            
        }

        public static SimpleSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SimpleSingleton();
                return _instance;
            }
        }
    }

    /// <summary>
    /// Thread safe singleton without lock
    /// </summary>
    public class ThreadSafeSingletonWithoutLock
    {
        private static readonly ThreadSafeSingletonWithoutLock _instance = new ThreadSafeSingletonWithoutLock();

        public string Name { get; }

        private ThreadSafeSingletonWithoutLock()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static ThreadSafeSingletonWithoutLock Instance => _instance;
    }

    /// <summary>
    /// Thread safe singleton with lock
    /// </summary>
    class ThreadSafeSingletonWithLock
    {
        private static ThreadSafeSingletonWithLock _instance;
        private static object lockObject = new object();

        private ThreadSafeSingletonWithLock()
        {
        }

        public static ThreadSafeSingletonWithLock Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                            _instance = new ThreadSafeSingletonWithLock();
                    }
                }

                return _instance;
            }
        }
    }

    /// <summary>
    /// Thread safe singleton with lazy load
    /// </summary>
    class LazyLockSingleton
    {
        public string Name { get; }

        private LazyLockSingleton()
        {
            Name = Guid.NewGuid().ToString();
        }

        private class Nested
        {
            internal static readonly LazyLockSingleton instance = new LazyLockSingleton();
        }

        public static LazyLockSingleton Instance => Nested.instance;
    }

    /// <summary>
    /// Another singleton realization with lazy load
    /// </summary>
    public class LazyLockSingleton2
    {
        private static readonly Lazy<LazyLockSingleton2> LazyInstance = new Lazy<LazyLockSingleton2>(() => new LazyLockSingleton2());

        public string Name { get; }

        private LazyLockSingleton2()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static LazyLockSingleton2 Instance => LazyInstance.Value;
    }
}
