#include "pasajero.h"

Pasajero::Pasajero(int documento, int maletas, int id, int turnos)
{
    this->documento = documento;
    this->maletas = maletas;
    this->id = id;
    this->turnos = turnos;
}

int Pasajero::getMaletas() const
{
    return this->maletas;
}

void Pasajero::setMaletas(int value)
{
    this->maletas = value;
}

int Pasajero::getId() const
{
    return this->id;
}

void Pasajero::setId(int value)
{
    this->id = value;
}

int Pasajero::getTurnos() const
{
    return this->turnos;
}

void Pasajero::setTurnos(int value)
{
    this->turnos = value;
}

int Pasajero::getDocumento() const
{
    return this->documento;
}

void Pasajero::setDocumento(int value)
{
    this->documento = value;
}
