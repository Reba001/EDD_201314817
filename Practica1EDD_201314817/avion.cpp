#include "avion.h"

int Avion::getId() const
{
    return id;
}

void Avion::setId(int value)
{
    id = value;
}

int Avion::getTurnos() const
{
    return turnos;
}

void Avion::setTurnos(int value)
{
    turnos = value;
}

int Avion::getMantenimiento() const
{
    return mantenimiento;
}

void Avion::setMantenimiento(int value)
{
    mantenimiento = value;
}

int Avion::getTipo() const
{
    return tipo;
}

void Avion::setTipo(int value)
{
    tipo = value;
}

Avion::Avion(int id, int turnos, int mantenimiento, int tipo)
{
    this->id = id;
    this->turnos = turnos;
    this->mantenimiento = mantenimiento;
    this->tipo = tipo;
}

string Avion::toString()
{
    string avion = "";
    avion += "id: "+to_string(id) + "\n turnos: "+to_string(turnos)+ "\n mantenimiento: "+to_string(mantenimiento)+ "\n tipo: "+to_string(tipo);
    return avion;
}

Avion::Avion()
{

}
