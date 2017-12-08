#ifndef AVION_H
#define AVION_H
#include "qstring.h"
#include "iostream"
#include "stdio.h"
#include "stdlib.h"

using namespace std;

class Avion
{
private:
    int id;
    int turnos;//pequeño 1 mediano 2 grande 3
    int mantenimiento;//dependiendo de ltipo
    int tipo; // 1 pequeño 2 mediano 3 grande

public:
    Avion();
};

#endif // AVION_H
