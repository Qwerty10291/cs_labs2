namespace cs_labs.lab5;
using System;

class Task
{
    int MyMax(int a, int b) { return (a > b) ? a : b; }
    void Revers(ref int a, ref int b) { int c = a; a = b; b = c; }
    bool Fact(int a)
    {
        try
        {
            while (a > 0)
            {
                a *= (a - 1);
                a--;
            }
            checked
            {
                return true;
            }
        }
        catch (OverflowException e)
        {
            return false;
        }
    }

    int Fact1(int a)
    {
        if (a == 0)
        {
            return 1;
        }
        if (a > 1)
        {
            return a * Fact1(a - 1);
        }
        else { return a; }
    }
    int NOD(int a, int b)
    {
        if (a < b) { Revers(ref a, ref b); }
        if (a % b == 0)
        {
            return b;
        }
        else { return NOD(b, a % b); }
    }
    int Fib(int a)
    {
        if (a == 1 || a == 2) { return 1; }
        else { return Fib(a - 1) + Fib(a - 2); }
    }
}
