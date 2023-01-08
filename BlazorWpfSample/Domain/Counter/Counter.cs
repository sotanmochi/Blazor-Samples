using System.Threading.Tasks;

namespace BlazorWpfSample.Domain
{
    public class Counter
    {
        public int CurrentCount => _count;

        private readonly int _asyncCountDelayMilliseconds;

        private int _count;

        public Counter(int defaultValue, int asyncCountDelayMilliseconds)
        {
            _count = defaultValue;
            _asyncCountDelayMilliseconds = asyncCountDelayMilliseconds;
        }

        public void Increment()
        {
            _count++;
        }

        public void Decrement()
        {
            _count--;
        }

        public async Task IncrementAsync()
        {
            await Task.Delay(_asyncCountDelayMilliseconds);
            _count++;
        }

        public async Task DecrementAsync()
        {
            await Task.Delay(_asyncCountDelayMilliseconds);
            _count--;
        }
    }
}