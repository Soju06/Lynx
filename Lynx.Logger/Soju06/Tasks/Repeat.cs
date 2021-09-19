namespace Soju06.Tasks {
    internal static class Repeat {
        public static Task Interval(TimeSpan pollInterval, Action action, CancellationToken token) =>
            Task.Factory.StartNew(() => {
                while (true) {
                    if (token.WaitHandle.WaitOne(pollInterval)) break;
                    action.Invoke();
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }
}
