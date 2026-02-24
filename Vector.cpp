#include "Vector.h"
#include <cmath>

// Конструктор без параметрів
Vector::Vector()
{
    r = 0;
    angle = 0;
}

// Конструктор з параметрами
Vector::Vector(double r, double angle)
{
    this->r = r;
    this->angle = angle;
}

// Конструктор копіювання
Vector::Vector(const Vector& other)
{
    r = other.r;
    angle = other.angle;
}

// Деструктор
Vector::~Vector()
{
}

// Методи доступу
double Vector::getR() const
{
    return r;
}

double Vector::getAngle() const
{
    return angle;
}

// Обчислення X
double Vector::getX() const
{
    return r * cos(angle);
}

// Обчислення Y
double Vector::getY() const
{
    return r * sin(angle);
}