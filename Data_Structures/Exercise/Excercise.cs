using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Exercise
{
    public class Excercise
    {
        private readonly List<KeyValuePair<char, char>> characterPairs = new List<KeyValuePair<char, char>>()
        {
                new KeyValuePair<char, char>('(',')'),
                new KeyValuePair<char, char>('<','>'),
                new KeyValuePair<char, char>('[',']'),
                new KeyValuePair<char, char>('{','}')
        };
        private List<char> leftBrackets = new List<char>()
        {
            '(','<','[','{'
        };
        private List<char> rightBrackets = new List<char>()
        {
            ')','>',']','}'
        };

        #region Reversing string stack

        public string ReverseUsingStack(string src)
        {
            if (src == null)
                throw new ArgumentNullException();

            var stack = new Stack<char>();
            foreach (char character in src.ToCharArray())
            {
                stack.Push(character);
            }
            var dest = new StringBuilder();
            while (stack.Count > 0)
            {
                dest.Append(stack.Pop());
            }
            return dest.ToString();
        }

        #endregion

        #region Find Balanced Expression
        public bool IsBalancedExpression(string str)
        {
            var stack = new Stack<char>();
            var src = str.ToCharArray();
            foreach (char c in src)
            {
                var pair = characterPairs.Find(x => x.Key == c || x.Value == c);
                if (pair.Key != '\0')
                {
                    if (pair.Key == c)
                    {
                        stack.Push(c);
                    }
                    else if (pair.Value == c)
                    {
                        if (stack.Count == 0) return false;
                        if (pair.Key != stack.Pop())
                        {
                            return false;
                        }
                    }
                }
            }
            return stack.Count == 0;
        }

        //Shorter version of the same with basic data structures.
        public bool IsBalancedExpression2(string str)
        {
            var stack = new Stack<char>();
            foreach (char c in str.ToCharArray())
            {
                if (IsLeftBrackets(c))
                {
                    stack.Push(c);
                }
                if (IsRightBrackets(c))
                {
                    if (stack.Count == 0 || !BracketsMatch(stack.Pop(), c)) return false;
                }
            }
            return stack.Count == 0;
        }

        private bool IsLeftBrackets(char c)
        {
            return leftBrackets.Contains(c);
        }

        private bool IsRightBrackets(char c)
        {
            return rightBrackets.Contains(c);
        }

        private bool BracketsMatch(char left, char right)
        {
            return leftBrackets.IndexOf(left) == rightBrackets.IndexOf(right);
        }

        #endregion

        #region reverse queue using stack

        public Queue<T> ReverseQueue<T>(Queue<T> queue)
        {
            var stack = new Stack<T>();
            while (queue.Count != 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        #endregion

        #region Find first non repeating character in string

        public char FindNonRepeatingCharacter(string str)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (char c in str.ToCharArray())
            {
                if (!dictionary.ContainsKey(c))
                    dictionary.Add(c, 1);
                else
                    dictionary[c] = dictionary[c] + 1;
            }
            foreach (var pair in dictionary)
            {
                if (pair.Value == 1)
                    return pair.Key;
            }
            return default(char);
        }

        #endregion

        #region Find first repeating character in string

        public char FindRepeatingCharacter(string str)
        {
            var set = new HashSet<char>();
            foreach (char c in str.ToCharArray())
            {
                if (set.Contains(c))
                    return c;
                set.Add(c);
            }
            return default(char);
        }

        #endregion
    }
}
