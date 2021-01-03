using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms.String_Manipulation_Algorithms
{
    class StringUtils
    {
        public int CountVowels(string input)
        {
            if (input == null)
                return 0;

            var vowels = "AEIOU";
            var count = 0;
            foreach (var c in input.ToUpper())
                if (vowels.IndexOf(c) != -1)
                    count++;

            return count;
        }
        public string ReverseString(string input)
        {
            if (input == null)
                return string.Empty;

            var result = new StringBuilder();

            for (var i = input.Length; i > 0; i--)
                result.Append(input[i - 1]);

            return result.ToString();
        }

        public string ReverseWords(string input)
        {
            if (input == null)
                return string.Empty;

            var reversedList = new List<string>();
            reversedList.AddRange(input.Trim().Split(' '));
            return string.Join(' ', reversedList);

            //var wordsList = input.Split(' ');

            //var result = new StringBuilder();
            //for(var i = wordsList.Length; i > 0; i--)
            //{
            //    result.Append(wordsList[i - 1] + " ");
            //}

            //return result.ToString().Trim();
        }

        public bool CheckRotation(string source, string target)
        {
            if (source == null || target == null)
                return false;

            return (source.Length == target.Length) && (source + source).Contains(target);
        }

        public string RemoveDuplicates(string input)
        {
            if (input == null)
                return string.Empty;

            var result = new StringBuilder();
            var seenChars = new HashSet<char>();
            foreach (var i in input)
                if (!seenChars.Contains(i))
                {
                    result.Append(i);
                    seenChars.Add(i);
                }

            return result.ToString();
        }

        public char MostRepeatedCharacter(string input)
        {
            if (input == null || input == string.Empty)
                return default(char);

            const int ASCII_SIZE = 256;
            var charArray = new int[256];

            foreach (var i in input)
            {
                charArray[i]++;
            }

            var max = 0;
            var character = ' ';

            for (var i = 0; i < ASCII_SIZE; i++)
            {
                if (charArray[i] > max)
                {
                    max = charArray[i];
                    character = (char)i;
                }
            }
            return character;
            //var charDictionary = new Dictionary<char, int>();
            //foreach(var c in input)
            //{
            //    if (charDictionary.ContainsKey(c))
            //        charDictionary[c]++;
            //    else
            //        charDictionary.Add(c, 1);
            //}
            //var result = charDictionary.OrderByDescending(x => x.Value);
            //return result.First().Key;
        }

        public string CapitalizeSentence(string input)
        {
            if (input == null || input.Trim() == string.Empty)
                return string.Empty;
            input = Regex.Replace(input.Trim(), " +", " ");
            var wordsList = input.Split(' ');
            for (var i = 0; i < wordsList.Length; i++)
            {
                if (wordsList[i] != string.Empty)
                    wordsList[i] = (wordsList[i].Substring(0, 1).ToUpper() + wordsList[i].Substring(1).ToLower()).Trim();
            }
            return string.Join(' ', wordsList);
        }

        // Using Dictionary
        public bool CheckAnagramFirstAttempt(string source, string target)
        {
            if (source.Length != target.Length || source == null || target == null)
                return false;

            var sourceDictionary = new Dictionary<char, int>();
            var targetDictionary = new Dictionary<char, int>();
            for (var i = 0; i < source.Length; i++)
            {
                if (sourceDictionary.ContainsKey(source[i]))
                {
                    sourceDictionary[source[i]]++;
                }
                else
                {
                    sourceDictionary.Add(source[i], 1);
                }
                if (targetDictionary.ContainsKey(target[i]))
                {
                    targetDictionary[target[i]]++;
                }
                else
                {
                    targetDictionary.Add(target[i], 1);
                }
            }
            foreach (var pair in sourceDictionary)
            {
                if (targetDictionary.ContainsKey(pair.Key) && targetDictionary[pair.Key] == pair.Value)
                    continue;
                return false;
            }
            return true;
        }

        // Using Sorting
        public bool CheckAnagramSorting(string source, string target)
        {
            if (source.Length != target.Length || source == null || target == null)
                return false;

            var sourceArray = source.ToCharArray().OrderBy(x => x);
            var targetArray = source.ToCharArray().OrderBy(x => x);

            return sourceArray.SequenceEqual(targetArray);
        }

        public bool CheckAnagramHistogramming(string source, string target)
        {
            const int ALPHABET_SIZE = 26;
            var sourceArray = new int[ALPHABET_SIZE];

            source = source.ToLower();
            for (var i = 0; i < source.Length; i++)
                sourceArray[source[i] - 'a']++;

            target = target.ToLower();
            for (var i = 0; i < target.Length; i++)
            {
                var characterIndex = target[i] - 'a';
                if (sourceArray[characterIndex] == 0)
                    return false;

                sourceArray[characterIndex]--;
            }
            return true;
        }

        public bool CheckPalindrom(string source)
        {
            var left = 0;
            var right = source.Length - 1;

            while (left < right)
                if (source[left++] != source[right--])
                    return false;
            
            return true;
        }
    }
}
