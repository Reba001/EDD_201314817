#ifndef PASAJERO_H
#define PASAJERO_H
#include "qstring.h"
#include "stdio.h"
#include "stdlib.h"
#include "iostream"
using namespace std;
class Pasajero
{
private:
    int documento;
    int maletas;
    int id;
    int turnos;
public:
    Pasajero(int documento, int maletas, int id, int turnos);
    Pasajero();
    int getDocumento() const;
    void setDocumento(int value);
    int getMaletas() const;
    void setMaletas(int value);
    int getId() const;
    void setId(int value);
    int getTurnos() const;
    void setTurnos(int value);
    string toString();
};

#endif // PASAJERO_H
