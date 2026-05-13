#include "Text.h"
#include <string>
#include <vector>
#include <iostream>

// Додавання об'єкта MyString до вектора
void Text::addLine(std::string line) {
    lines.push_back(MyString(line));
}

// Очищення контейнера
void Text::clear() {
    lines.clear();
}

// Реалізація інтерфейсу: проходимо по всіх об'єктах MyString
void Text::toUpperCase() {
    for (auto& line : lines) {
        line.toUpper();
    }
}

// Пошук підрядка
int Text::countOccurrences(std::string searchStr) {
    int count = 0;
    for (const auto& line : lines) {
        if (line.getValue().find(searchStr) != std::string::npos) {
            count++;
        }
    }
    return count;
}

// Видалення об'єктів за довжиною рядка
void Text::removeByLength(int length) {
    for (auto it = lines.begin(); it != lines.end(); ) {
        if (it->getLength() == length) {
            it = lines.erase(it);
        }
        else {
            ++it;
        }
    }
}

// Виведення (для перевірки)
void Text::display() {
    for (const auto& line : lines) {
        std::cout << line.getValue() << std::endl;
    }
}