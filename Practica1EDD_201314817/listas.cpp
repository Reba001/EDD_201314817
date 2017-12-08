#include "listas.h"


Listas::Listas()
{
    this->cabezaS = nullptr;
    this->colaS = nullptr;
    this->cabezaD = nullptr;
    this->colaD = nullptr;
    this->cabezaC = nullptr;
    this->colaC = nullptr;
    this->tamanio = 0;
}

Nodo::Nodo()
{

}

Nodo::Nodo(int numero)
{
    this->numero;
}

Nodo::Nodo(Pasajero pasajero)
{
    this->pasajero = pasajero;
}

Nodo::Nodo(Avion avion)
{
    this->avion = avion;
}
