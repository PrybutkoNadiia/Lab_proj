#include "Segment.h"

int main()
{
    Segment L1;
    Segment L2(1, 2, 3, 4);
    Segment L3(L2);

    L3 = L3 * 2;

    L1 = L3 + L2;

    cout << "L1:" << endl;
    L1.print();

    cout << endl;

    cout << "L2:" << endl;
    L2.print();

    cout << endl;

    cout << "L3:" << endl;
    L3.print();

    return 0;
}