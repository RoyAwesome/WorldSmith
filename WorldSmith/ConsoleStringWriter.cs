using System.IO;
using System.Text;
using WorldSmith.Panels;

namespace WorldSmith
{
    class ConsoleStringWriter : TextWriter
    {
        ConsoleForm _output = null;
        public ConsoleStringWriter(ConsoleForm output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);

            _output.UpdateConsole(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
