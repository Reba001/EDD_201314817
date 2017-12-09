#ifndef Lista
#define Lista
#include "stdio.h"
#include "stdlib.h"
//declaracion de tipos
typedef struct Nodo Nodo;
typedef struct List List;

//declaracion estructura del nodo
struct Nodo
{
    int valor;
    Nodo * siguiente;
    Nodo * anterior;
};

//declaracion  estructura de la  lista
struct List
{
    Nodo * cabeza;
    Nodo * cola;

};

//declaracion de operaciones
void agregar(List * lista, int valor);
void recorrer(List * lista);
void eliminar(List * lista, int valor);

#endif // LISTA
