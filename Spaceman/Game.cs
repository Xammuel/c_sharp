using System;

namespace Spaceman
{
    class Game
    {
        private string codeWord;
        private string currentWord;
        private int maxGuess;
        private int wrongGuess;
        private string[] wordBank = new string[] {"Martian", "Space", "Alien", "Flying"};

        Ufo ufo = new Ufo();
        
        public Game()
        {
            Random rand = new Random();
            codeWord = wordBank[rand.Next(wordBank.Length+1)];
            maxGuess = 5;
            wrongGuess = 0;
            for (int i = 0; i < codeWord.Length; i++)
            {
                currentWord += "_";
            }
        }

        public void Greet()
        {
            Console.WriteLine("==============\nUFO: The Game\n==============");
            Console.WriteLine("Instructions: Save your friend from alien abduction by guessing the letters in the codeword.");
        }

        public bool DidWin()
        {
            return codeWord.Equals(currentWord);
        }

        public bool DidLose()
        {
            return wrongGuess >= maxGuess;
        }

        public void Display()
        {
            Console.WriteLine(ufo.Stringify());
            Console.WriteLine($"Current Word: {currentWord}");
            Console.WriteLine($"\nGuesses remaining: {maxGuess-wrongGuess}");
        }
        
        public void Ask()
        {
            Console.Write("Guess a letter: ");
            string input = Console.ReadLine();
            while(input.Length != 1)
            {
                Console.Write("Only single characters are accepted!\nEnter another letter: ");
                input = Console.ReadLine();
            }
            char guess = char.Parse(input);
            if(codeWord.Contains(guess))
            {
                Console.WriteLine($"Correct! The word contains the letter {guess}.");
                while(codeWord.Contains(guess))
                {
                    int guessPos = codeWord.IndexOf(guess);
                    codeWord = codeWord.Remove(guessPos, 1).Insert(guessPos, " ");
                    currentWord = currentWord.Remove(guessPos, 1).Insert(guessPos, input);
                }
            } else {
                wrongGuess++;
                Console.WriteLine($"Wrong! The word does not contain the letter {guess}.\nYou have {maxGuess-wrongGuess} guesses remaining.");
                ufo.AddPart();
            }
        }
    }
}