﻿namespace VolumeControllerService.Observer
{
    using System;
    public class Observer<T> : IObserver<T>, IDisposable
    {
        private Action<T> _onNext;
        public Observer(Action<T> onNext)
        {
            _onNext = onNext;
        }

        public void OnCompleted()
        {
            Dispose();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Observer died :(((");
            Console.WriteLine(error.StackTrace);
        }

        public void OnNext(T value)
        {
            _onNext(value);
        }

        public void Dispose()
        {
        }
    }
}
