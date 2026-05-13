#include <iostream>
#include "Text.h"

int main() {
    Text t;
    t.addLine("C++ Code");
    t.addLine("Lab");

    t.toUpperCase();
    t.removeByLength(3);

    // Перевірте, щоб назва методу була getLines()
    for (const auto& line : t.getLines()) {
        std::cout << line.getValue() << std::endl;
    }

    return 0;
}