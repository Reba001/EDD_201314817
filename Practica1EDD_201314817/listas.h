#ifndef LISTAS_H
#define LISTAS_H
#include "pasajero.h"
#include "avion.h"
#include "stdlib.h"
#include "iostream"
#include "stdio.h"
using namespace std;
typedef struct Nodo Nodo;
typedef struct List List;
typedef struct Cola Cola;
typedef struct Escritorios Escritorios;
typedef struct Pila Pila;
typedef struct ListaEscritorio ListaEscritorio;
typedef struct Desktops Desktops;
typedef struct Mantenimiento Mantenimiento;
typedef struct ListaMantenimiento ListaMantenimiento;
struct Nodo
{
public:
    int numero;
    Pasajero pasajero;
    char escritorio;
    Avion avion;
    Nodo * anterior;
    Nodo * siguiente;
    Nodo * arriba;
    Nodo * abajo;
    Nodo(int numero);
    Nodo(Pasajero pasajero);
    Nodo(char escritorio);
    Nodo(Avion avion);
};

struct List
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

    List();
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


    Nodo * cabezaD;
    Nodo * colaD;

    int tamanio;
    int tamanioD;

    Cola();
    void push(Pasajero pasajero);
    Nodo * pop();

    void pushA(Avion avion);
    Nodo * popA();
    void recorrerA();


    void pushD(Avion avion);
    Nodo *popD();

    void recorrer();
    void recorrerD();

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
    Cola * pasajeros;
    Pila * documentos;
    Escritorios * siguiente;
    Escritorios * anterior;
    Escritorios(char desk);

};

struct ListaEscritorio{
    Escritorios * primero;
    Escritorios * ultimo;
    ListaEscritorio();
    void insertar(char desk);
    Escritorios * getEscritorio(char desk);
};

struct Desktops{
    ListaEscritorio *listadesktop;
    Desktops();
    void insertar(char desk);
    void insertarPasajeros(Pasajero pasajero);
    void recorrer();

};

struct Mantenimiento{
    int numero;
    Cola *avionesM;
    Mantenimiento *siguiente;
    Mantenimiento(int numero);
 };

struct ListaMantenimiento{
    Mantenimiento *primero;
    Mantenimiento *ultimo;
    ListaMantenimiento();
    void insertar(int numero);
    void insertarA(Avion avion, int numero);
    Mantenimiento *buscarM(int numero);
    void eliminar(int numero);
    void recorrer();

};

#endif // LISTAS_H
