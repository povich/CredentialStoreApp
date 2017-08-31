using System;

using log4net.Appender;

namespace InsyteDeployment.MainWindow.Logging
{
    public class ConsoleAppender : AppenderSkeleton
    {
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
           
            Console.WriteLine(loggingEvent.RenderedMessage);
        }
    }
}