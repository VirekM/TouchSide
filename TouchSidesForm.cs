using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchSides
{
    public partial class TouchSidesForm : Form
    {
        public TouchSidesForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            List<WordCounter> words;




            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    FileLocationTextBox.Text = filePath;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            //ResultTextBox.Text = fileContent;
            words=SplitWords(fileContent);
            MostFreqWord(words);
            MostSevenLetterWord(words);
            HighestScoringWord(words);

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private List<WordCounter> SplitWords(string file)
        {
            String[] wordsArray = file.Split(' ',',','.','!','-',':','?', '\"', '\r', '\n','[',']','(',')','`', '“', '”', '\\', '—',';', '’'
                ,'~','@','#','$','%','^','&','*','+','=');
            List<WordCounter> wordCounters = new List<WordCounter>();
            foreach (string word in wordsArray)
            {
   
                WordCounter foundWord = wordCounters.Find(x => x.word == word);
                //if empty , add word to list otherwise add frequency of word
                if (foundWord == null)
                {
                    wordCounters.Add(new WordCounter(word,1));

                }
                else
                {
                    foundWord.frequency++;
                }
            }

            return wordCounters;
        }

        private void MostFreqWord(List<WordCounter> wordCounters)
        {
            foreach (WordCounter w in wordCounters.OrderByDescending(x => x.frequency))
            {
                //Console.WriteLine(w.word + ":" + w.frequency);
            }
            int freq = wordCounters.Max(f => f.frequency);
            string highestword = wordCounters.Find(x => x.frequency == freq).word;
            Console.WriteLine("Most frequent word: {0} occurred {1} times", highestword, freq);
            ResultTextBox.Text = "Most frequent word:" + highestword + " occurred " + freq + " times";
        }

        private void MostSevenLetterWord(List<WordCounter> wordCounters)
        {
            List<WordCounter> sevenLetterWords = new List<WordCounter>();
            foreach (WordCounter w in wordCounters.OrderByDescending(x => x.frequency))
            {
                if(w.word.Count() == 7)
                {
                    //Console.WriteLine(w.word + ":" + w.frequency);
                    sevenLetterWords.Add(new WordCounter(w.word, w.frequency));
                }
            }
            if(sevenLetterWords.Count > 0)
            {
                int freq = sevenLetterWords.Max(f => f.frequency);
                string highestword = sevenLetterWords.Find(x => x.frequency == freq).word;
                Console.WriteLine("Most frequent 7-character word: {0} occurred {1} times", highestword, freq);
                ResultTextBox.AppendText("\nMost frequent 7-character word:" + highestword + " occurred " + freq + " times");
            }

        }

        private void HighestScoringWord(List<WordCounter> wordCounters)
        {
            Dictionary<string, int> wordScores = new Dictionary<string, int>()
            {
                {"A",1},{"B",3},{"C",3},{"D",2},{"E",1 },{"F",4 },{"G",2 },{"H",4 },{"I",1 },{"J",8 },{"K",5 },
                {"L",1 },{"M",3 },{"N",1 },{"O",1 },{"P",3 },{"Q",10 },{"R", 1},{"S",1 },{"T",1 },{"U",1 },
                {"V",4 },{"W",4 },{"X",8 },{"Y",4 },{"Z",10 }
            };
            List<ScoringWord> highScoringWord = new List<ScoringWord>();
            int highScore = 0;
            foreach (WordCounter w in wordCounters.OrderByDescending(x => x.frequency))
            {
                int wordScore = 0;
                Console.WriteLine("Word:"+w.word);
                foreach (char letter in w.word)
                {
                    Console.WriteLine("letter:"+ letter);
                    bool isAlphaBet = Regex.IsMatch(letter.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                    if (!isAlphaBet) 
                    {
                        wordScore = wordScore;
                    }
                    else
                    {
                        wordScore = wordScores[letter.ToString().ToUpper()] + wordScore;
                    }
                    
                    Console.WriteLine("wordScore:"+wordScore);
                }
                if (wordScore > highScore)
                {
                    highScore = wordScore;
                    highScoringWord.Add(new ScoringWord(w.word, highScore));
                }
            }

            foreach (ScoringWord s in highScoringWord.OrderByDescending(x => x.score))
            {
                Console.WriteLine(s.word + ":" + s.score);
            }
            int scoreforword = highScoringWord.Max(f => f.score);
            string highestword = highScoringWord.Find(x => x.score == scoreforword).word;
            Console.WriteLine("highest scoring word (according to the score table): {0} with a score of {1}", highestword, scoreforword);
            ResultTextBox.AppendText("\nhighest scoring word (according to the score table):" + highestword + " with a score of " + scoreforword);

        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
