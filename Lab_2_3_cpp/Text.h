#ifndef TEXT_H
#define TEXT_H

#include <vector>
#include <string>
#include "MyString.h"

// Інтерфейс
class ICaseManager {
public:
    virtual void toUpperCase() = 0;
    virtual ~ICaseManager() {}
};

// Клас-контейнер
class Text : public ICaseManager {
private:
    std::vector<MyString> lines; // Вектор об'єктів іншого класу
public:
    const std::vector<MyString>& getLines() const { return lines; }
    void addLine(std::string line);
    void clear();
    void toUpperCase() override;
    int countOccurrences(std::string searchStr);
    void removeByLength(int length);
    void display();
};

#endif