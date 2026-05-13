#ifndef MYSTRING_H
#define MYSTRING_H
#include <string>

class MyString {
private:
    std::string value;
public:
    MyString(std::string v);
    std::string getValue() const;
    int getLength() const;
    void toUpper();
};
#endif