using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchSides
{
    class ScoringWord
    {
        public ScoringWord(string word, int score)
        {
            this.word = word;
            this.score = score;
        }

        public string word { get; set; }
        public int score { get; set; }
    }
}
