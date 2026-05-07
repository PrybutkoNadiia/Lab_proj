#include <iostream>
#include "SymbolString.h"

using namespace std;

int main()
{
    SymbolString str("hello world");

    cout << "Line: " << str.getValue() << endl;
    cout << "Length: " << str.getLength() << endl;

    str.replaceChar('o', 'a');

    cout << "After replacement: " << str.getValue() << endl;

    return 0;
}