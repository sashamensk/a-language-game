using System;
using System.Globalization;
using System.Text;

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay"
        /// </example>
        public static string TranslateToPigLatin(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentException($"{nameof(phrase)} Thrown if phrase is null or empty.");
            }

            string word;
            StringBuilder text = new StringBuilder(phrase);

            int startIndex = 0, endIndex = 0, n = 0;
            bool startIndexSet = false, endIndexSet = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '’')
                {
                    continue;
                }

                if (char.IsLetter(text[i]) && !startIndexSet)
                {
                    startIndex = i;
                    startIndexSet = true;
                }

                if (!char.IsLetter(text[i]) && startIndexSet)
                {
                    endIndex = i - 1;
                    endIndexSet = true;
                }
                else if (i == text.Length - 1)
                {
                    endIndex = i;
                    endIndexSet = true;
                }

                if (startIndexSet && endIndexSet)
                {
                    word = text.ToString(startIndex, endIndex - startIndex + 1);
                    n = word.Length;
                    word = WordToPigLatin(word);
                    text.Remove(startIndex, endIndex - startIndex + 1);
                    text.Insert(startIndex, word);
                    i += word.Length - n;
                    startIndexSet = false;
                    endIndexSet = false;
                }
            }

            string result = text.ToString();
            return result;
        }

        public static string WordToPigLatin(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"{nameof(word)} Thrown if phrase is null or empty.");
            }

            bool isUpper = char.IsUpper(word[0]);

            if (IsAVowel(word[0]))
            {
                word += "yay";
            }
            else
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (IsAVowel(word[i]))
                    {
                        word = word.Substring(i) + word.Substring(0, i) + "ay";
                        break;
                    }

                    if (i == word.Length - 1)
                    {
                        word = string.Concat(word, "ay");
                        break;
                    }
                }
            }

            if (isUpper)
            {
                word = word.ToLower(CultureInfo.CurrentCulture);
                word = CapitalToUppercase(word);
            }

            return word;
        }

        public static bool IsAVowel(char c)
        {
            return "aeiou".Contains(c, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string CapitalToUppercase(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            char[] arr = str.ToCharArray();
            arr[0] = char.ToUpper(arr[0], CultureInfo.CurrentCulture);
            return new string(arr);
        }
    }
}
