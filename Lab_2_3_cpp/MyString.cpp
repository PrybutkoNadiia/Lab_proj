#include "MyString.h"
#include <string>
#include <cctype>

// Конструктор
MyString::MyString(std::string v) : value(v) {}

// Отримання рядка
std::string MyString::getValue() const {
    return value;
}

// Отримання довжини
int MyString::getLength() const {
    return (int)value.length();
}

// Переведення всього рядка у верхній регістр
void MyString::toUpper() {
    for (auto& c : value) {
        c = (char)toupper((unsigned char)c);
    }
}