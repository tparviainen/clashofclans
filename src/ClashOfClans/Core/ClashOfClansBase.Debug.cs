using System;
using System.Diagnostics;
using System.Globalization;

namespace ClashOfClans.Core
{
    internal partial class ClashOfClansBase
    {
        [Conditional("DEBUG")]
        private void LogResponse(string uri, string response, string content)
        {
            Trace.WriteLine($"Date: {DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture)}");
            Trace.WriteLine($"API: {GetType().Name}, Uri: /{uri}");
            Trace.WriteLine(response);
            Trace.WriteLine($"Content: {content}");
            Trace.WriteLine(string.Empty);
        }
    }
}
