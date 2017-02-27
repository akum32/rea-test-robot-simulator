using System.Collections.Generic;

namespace ToyRobot.App.Tests
{
    public class TestCommandReader : ICommandReader
    {
        private readonly IEnumerator<string> _enumerator;

        public TestCommandReader(params string[] commands)
        {
            _enumerator = new List<string>(commands).GetEnumerator();
        }

        public string NextCommand()
        {
            var hasMore = _enumerator.MoveNext();
            return hasMore ? _enumerator.Current : null;
        }
    }
}
