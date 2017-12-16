#include "simulador.h"
#include "ui_simulador.h"

Simulador::Simulador(QString avion, QString escritorios, QString servicios, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Simulador)
{
    ui->setupUi(this);
    this->avion = avion;
    this->escritorios = escritorios;
    this->servicios = servicios;
    this->escrito = new Desktops();
    this->pasajeros = new Cola();
    this->avions = new Cola();
    this->listaEq = new List();
    this->listmant = new List;
    this->avMant = new Cola();
    this->turnoA = 0;
    this->generacionAviones();
    this->generacionEscritor();
    this->generacionServicio();
    this->avGlobal = this->avions->cabezaD;
    this->generacionPasajeros();
    this->grafoGeneral();
}

Simulador::~Simulador()
{
    delete ui;
}

void Simulador::generacionAviones()
{
    cout << "Aqui inicia la generacion de aviones" << endl;
    srand(time(NULL));
    int numav = avion.toInt();
    for(int i= 0; i < numav; i++){
        int id= 123+i;
        int tamanio = rand()%3;
        int turnoD = 0;
        int turnoM = 0;
        if(tamanio == 0){
            turnoD = 1;
            turnoM = 1+(rand()%3);
        }else if (tamanio == 1){
            turnoD = 2;
            turnoM = 2+(rand()%3);
        }else{
            turnoD = 3;
            turnoM = 3+(rand()%4);
        }

        Avion av(id,turnoD, turnoM, tamanio);
        this->avions->pushD(av);
    }
    this->avions->recorrerD();
    cout << "Aqui finaliza" << endl;
    // para generar pasajeros
    //int p = 0 ;
    //if(tamanio == 0){
      //  p = 5+(rand()%6);
    //}else if (tamanio == 1){
     //   p = 15+(rand()%11);
    //}else{
      //  p = 30+(rand()%11);
    //}
}

void Simulador::generacionEscritor()
{
    cout << "Aqui inicia la generacion de escritorios" << endl;
    srand(time(NULL));
    int numEsc = this->escritorios.toInt();
    for(int i = 65 ; i < numEsc+65 ; i++){
        this->escrito->insertar(i);
    }
    this->escrito->recorrer();
    cout << "Aqui finaliza" << endl;

}

void Simulador::generacionServicio()
{
    cout << "Aqui iniciar la generacion de Servicios" << endl;
    int numServ = this->servicios.toInt();
    for (int i = 1 ; i <= numServ ; i++){
        this->listmant->insertarS(i);
    }
    this->listmant->recorrerS();
    cout << "Aqui finaliza la generacion de Servicios" << endl;

}

void Simulador::generacionPasajeros()
{
    cout << "Generacion de Pasajeros" << endl;
    srand(time(NULL));
    if(avGlobal != nullptr){
        int tipo = avGlobal->avion.getTipo();
        int numP = 0;
        if (tipo == 0)
            numP = 5+(rand()%6);
        else if (tipo == 1)
            numP = 15+(rand()%11);
        else
            numP = 30+(rand()%11);

        for(int i = 0; i < numP ; i++){
            int id = 234+i;
            int numDoc = 1+(rand()%10);
            int cantMa = 1+(rand()%4);
            int turnR = 1+(rand()%3);
            Pasajero pa(numDoc, cantMa, id, turnR);
            for (int j = 0; j < cantMa; j++){
                this->listaEq->insertarC(j);
            }
            if (this->escrito->colasllenas()){
                this->pasajeros->push(pa);
            }else{
                this->escrito->insertarPasajeros(pa);
            }

        }
        int t = avGlobal->avion.getTurnos();
        this->avGlobal->avion.setTurnos(--t);
    }


    this->escrito->recorrer();
    cout << "Pasajeros en cola " << endl;
    this->pasajeros->recorrer();

    cout << "Termina Generacion de Pasajeros" << endl;
}

