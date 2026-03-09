#include "Segment.h"
#include <cmath>

Segment::Segment()
{
    x1 = 0;
    y1 = 0;
    x2 = 0;
    y2 = 0;
}

Segment::Segment(double a, double b, double c, double d)
{
    x1 = a;
    y1 = b;
    x2 = c;
    y2 = d;
}

Segment::Segment(const Segment& s)
{
    x1 = s.x1;
    y1 = s.y1;
    x2 = s.x2;
    y2 = s.y2;
}

double Segment::length() const
{
    return sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
}

Segment Segment::operator*(double k)
{
    return Segment(x1 * k, y1 * k, x2 * k, y2 * k);
}

Segment Segment::operator+(const Segment& other)
{
    return Segment(x1 + other.x1,
        y1 + other.y1,
        x2 + other.x2,
        y2 + other.y2);
}

void Segment::print() const
{
    cout << "Start: (" << x1 << "," << y1 << ")" << endl;
    cout << "End: (" << x2 << "," << y2 << ")" << endl;
    cout << "Length: " << length() << endl;
}