using System.Diagnostics;

namespace TestAutomation.Tests.PageObjectPattern.Helpers
{
    static class WaitHelper
    {
        //Custom method to check if the condition given is true for a given time
        public static void WaitForCondition(Func<bool> condition, int msTimeout = 4000)
        {
            Stopwatch stopWatch = new Stopwatch();
            Exception? ex;

            do
            {
                try
                {
                    ex = null;
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ex = e;
                }

            } while (stopWatch.ElapsedMilliseconds < msTimeout);

            stopWatch.Stop();

            if (ex != null)
            {
                throw new TimeoutException("Error executing the condition.", ex);
            }

            throw new TimeoutException("Error the condition was false");

        }
    }
}
