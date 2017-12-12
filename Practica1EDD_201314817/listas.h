#ifndef LISTAS_H
#define LISTAS_H
#include "pasajero.h"
#include "avion.h"
#include "stdlib.h"
#include "iostream"
#include "stdio.h"
using namespace std;
typedef struct Nodo Nodo;
typedef struct Listas Listas;
typedef struct Cola Cola;
typedef struct Escritorios Escritorios;
typedef struct Pila Pila;
typedef struct ListaEscritorio ListaEscritorio;
struct Nodo
{
    int numero;
    Pasajero pasajero;
    char escritorio;
    Avion avion;
    Nodo * anterior;
    Nodo * siguiente;
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
    int tamanioS;
    int tamanioD;
    int tamanioC;

    Listas();
    void insertarS(int numero);
    void insertarD(int numero);
    void insertarC(int numero);

    void insertarDEsc(char esc);

    void insertarSD(int numero);
    void insertarDD(int numero);
    void insertarCD(int numero);

    void recorrerS();
    void recorrerD();
    void recorrerC();

    void eliminarS(int numero);
    void eliminarD(int numero);
    void eliminarC(int numero);
};

struct Cola{
    Nodo * cabeza;
    Nodo * cola;

    int tamanio;
    Cola();
    void push(Nodo *pasajero);
    Nodo * pop();
    void recorrer();

};

struct Pila{
    Nodo *cabeza;
    Nodo *cola;
    int tamanio;

    Pila();

    void apilar(int numero);
    void desapilar();
    void recorrer();
    void eliminar();

};

struct Escritorios{
    char desk;
    Escritorios * siguiente;
    Escritorios * anterior;
    Escritorios(char desk);
    Nodo * pasajeros;
    Nodo * documentos;
};

struct ListaEscritorio{
    Escritorios * primero;
    Escritorios * ultimo;
    ListaEscritorio();
    void insertar(Escritorios * desktop);
    Escritorios * getEscritorio(char desk);
};

#endif // LISTAS_H
