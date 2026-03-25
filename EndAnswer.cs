using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Tests
{
    internal class EndAnswer
    {
        string type;
        int Single;
        List<int> Multi;
        string SentenceOrCompare;
        List<string> Insert;

        public EndAnswer(int answer)
        {
            type = "Single";
            Single = answer;
        }

        public EndAnswer(List<int> answer)
        {
            type = "Multi";
            Multi = answer;
        }

        public EndAnswer(string answer)
        {
            type = "Sentence";
            SentenceOrCompare = answer;
        }

        public EndAnswer(List<string> answer)
        {
            type = "Insert";
            Insert = answer;
        }

        public object GetResult()
        {
            switch (type)
            {
                case "Single": return Single;
                case "Multi": return Multi;
                case "Sentence":
                case "Compare": return SentenceOrCompare;
                case "Insert": return Insert;
                default: return null;
            }
        }
    }
}
