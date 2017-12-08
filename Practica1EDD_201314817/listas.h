#ifndef LISTAS_H
#define LISTAS_H
#include "pasajero.h"
#include "avion.h"
typedef struct Nodo Nodo;
typedef struct Listas Listas;
struct Nodo
{
    int numero;
    Pasajero pasajero;
    char escritorio;
    Avion avion:
    Nodo * derecha;
    Nodo * izquierda;
    Nodo * arriba;
    Nodo * abajo;
    Nodo();
    Nodo(int numero);
    Nodo(Pasajero pasajero);
    Nodo(char escritorio);
    Nodo (Avion avion);


};

struct Listas
{
    Nodo * cabezaS;
    Nodo * colaS;
    Nodo * cabezaD;
    Nodo * colaD;
    Nodo * cabezaC;
    Nodo * colaC;
    int tamanio;
    Listas();
    void insertarS(int numero);
    void insertarD(int numero);
    void insertarC(int numero);
};
#endif // LISTAS_H
