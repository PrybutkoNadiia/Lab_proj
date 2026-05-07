using System;

namespace StringLibrary
{
    public class BaseString
    {
        protected string value;

        public BaseString()
        {
            value = "";
        }

        public BaseString(string val)
        {
            value = val;
        }

        public BaseString(BaseString other)
        {
            value = other.value;
        }

        public string GetValue()
        {
            return value;
        }

        public int GetLength()
        {
            return value.Length;
        }
    }
}
