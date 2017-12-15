#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    this->escritorios = new Desktops();
    this->pasajeros = new Cola();
    this->aviones = new Cola();
    this->listaEq = new List();
    this->listmant = new ListaMantenimiento();

    Pasajero pas1(3, 5, 123, 3);
    Pasajero pas2(4, 3, 124, 2);
    Pasajero pas3(2, 5, 125, 4);
    Pasajero pas4(1, 2, 126, 1);
    Pasajero pas5(5, 10, 127, 3);
    Pasajero pas6(3, 6, 128, 1);
    Pasajero pas7(4, 7, 129, 2);
    this->pasajeros->push(pas1);
    this->pasajeros->push(pas2);
    this->pasajeros->push(pas3);
    this->pasajeros->push(pas4);
    this->pasajeros->push(pas5);
    this->pasajeros->push(pas6);
    this->pasajeros->push(pas7);

    Avion avion1(266, 2, 1, 2);
    Avion avion2(267, 3, 2, 3);
    Avion avion3(268, 7, 3, 2);
    Avion avion4(269, 6, 3, 3);
    Avion avion5(270, 5, 2, 1);
    Avion avion6(271, 3, 1, 3);
    Avion avion7(272, 4, 1, 1);
    Avion avion8(273, 2, 2, 2);
    this->aviones->pushD(avion1);
    this->aviones->pushD(avion2);
    this->aviones->pushD(avion3);
    this->aviones->pushD(avion4);
    this->aviones->pushD(avion5);
    this->aviones->pushD(avion6);
    this->aviones->pushD(avion7);
    this->aviones->pushD(avion8);

    this->pasajeros->recorrer();
    this->aviones->recorrerD();

    this->escritorios->insertar(98);
    this->escritorios->insertar(99);
    int tam = pasajeros->tamanio;
    cout << to_string(pasajeros->tamanio) << endl;
    for(int i = 0; i < tam; i++){
        Nodo * pasaje = this->pasajeros->pop();
        if (pasaje != nullptr){
            Pasajero pass1 = pasaje->pasajero;
            escritorios->insertarPasajeros(pass1);
            for(int j =0 ; j < pass1.getMaletas(); j++){
                listaEq->insertarC(j);
            }
            delete pasaje;
        }
    }
    this->listaEq->recorrerC();
    this->escritorios->recorrer();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    this->pasajeros->recorrer();
    this->aviones->recorrerD();



    this->escritorios->recorrer();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    delete this->escritorios->listadesktop->getEscritorio(98)->pasajeros->pop();
    int tam2 = this->escritorios->listadesktop->getEscritorio(98)->documentos->tamanio;
    for (int i =0 ; i < tam2 ; i++){
        this->escritorios->listadesktop->getEscritorio(98)->documentos->desapilar();
    }
    cout << "Primer eliminacion circular" << endl;

    for(int i = 0; i < 5; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    cout << "Segunda eliminacion circular" << endl;

    for(int i = 0; i < 3; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    for(int i = 0; i < 5; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    for(int i = 0; i < 2; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    for(int i = 0; i < 10; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    for(int i = 0; i < 6; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    for(int i = 0; i < 7; i++){
        this->listaEq->eliminarC(i);
    }
    this->listaEq->recorrerC();
    this->escritorios->recorrer();
    this->listmant->insertar(1);
    this->listmant->insertar(2);
    this->listmant->insertar(3);
    int tam5 = this->aviones->tamanioD;
    for(int k = 0; k < tam5; k++){
        Nodo *av = this->aviones->popD();
        if (av != nullptr){
            this->listmant->insertarA(av->avion, av->avion.getMantenimiento());
        }
        delete av;
    }
    this->aviones->recorrerD();
    this->listmant->recorrer();



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
