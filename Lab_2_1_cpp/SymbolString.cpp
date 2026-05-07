#include "SymbolString.h"

SymbolString::SymbolString() : BaseString() {}

SymbolString::SymbolString(std::string val) : BaseString(val) {}

SymbolString::SymbolString(const SymbolString& other) : BaseString(other) {}

void SymbolString::replaceChar(char oldChar, char newChar)
{
    for (int i = 0; i < value.length(); i++)
    {
        if (value[i] == oldChar)
            value[i] = newChar;
    }
}