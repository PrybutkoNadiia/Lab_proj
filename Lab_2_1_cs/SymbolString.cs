using System;

namespace StringLibrary
{
    public class SymbolString : BaseString
    {
        public SymbolString() : base() { }

        public SymbolString(string val) : base(val) { }

        public SymbolString(SymbolString other) : base(other) { }

        public void ReplaceChar(char oldChar, char newChar)
        {
            value = value.Replace(oldChar, newChar);
        }
    }
}