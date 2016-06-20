using NLog.Common;
using System;
using System.Collections.Generic;

namespace NLog.Targets.Syslog.Policies
{
    internal class SplitOnNewLinePolicy : IBasicPolicy<string, IEnumerable<string>>
    {
        private readonly Enforcement enforcement;
        private static readonly char[] LineSeps = { '\r', '\n' };

        public SplitOnNewLinePolicy(Enforcement enforcement)
        {
            this.enforcement = enforcement;
        }

        public bool IsApplicable()
        {
            return enforcement.SplitOnNewLine;
        }

        public IEnumerable<string> Apply(string s)
        {
            InternalLogger.Trace($"Splitting on new line {s}");
            return s.Split(LineSeps, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}