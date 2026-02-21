#include "Vector.h"
#include <cmath>
#include <sstream>
#include <iomanip>

// Використовуємо число Пі з бібліотеки cmath або задаємо константу
const double PI = 3.14159265358979323846;

Vector::Vector(double l, double a) : length(l), angleInDegrees(a) {} // Ініціалізація довжини та кута в градусах

double Vector::calculateX() const { // Перетворення кута з градусів у радіани
    double radians = angleInDegrees * (PI / 180.0); 
    return length * std::cos(radians); 
}

double Vector::calculateY() const { // Перетворення кута з градусів у радіани
    double radians = angleInDegrees * (PI / 180.0);
    return length * std::sin(radians);
}

std::string Vector::getPolarData() const { // Формування рядка з інформацією про вектор
	std::stringstream ss; // Використовуємо stringstream для зручного форматування рядка
	ss << "Вектор: довжина = " << length << ", кут = " << angleInDegrees << " градусів"; // Форматування рядка з інформацією про вектор
	return ss.str(); // Повертаємо сформований рядок
}