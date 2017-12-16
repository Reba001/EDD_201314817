#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "qdebug.h"
#include <iostream>
#include <cstdint>
#include <sstream>
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    Nodo *prueba = new Nodo(10);
    std::string direccion;
    {
        std::ostringstream ostm;
        ostm << reinterpret_cast<std::uintptr_t>(prueba);
        direccion = ostm.str();

    }
    cout << direccion << endl;
    cout << &prueba << endl;

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    if(!this->ui->lineEdit->text().isEmpty()){
        QString st1 = this->ui->lineEdit->text();
        QString st2 = this->ui->lineEdit_2->text();
        QString st3 = this->ui->lineEdit_3->text();
        Simulador *sim = new Simulador(st1, st2, st3, this);
        sim->exec();
    }

}
