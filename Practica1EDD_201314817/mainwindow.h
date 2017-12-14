#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "listas.h"
#include "pasajero.h"
#include "avion.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    Cola *aviones;
    Cola *pasajeros;
    Desktops *escritorios;
    List *listaEq;
    ListaMantenimiento *listmant;
};

#endif // MAINWINDOW_H
