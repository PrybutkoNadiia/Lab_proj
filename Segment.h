#ifndef SEGMENT_H
#define SEGMENT_H

#include <iostream>
using namespace std;

class Segment
{
private:
    double x1, y1, x2, y2;

public:
    Segment();
    Segment(double a, double b, double c, double d);
    Segment(const Segment& s);

    double length() const;

    Segment operator*(double k);
    Segment operator+(const Segment& other);

    void print() const;
};

#endif#pragma once
