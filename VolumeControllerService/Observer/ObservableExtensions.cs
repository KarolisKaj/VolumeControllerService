namespace VolumeControllerService.Observer
{
    using System;
    public static class ObservableExtensions
    {
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext)
        {
            return source.Subscribe(new Observer<T>(onNext));
        }
    }
}