void Simulador::desabordajePasajero()
{
    if (this->avions->cabezaD != nullptr){
        if (this->avGlobal->avion.getTurnos() > 0){
            if (avGlobal != nullptr){
                int tipo = avGlobal->avion.getTipo();
                int numP = 0;
                if (tipo == 0)
                    numP = 5+(rand()%6);
                else if (tipo == 1)
                    numP = 15+(rand()%11);
                else
                    numP = 30+(rand()%11);

                for(int i = 0; i < numP ; i++){
                    int id = 234+i;
                    int numDoc = 1+(rand()%10);
                    int cantMa = 1+(rand()%4);
                    int turnR = 1+(rand()%3);
                    Pasajero pa(numDoc, cantMa, id, turnR);
                    for(int k = 1; k < cantMa+1 ; k++){
                        this->listaEq->insertarC(k);
                    }
                    if (this->escrito->colasllenas()){
                        this->pasajeros->push(pa);

                    }else{
                        this->escrito->insertarPasajeros(pa);
                    }

                }
                int t = avGlobal->avion.getTurnos();
                this->avGlobal->avion.setTurnos(--t);
            }


        }else{

            this->avMant->pushA(avGlobal->avion);
            Nodo *aux = this->avions->popD();
            this->avMant->pushD(aux->avion);
            aux = nullptr;
            delete aux;
            avGlobal = nullptr;
            delete avGlobal;
            avGlobal = this->avions->cabezaD;
            if (avGlobal != nullptr){
                int tipo = avGlobal->avion.getTipo();
                int numP = 0;
                if (tipo == 0)
                    numP = 5+(rand()%6);
                else if (tipo == 1)
                    numP = 15+(rand()%11);
                else
                    numP = 30+(rand()%11);

                for(int i = 0; i < numP ; i++){
                    int id = 234+i;
                    int numDoc = 1+(rand()%10);
                    int cantMa = 1+(rand()%4);
                    int turnR = 1+(rand()%3);
                    Pasajero pa(numDoc, cantMa, id, turnR);

                    if (this->escrito->colasllenas()){
                        this->pasajeros->push(pa);

                    }else{
                        this->pasajeros->push(pa);
                        Nodo *nuevoP = pasajeros->pop();
                        this->escrito->insertarPasajeros(nuevoP->pasajero);
                        nuevoP = nullptr;
                        delete nuevoP;
                    }

                }
                int t = avGlobal->avion.getTurnos();
                this->avGlobal->avion.setTurnos(--t);
            }

        }
    }else{
        avGlobal = nullptr;
        delete avGlobal;
        cout << "Vacio" << endl;
    }

}

void Simulador::insertardesdeColaEspera()
{
    if (this->avions->cabezaD == nullptr){
        if (!this->escrito->colasllenas()){
            if (this->pasajeros->cabeza != nullptr){
                Nodo *nuevoP = pasajeros->pop();
                this->escrito->insertarPasajeros(nuevoP->pasajero);
                nuevoP = nullptr;
                delete nuevoP;
            }
        }

    }
}

void Simulador::eliminarMaletas(int n)
{
    for (int i =0 ; i < n ; i++){
        this->listaEq->popC();
    }
}

void Simulador::grafoGeneral()
{
    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ColaPasajero{\n";

    this->pasajeros->cadenaPasajero(grafo);
    grafo += "\t label = \"Pasajeros\";\n" ;
    grafo += "\t color = blue\n" ;
    grafo += "\t}\n";
    grafo += "\t subgraph ColaAviones{\n";
    grafo += "\t \"Aviones\";\n";
    this->avions->cadenaAvionD(grafo);
    grafo += "\t label = \"Aviones\";\n" ;
    grafo += "\t color = blue\n" ;
    grafo += "\t}\n";
    grafo += "\t subgraph ColaEscritorios{\n";
    grafo += "\t rankdir=UD;\n";
    this->escrito->cadenaEscritorio(grafo);
    grafo += "label = \"Escritorio\";\n" ;
    grafo += "\t color = blue\n" ;
    grafo += "\t}\n";
    grafo += "\t subgraph ListaServicios{\n";
    grafo += "\t rankdir=UD;\n";
    this->listmant->cadenaGrafoS(grafo);
    grafo += "label = \"Mantenimiento\";\n" ;
    grafo += "\t color = blue\n" ;
    grafo += "\t}\n";
    grafo += "\t subgraph AvionesMantenimiento{\n";
    grafo += "\t rankdir=UD;\n";
    this->avMant->cadenaAvionD(grafo);
    grafo += "label = \"Aviones en Mantenimiento\";\n" ;
    grafo += "\t color = blue\n" ;
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("//home//reba//Escritorio//grafoFinal.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng //home//reba//Escritorio//grafoFinal.dot -o //home//reba//Escritorio//grafoFinal.png");

}

void Simulador::on_pushButton_clicked()
{
    int n = 0;
    this->escrito->finalizarRegistro(n);
    this->eliminarMaletas(n);
    this->desabordajePasajero();
    this->insertardesdeColaEspera();

    cout << "Este es el numero de maletas: " << to_string(n) << endl;
    cout << "EStas son las maletas " << endl;
    this->listaEq->recorrerC();
    cout << "Se terminaron las maletas" << endl;
    cout << "Escritorios Ocupados " << endl;
    this->escrito->recorrer();
    cout << "Pasajeros en cola " << endl;
    this->pasajeros->recorrer();
    cout << "Escritorios ocupados finalizado " << endl;
    cout << "Inicia Lista Aviones " << endl;
    this->avions->recorrerD();
    cout << "Finaliza Lista Aviones" << endl;
    this->listaEq->crearGrafo();
    this->pasajeros->grafoPasajero();
    this->avions->grafoAvionD();
    this->escrito->grafoEscritorio();
    this->grafoGeneral();

}

void Simulador::on_pushButton_2_clicked()
{

    QDesktopServices::openUrl(QUrl("//home//reba//Escritorio//grafoFinal.png",QUrl::TolerantMode));
}
