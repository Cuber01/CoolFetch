using System.Collections.Generic;
using System.Text;

namespace CoolFetch
{
    /*
    Parser for noname (?) file format found commonly in the GNU/Linux system and many more.
    This parser supports only a part of it, see the example.
    
    Example:
    
    KEY="VALUE"
    ANOTHER_KEY=VALUE
    
    (Do note that both "VALUE" and VALUE are recognised as strings)
    */
    
    public class KeyValueParser
    {
        public static Dictionary<string, string> parseLines(string[] lines)
        {
            
            Dictionary<string, string> keysAndValues = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                bool gettingKey = true;
                
                StringBuilder key = new StringBuilder();
                StringBuilder value = new StringBuilder();
                
                foreach (var c in line)
                {
                    if (c == '=') gettingKey = false;

                    if (gettingKey)
                    {
                        key.Append(c);
                    }
                    else
                    {
                        value.Append(c);
                    }
                    
                }
                
                keysAndValues.Add(key.ToString(), value.ToString());
                
            }

            return keysAndValues;
            
        }
        
    }
}