#ifndef SIMULADOR_H
#define SIMULADOR_H

#include <QDialog>
#include "qstring.h"
#include <time.h>
#include <listas.h>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <avion.h>
#include <pasajero.h>
#include <QUrl>
#include <QIODevice>
#include <QDesktopServices>
#include <QFile>

namespace Ui {
class Simulador;
}

class Simulador : public QDialog
{
    Q_OBJECT

public:
    explicit Simulador(QString avion, QString escritorios, QString servicios, QWidget *parent = 0);
    ~Simulador();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

private:
    Ui::Simulador *ui;
    QString avion;
    QString escritorios;
    QString servicios;
    Cola *avions;
    Cola *pasajeros;
    Desktops *escrito;
    List *listaEq;
    List *listmant;
    Cola *avMant;
    int turnoA;
    Nodo *avGlobal;

    void generacionAviones();
    void generacionEscritor();
    void generacionServicio();
    void generacionPasajeros();
    void desabordajePasajero();
    void insertardesdeColaEspera();
    void eliminarMaletas(int n);
    void grafoGeneral();
};

#endif // SIMULADOR_H
