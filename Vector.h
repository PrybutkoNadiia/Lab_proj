#ifndef VECTOR_H
#define VECTOR_H

class Vector // клас для представлення вектора у полярних координатах
{
private:
    double r;      // довжина
    double angle;  // кут у радіанах

public:
    // Конструктори
    Vector();                          // без параметрів
    Vector(double r, double angle);    // з параметрами
    Vector(const Vector& other);       // конструктор копіювання

    // Деструктор
    ~Vector();

    // Методи доступу
    double getR() const;
    double getAngle() const;

    // Методи обчислення координат
    double getX() const;
    double getY() const;
};

#endif