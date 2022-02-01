using System.Collections.Generic;
using System.Text;

namespace CoolFetch.Generic
{
    /*
    Parser for noname (?) file format found commonly in the GNU/Linux system and many more.
    This parser supports only a part of it, see the example.
    
    Example:
    
    ```
    KEY="VALUE"
    ANOTHER_KEY=VALUE
    ```
    
    (Do note that both "VALUE" and VALUE are recognised as strings)
    
    Or using : instead of =
    
    ```
    KEY:VALUE
    ANOTHER_KEY:ANOTHER_VALUE
    ```
    
    */
    
    public class KeyValueParser
    {
        public static Dictionary<string, string> parseLines(string[] lines, char separator)
        {
            
            Dictionary<string, string> keysAndValues = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                bool gettingKey = true;
                
                StringBuilder key = new StringBuilder();
                StringBuilder value = new StringBuilder();
                
                foreach (var c in line)
                {
                    if (c == separator)
                    {
                        gettingKey = false;
                        continue;
                    }
                    
                    if (gettingKey)
                    {
                        key.Append(c);
                    }
                    else
                    {
                        // Ignore redundant spaces at the start of the value.
                        if (value.Length == 0 && c == ' ') continue;
                        
                        value.Append(c);
                    }
                    
                }

                // Ignore repeating keys.
                if (!keysAndValues.ContainsKey(key.ToString()))
                {
                    keysAndValues.Add(key.ToString(), value.ToString());
                }
                
            }

            return keysAndValues;
            
        }
        
    }
}