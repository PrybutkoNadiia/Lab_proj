#include <iostream>
#include <iomanip>
#include "Vector.h"

int main() {
    // Встановлюємо підтримку української мови в консолі
    setlocale(LC_ALL, "Ukrainian");

    // Створення об'єкта класу
    Vector myVector(10.0, 45.0);

    // Виведення даних об'єкта
    std::cout << myVector.getPolarData() << std::endl;

    // Обчислення та виведення координат
    std::cout << std::fixed << std::setprecision(2);
    std::cout << "Координата X кінця вектора: " << myVector.calculateX() << std::endl;
    std::cout << "Координата Y кінця вектора: " << myVector.calculateY() << std::endl;

    return 0;
}
