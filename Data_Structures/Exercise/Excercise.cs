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
            foreach(char c in str.ToCharArray())
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
    }
}
