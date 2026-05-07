#ifndef SYMBOLSTRING_H
#define SYMBOLSTRING_H

#include "BaseString.h"

class SymbolString : public BaseString
{
public:
    SymbolString();
    SymbolString(std::string val);
    SymbolString(const SymbolString& other);

    void replaceChar(char oldChar, char newChar);
};

#endif