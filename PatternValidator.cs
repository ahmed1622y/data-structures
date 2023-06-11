using MyStack;
namespace PatternValidate
{
    public class PatternValidator
    {
        private MyStack<char> stack = new MyStack<char>();
        private string Pattern;
        public string pattern
        {
            get
            {
                return string.IsNullOrEmpty(this.Pattern) ? "" : this.Pattern;
            }
            set
            {
                this.Pattern = patternize(value);
            }
        }
        public PatternValidator()
        {
        }
        public PatternValidator(string pattern)
        {
            this.pattern = patternize(pattern);
        }
        public Boolean validate()
        {
            Boolean valid = false;
            if (pattern == String.Empty) return valid;
            foreach (char item in pattern)
            {
                if ("({[<".Contains(item))
                {
                    stack.push(item);
                }
                else 
                {
                    if (stack.isEmpty())
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        if (rightElement(stack.peek(), item))
                        {
                            stack.pop();
                            valid = true;
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }
            }
            if (!stack.isEmpty()) valid = false;
            return valid;
        }
        private string patternize(string phrase)
        {
            string patterized = "";
            foreach (char item in phrase)
            {
                if ("<>{}[]()".Contains(item))
                {
                    patterized += item;
                }
            }
            return patterized;
        }
        private Boolean rightElement(char left, char right)
        {
            Dictionary<char, char> sympolsPair = new Dictionary<char, char>()
            {
                ['('] = ')',
                ['{'] = '}',
                ['['] = ']',
                ['<'] = '>'
            };
            return sympolsPair[left] == right;
        }
    }
}
