using System.IO;
using System.Text;
using WorldSmith.Panels;
using System.Collections.Generic;
using WorldSmith.Utils;

namespace WorldSmith
{
    class ConsoleStringWriter : TextWriter
    {
        IConsoleNotify _output;
        public IConsoleNotify Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                if (_output != null)
                {
                    _output.UpdateConsole(BackupBuilder.ToString());
                }
            }
        }
        StringBuilder BackupBuilder = new StringBuilder();
        
                 
        public ConsoleStringWriter()
        {
            
        }

        public override void Write(char value)
        {
            base.Write(value);
            if(Output == null)
            {
                BackupBuilder.Append(value);
            }
            else
            {
                Output.UpdateConsole(value.ToString()); // When character data is written, append it to the text box.
            }
           
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
