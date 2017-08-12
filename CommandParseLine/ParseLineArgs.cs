using System;
using System.Linq;

namespace CommandParseLine
{
    public class ParseLineArgs
    {
        public void ParseArgs(string[] args)
        {
            var test = args.Select(x => x.Split(':')).ToDictionary(x => x[0], x => x[1]);


        }
    }
}
