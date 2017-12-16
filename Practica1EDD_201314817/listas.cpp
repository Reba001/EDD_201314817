#include "listas.h"


List::List()
{
    this->cabezaS = nullptr;
    this->colaS = nullptr;
    this->cabezaD = nullptr;
    this->colaD = nullptr;
    this->cabezaC = nullptr;
    this->colaC = nullptr;
    this->tamanioS = 0;
    this->tamanioD = 0;
    this->tamanioC = 0;

}

void List::insertarS(int numero)
{
    Nodo * nuevo = new Nodo(numero);
    if (this->cabezaS == nullptr){
        this->cabezaS = nuevo;
        this->colaS = nuevo;
    }else {
        this->colaS->siguiente = nuevo;
        this->colaS = nuevo;
    }
    this->tamanioS++;

}

void List::insertarD(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if(this->cabezaD == nullptr)
    {
        this->cabezaD = nuevo;
        this->colaD = nuevo;
    }else
    {
        this->colaD->siguiente = nuevo;
        nuevo->anterior = this->colaD;
        this->colaD = nuevo;
    }
    this->tamanioD++;

}

void List::insertarC(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if(this->cabezaC == nullptr)
    {
        nuevo->siguiente = nuevo;
        nuevo->anterior = nuevo;
        this->cabezaC = this->colaC = nuevo;
    }
    else
    {
        this->colaC->siguiente = nuevo;
        nuevo->anterior = this->colaC;
        nuevo->siguiente = this->cabezaC;
        this->cabezaC->anterior = nuevo;
        this->colaC = nuevo;
    }
    this->tamanioC++;
}

void List::insertarDEsc(char esc)
{
    Nodo *nuevo = new Nodo(esc);
    if(this->cabezaD == nullptr)
    {
        this->cabezaD = nuevo;
        this->colaD = nuevo;
    }else
    {
        this->colaD->siguiente = nuevo;
        nuevo->anterior = this->colaD;
        this->colaD = nuevo;
    }
    this->tamanioD++;

}

void List::insertarSD(int numero)
{
    Nodo * nuevo = new Nodo(numero);
    if (this->cabezaS == nullptr){
        this->cabezaS = nuevo;
        this->colaS = nuevo;
    }else {
        nuevo->siguiente = this->cabezaS;
        this->cabezaS = nuevo;
    }
    this->tamanioS++;
}

void List::insertarDD(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if(this->cabezaD == nullptr)
    {
        this->cabezaD = nuevo;
        this->colaD = nuevo;
    }else
    {
        this->cabezaD->anterior = nuevo;
        nuevo->siguiente = this->cabezaD;
        this->cabezaD = nuevo;
    }
    this->tamanioD++;
}

void List::insertarCD(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if(this->cabezaC == nullptr)
    {
        nuevo->siguiente = nuevo;
        nuevo->anterior = nuevo;
        this->cabezaC = this->colaC = nuevo;
    }
    else
    {
        this->cabezaC->anterior = nuevo;
        nuevo->siguiente = this->cabezaC;
        nuevo->anterior = this->colaC;
        this->colaC->siguiente = nuevo;
        this->cabezaC = nuevo;
    }
    this->tamanioC++;
}

void List::popC()
{
    if (this->cabezaC != nullptr){
        if (this->cabezaC == this->colaC){
            this->cabezaC = nullptr;
            this->colaC = nullptr;
            delete this->cabezaC;
            delete this->colaC;
            return;

        }else if(this->cabezaC->siguiente == this->colaC){
            Nodo *aux = this->cabezaC;
            this->cabezaC = this->cabezaC->siguiente;
            this->cabezaC->anterior = this->colaC;
            this->cabezaC->siguiente = this->colaC;
            this->colaC->anterior = this->cabezaC;
            this->colaC->siguiente = this->cabezaC;
            aux = nullptr;
            delete aux;
            return;
        }

        Nodo *aux = this->cabezaC;
        this->cabezaC = this->cabezaC->siguiente;
        this->cabezaC->anterior = this->colaC;
        this->colaC->siguiente = this->cabezaC;
        aux->anterior = nullptr;
        aux->siguiente = nullptr;
        aux = nullptr;
        delete aux;
        return;

    }else{
        cout << "Vacia ggizi" << endl;
    }

}

void List::crearGrafo()
{

    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ListaMaletin{\n";
    grafo += "\t node[style=filled];\n";
    this->cadenaGrafo(grafo);
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("grafo.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng grafo.dot -o grafo.png");

}

void List::cadenaGrafo(string &graph)
{
    if(this->cabezaC != nullptr){
        Nodo *aux = this->cabezaC;
        do{
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux);
                direccion = ostm.str();
            }

            std::string direccionsig;
            {
                std::ostringstream ostms;
                ostms << reinterpret_cast<std::uintptr_t>(aux->siguiente);
                direccionsig = ostms.str();
            }

            std::string direccionant;
            {
                std::ostringstream ostm2;
                ostm2 << reinterpret_cast<std::uintptr_t>(aux->anterior);
                direccionant = ostm2.str();
            }
            graph += "\t"+ direccion+"[label=\""+to_string(aux->numero)+"\"];\n";
            graph += "\t"+ direccionant+"[label=\""+to_string(aux->anterior->numero)+"\"];\n";
            graph += "\t"+ direccion+" -> "+direccionant+";\n";
            graph += "\t"+ direccion+" -> "+direccionsig+";\n";
            aux = aux->siguiente;

        }
        while(aux != this->cabezaC);

    }else {
        graph += "Vacio DX" ;
    }
}

void List::cadenaGrafoS(string &graph)
{
    if(this->cabezaS != nullptr){
        Nodo *aux = this->cabezaS;
        Nodo *aux2 = this->cabezaS;
        graph += "{rank=min;\"SERVICIOS\";";
        while(aux2 != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux2);
                direccion = ostm.str();
            }
            graph += direccion +";";
            aux2 = aux2->siguiente;
        }
        graph+= "};\n";
        while(aux->siguiente != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux);
                direccion = ostm.str();
            }

            std::string direccionsig;
            {
                std::ostringstream ostms;
                ostms << reinterpret_cast<std::uintptr_t>(aux->siguiente);
                direccionsig = ostms.str();
            }


            graph += "\t"+ direccion+"[label=\""+to_string(aux->numero)+"\"];\n";
            graph += "\t"+ direccionsig+"[label=\""+to_string(aux->siguiente->numero)+"\"];\n";
            graph += "\t"+ direccion+" -> "+direccionsig+";\n";
            aux = aux->siguiente;
        }
    }else {
        graph += "Vacio";
    }

}

void List::recorrerS()
{
    if (this->cabezaS != nullptr){
        Nodo * auxiliar= this->cabezaS;
        while(auxiliar != nullptr){
            cout << to_string(auxiliar->numero) <<"\n" ;
            auxiliar = auxiliar->siguiente;
        }
    }else{
       cout << "Vacio DX !! \n" ;
    }

}

void List::recorrerD()
{
    if (this->cabezaD != nullptr){
        Nodo * auxiliar= this->cabezaD;
        while(auxiliar != nullptr){
            cout << to_string(auxiliar->numero) <<"\n" ;
            auxiliar = auxiliar->siguiente;
        }
    }else{
       cout << "Vacio DX !! \n" ;
    }

}

void List::recorrerC()
{
    if (this->cabezaC != nullptr){
        Nodo * auxiliar= this->cabezaC;
        do
        {
            cout << to_string(auxiliar->numero) <<"\n" ;
            auxiliar = auxiliar->siguiente;
        }
        while(auxiliar != this->cabezaC);
    }else{
       cout << "Vacio DX !! \n" ;
    }
}

void List::eliminarS(int numero)
{
    if(this->cabezaS != nullptr)
    {
        if (this->cabezaS->numero == numero){
            if (this->cabezaS->siguiente != nullptr){
                Nodo *aux = this->cabezaS;
                this->cabezaS = this->cabezaS->siguiente;
                aux = nullptr;
                delete aux;
            }else{
                delete this->cabezaS;
            }
        }else{
            Nodo *ant = nullptr;
            Nodo *aux = this->cabezaS;
            while(aux->siguiente != nullptr){
                if(aux->numero == numero){
                    ant->siguiente = aux->siguiente;
                    delete aux;
                    this->tamanioS--;
                    return;
                }
                ant = aux;
                aux = aux->siguiente;
            }
            if (aux->siguiente == nullptr && aux->numero == numero){
                ant->siguiente = nullptr;
                delete aux;
            }
        }
        this->tamanioS--;
    }
    else
    {
        cout << "Vacio DX !!" << endl;
    }
}

void List::eliminarD(int numero)
{
    if(this->cabezaD != nullptr)
    {
        if (this->cabezaD->numero == numero){
            if (this->cabezaD->siguiente != nullptr){
                Nodo *aux = this->cabezaD;
                this->cabezaD = this->cabezaD->siguiente;
                this->cabezaD->anterior = nullptr;
                delete aux;
            }else{
                delete this->cabezaD;
            }
        }else{
            Nodo *aux = this->cabezaD;
            while(aux->siguiente != nullptr){
                if(aux->numero == numero){
                    aux->siguiente->anterior = aux->anterior;
                    aux->anterior->siguiente = aux->siguiente;
                    delete aux;
                    this->tamanioD--;
                    return;
                }
                aux = aux->siguiente;
            }
            if (aux->siguiente == nullptr && aux->numero == numero){
                aux->anterior->siguiente = nullptr;
                delete aux;
            }
        }
        this->tamanioD--;
    }
    else
    {
        cout << "Vacio DX !!" << endl;
    }
}

void List::eliminarC(int numero)
{
    if(this->cabezaC != nullptr)
    {
        if (this->cabezaC->numero == numero){
            if (this->cabezaC->siguiente != this->cabezaC){
                Nodo *aux = this->cabezaC;
                this->cabezaC = this->cabezaC->siguiente;
                this->colaC->siguiente = this->cabezaC;
                this->cabezaC->anterior = this->colaC;
                delete aux;
            }else{
                this->cabezaC = nullptr;
                this->colaC = nullptr;
                delete this->cabezaC;
                delete this->colaC;
            }
        }else{
            Nodo *aux = this->cabezaC;
            do{
                if (aux->numero == numero){
                    aux->anterior->siguiente = aux->siguiente;
                    aux->siguiente->anterior = aux->anterior;
                    aux = nullptr;
                    delete aux;
                    this->tamanioC--;
                    return;
                }
                aux = aux->siguiente;

            }while(aux->siguiente != this->cabezaC);

            if (aux->siguiente == this->cabezaC && aux->numero == numero){
                aux->anterior->siguiente = this->cabezaC;
                this->colaC = aux->anterior;
                aux = nullptr;
                delete aux;
            }
        }
        this->tamanioC--;
    }
    else
    {
        cout << "Vacio DX !!" << endl;
    }

}



Nodo::Nodo(int numero)
{
    this->numero = numero;
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->arriba = nullptr;
    this->abajo = nullptr;
}

Nodo::Nodo(Pasajero pasajero){
    this->pasajero = pasajero;
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->arriba = nullptr;
    this->abajo = nullptr;
}

Nodo::Nodo(char escritorio)
{
    this->escritorio = escritorio;
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->arriba = nullptr;
    this->abajo = nullptr;
}

Nodo::Nodo(Avion avion)
{
    this->avion = avion;
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->arriba = nullptr;
    this->abajo = nullptr;
}

Cola::Cola()
{
    this->cabeza = nullptr;
    this->cola = nullptr;

    this->cabezaD = nullptr;
    this->colaD = nullptr;

    this->tamanio = 0;
    this->tamanioD = 0;

}

Nodo * Cola::pop()
{
    if (this->cabeza != nullptr){
        if (this->cabeza->siguiente != nullptr){
            Nodo *aux = this->cabeza;
            this->cabeza = this->cabeza->siguiente;
            aux->siguiente = nullptr;
            --tamanio;
            return aux;
        }else{
            Nodo * aux = this->cabeza;
            this->cabeza = nullptr;
            --tamanio;
            return aux;
        }
    }
    cout << "Vacio DX !! " << endl;
    return nullptr;
}

void Cola::grafoPasajero()
{
    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ColaPasajero{\n";
    grafo += "\t node[style=filled];\n";
    this->cadenaPasajero(grafo);
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("grafoPasajero.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng grafoPasajero.dot -o grafoPasajero.png");

}

void Cola::cadenaPasajero(string &graph)
{
    if (this->cabeza != nullptr){
        Nodo *aux = this->cabeza;

        while(aux->siguiente != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux);
                direccion = ostm.str();
            }

            std::string direccionsig;
            {
                std::ostringstream ostms;
                ostms << reinterpret_cast<std::uintptr_t>(aux->siguiente);
                direccionsig = ostms.str();
            }

            graph += "\t"+ direccion+"[label=\""+aux->pasajero.toString()+"\"];\n";
            graph += "\t"+ direccionsig+"[label=\""+aux->siguiente->pasajero.toString()+"\"];\n";
            graph += "\t"+ direccion+" -> "+direccionsig;

            aux = aux->siguiente;

        }
    }else{
        graph +="\"Vacio DX\"";
    }
}

void Cola::pushA(Avion avion)
{
    Nodo *nuevo = new Nodo(avion);
    if (this->cabeza == nullptr){
        this->cabeza = nuevo;
        this->cola = nuevo;
    }else{
        this->cola->siguiente = nuevo;
        this->cola = nuevo;
    }
    ++tamanio;

}

Nodo *Cola::popA()
{
    if (this->cabeza != nullptr){
        if (this->cabeza->siguiente != nullptr){
            Nodo *aux = this->cabeza;
            this->cabeza = this->cabeza->siguiente;
            aux->siguiente = nullptr;
            --tamanio;
            return aux;
        }else{
            Nodo * aux = this->cabeza;
            this->cabeza = nullptr;
            --tamanio;
            return aux;
        }
    }
    cout << "Vacio DX !! " << endl;
    return nullptr;

}

void Cola::recorrerA()
{
    if(this->cabeza != nullptr){
        Nodo * aux = this->cabeza;
        while (aux != nullptr){
            cout << "Cola : " << aux->avion.toString() << endl ;
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !!" << endl;
    }
}

void Cola::grafoAvion()
{

    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ColaAvion{\n";
    grafo += "\t node[style=filled];\n";
    this->cadenaAvion(grafo);
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("grafoAvion.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng grafoAvion.dot -o grafoAvion.png");

}

void Cola::cadenaAvion(string &graph)
{
    if(this->cabeza != nullptr){
        Nodo *aux = this->cabeza;

        while(aux->siguiente != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux);
                direccion = ostm.str();
            }

            std::string direccionsig;
            {
                std::ostringstream ostms;
                ostms << reinterpret_cast<std::uintptr_t>(aux->siguiente);
                direccionsig = ostms.str();
            }

            graph += "\t"+ direccion+"[label=\""+aux->avion.toString()+"\"];\n";
            graph += "\t"+ direccionsig+"[label=\""+aux->siguiente->avion.toString()+"\"];\n";
            graph += "\t"+ direccion+" -> "+direccionsig;

            aux = aux->siguiente;
        }
    }else{
        graph += "Vacio" ;
    }
}

void Cola::pushD(Avion avion)
{
    Nodo * nuevo = new Nodo(avion);
    if (this->cabezaD == nullptr){
        this->cabezaD = this->colaD = nuevo;
    }else{
        this->colaD->siguiente = nuevo;
        nuevo->anterior = this->colaD;
        this->colaD = nuevo;
    }
    ++tamanioD;
}

Nodo *Cola::popD()
{
    if (this->cabezaD != nullptr){
        if (this->cabezaD->siguiente != nullptr){
            Nodo *aux = this->cabezaD;
            this->cabezaD = this->cabezaD->siguiente;
            aux->siguiente = nullptr;
            this->cabezaD->anterior = nullptr;
            --tamanioD;
            return aux;
        }else{
            Nodo *aux = this->cabezaD;
            this->cabezaD = nullptr;
            --tamanioD;
            return aux;
        }
    }
    return nullptr;
}

void Cola::grafoAvionD()
{

    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ColaAvionDesabordaje{\n";
    grafo += "\t node[style=filled];\n";
    this->cadenaAvionD(grafo);
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("grafoAvionD.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng grafoAvionD.dot -o grafoAvionD.png");
}

void Cola::cadenaAvionD(string &graph)
{
    if(this->cabezaD != nullptr){
        Nodo *aux = this->cabezaD;
        while(aux->siguiente != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(aux);
                direccion = ostm.str();
            }

            std::string direccionsig;
            {
                std::ostringstream ostms;
                ostms << reinterpret_cast<std::uintptr_t>(aux->siguiente);
                direccionsig = ostms.str();
            }

            if(aux->anterior != nullptr){

                std::string direccionAnt;
                {
                    std::ostringstream ostmA;
                    ostmA << reinterpret_cast<std::uintptr_t>(aux->anterior);
                    direccionAnt = ostmA.str();
                }

                graph += "\t"+ direccionAnt+"[label=\""+aux->anterior->avion.toString()+"\"];\n";
                graph += "\t"+ direccion+" -> "+direccionAnt;

            }


            graph += "\t"+ direccion+"[label=\""+aux->avion.toString()+"\"];\n";
            graph += "\t"+ direccionsig+"[label=\""+aux->siguiente->avion.toString()+"\"];\n";
            graph += "\t"+ direccion+" -> "+direccionsig;

            aux = aux->siguiente;
        }
    }else{
        graph += "Vacio" ;
    }
}



void Cola::recorrer()
{
    if(this->cabeza != nullptr){
        Nodo * aux = this->cabeza;
        while (aux != nullptr){
            cout << "Cola : " << aux->pasajero.toString() << endl ;
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !!" << endl;
    }
}

void Cola::recorrerD()
{

    if(this->cabezaD != nullptr){
        Nodo * aux = this->cabezaD;
        while (aux != nullptr){
            cout << "Cola : " << aux->avion.toString() << endl ;
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !!" << endl;
    }
}

void Cola::push(Pasajero pasajero)
{
    Nodo *nuevo = new Nodo(pasajero);
    if (this->cabeza == nullptr){
        this->cabeza = nuevo;
        this->cola = nuevo;
    }else{
        this->cola->siguiente = nuevo;
        this->cola = nuevo;
    }
    ++tamanio;
}

Escritorios::Escritorios(char desk)
{
    this->desk = desk;
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->documentos = new Pila();
    this->pasajeros = new Cola();

}

Pila::Pila()
{
    this->cabeza = nullptr;
    this->cola = nullptr;
    this->tamanio = 0;
}

void Pila::apilar(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if (this->cabeza == nullptr){
        this->cabeza = nuevo;
        this->cola = nuevo;
    }else{
        this->cabeza->anterior = nuevo;
        nuevo->siguiente = this->cabeza;
        this->cabeza = nuevo;
    }
    this->tamanio++;
}

void Pila::desapilar()
{
    if (this->cabeza != nullptr){
        if (this->cabeza->siguiente != nullptr){

            Nodo *aux = this->cabeza;
            this->cabeza = this->cabeza->siguiente;
            this->cabeza->anterior = nullptr;
            delete aux;

        }else{
            this->eliminar();
        }

    }else {
        cout << "Vacios! " << endl;
    }
}

void Pila::recorrer()
{
    if (this->cabeza != nullptr){
        Nodo *aux = this->cabeza;
        while(aux != nullptr){
            cout << "Pila: " << to_string(aux->numero) << endl;
            aux = aux->siguiente;
        }
    }else {
        cout << "Vacio" << endl;
    }
}

void Pila::eliminar()
{
    this->cabeza = nullptr;
    delete this->cabeza;
}

ListaEscritorio::ListaEscritorio()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
    this->tamanioE = 0;
}

void ListaEscritorio::insertar(char desk)
{
    Escritorios *desktop = new Escritorios(desk);
    if (this->primero == nullptr){
        this->primero = desktop;
        this->ultimo = desktop;
    }else{
        this->ultimo->siguiente = desktop;
        desktop->anterior = this->ultimo;
        this->ultimo = desktop;
    }
    ++tamanioE;
}

Escritorios *ListaEscritorio::getEscritorio(char desk)
{
    if (this->primero != nullptr){
        Escritorios *aux = this->primero;
        while(aux != nullptr){
            if (aux->desk == desk){
                return aux;
            }
            aux = aux->siguiente;
        }
    }
    return nullptr;
}



Desktops::Desktops()
{
    this->listadesktop = new ListaEscritorio();
    this->listEq = new List();
}

void Desktops::insertar(char desk)
{
    Escritorios *esc = this->listadesktop->getEscritorio(desk);
    if (esc == nullptr){
        this->listadesktop->insertar(desk);

    }else{
        cout << "ya insertado" << endl;
    }
}

bool Desktops::colasllenas()
{
    if (this->listadesktop->primero != nullptr){
        Escritorios *aux = this->listadesktop->primero;
        int resultado = 0;
        while (aux != nullptr){
            int tam = aux->pasajeros->tamanio;
            resultado += tam;
            aux = aux->siguiente;
        }
        return resultado == (this->listadesktop->tamanioE *10);
    }
    return false;
}

void Desktops::insertarPasajeros(Pasajero pasajero)
{
    if(this->listadesktop->primero != nullptr){
        Escritorios *aux = this->listadesktop->primero;
        while(aux != nullptr){
            if (aux->pasajeros->tamanio < 10){
                aux->pasajeros->push(pasajero);
                if (aux->pasajeros->cabeza->pasajero.toString() == pasajero.toString()){
                    for(int i =1; i <= pasajero.getDocumento(); i++){
                        aux->documentos->apilar(i);
                    }

                }
                return;
            }
            aux = aux->siguiente;
        }
        cout << "Escritorios LLenos espere en la cola" << endl;
    }else{
        cout << "Vacio DX" << endl;
    }
}

void Desktops::finalizarRegistro(int &num)
{
    if (this->listadesktop->primero != nullptr){
        Escritorios *aux = this->listadesktop->primero;
        while(aux != nullptr){
            if (aux->pasajeros->cabeza != nullptr){
                if (aux->pasajeros->cabeza->pasajero.getTurnos() < 1){
                    Nodo *passs = aux->pasajeros->pop();
                    num = passs->pasajero.getMaletas();
                    passs = nullptr;
                    delete passs;
                    aux->documentos->eliminar();
                    if (aux->pasajeros->cabeza != nullptr){
                        for(int i =1; i <= aux->pasajeros->cabeza->pasajero.getDocumento(); i++){
                            aux->documentos->apilar(i);
                        }

                        int t = aux->pasajeros->cabeza->pasajero.getTurnos();
                        aux->pasajeros->cabeza->pasajero.setTurnos(--t);
                    }

                }else{
                    int t = aux->pasajeros->cabeza->pasajero.getTurnos();
                    num = 0;
                    aux->pasajeros->cabeza->pasajero.setTurnos(--t);
                }
            }else {
                cout << "Vacio Pasajero" << endl;
            }
            aux = aux->siguiente;
        }
    }else {
        cout << "Vacio DXAAAAAA" << endl;
    }
}


void Desktops::recorrer()
{
    if (this->listadesktop->primero != nullptr){
        Escritorios *aux = this->listadesktop->primero;
        while (aux != nullptr){
            cout << aux->desk << endl;
            aux->pasajeros->recorrer();
            aux->documentos->recorrer();
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !! " << endl;
    }
}

void Desktops::grafoEscritorio()
{

    string grafo = "digraph g{\n";
    grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
    grafo += "\t edge[color=black];\n";
    grafo += "\t subgraph ColaEscritorios{\n";
    grafo += "\t node[style=filled];\n";
    this->cadenaEscritorio(grafo);
    grafo += "\t}\n";
    grafo += "}\n";
    ofstream archivo("grafoEscritorios.dot");
    archivo << grafo;
    archivo.close();
    system("dot -Tpng grafoEscritorios.dot -o grafoEscritorios.png");

}

void Desktops::cadenaEscritorio(string &graph)
{
    if(this->listadesktop->primero != nullptr){
        Escritorios *esc = this->listadesktop->primero;
        int contador= 0;
        Escritorios *escaux = this->listadesktop->primero;
        graph += "{rank=min;\"ESCRITORIO\";";
        while(escaux != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(escaux);
                direccion = ostm.str();
            }
            graph+= direccion+";";
            escaux = escaux->siguiente;
        }
        graph+="\n};\n";
        while(esc->siguiente != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(esc);
                direccion = ostm.str();
            }
            std::string direccionSig;
            {
                std::ostringstream ostmS;
                ostmS << reinterpret_cast<std::uintptr_t>(esc->siguiente);
                direccionSig = ostmS.str();
            }

            if (esc->anterior != nullptr){

                std::string direccionAnt;
                {
                    std::ostringstream ostmA;
                    ostmA << reinterpret_cast<std::uintptr_t>(esc->anterior);
                    direccionAnt = ostmA.str();
                }
                graph += "\t\t "+direccionAnt+"[label=\""+esc->anterior->desk+"\"];\n";
                graph+= "\t\t "+ direccion + " -> "+direccionAnt+";\n";
            }

            graph+= "\t\t "+ direccion+ "[label=\""+esc->desk+"\"];\n";
            graph+= "\t\t "+ direccionSig+ "[label=\""+esc->siguiente->desk+"\"];\n";
            graph+= "\t\t "+ direccion + " -> "+direccionSig+";\n";

            if (esc->pasajeros->cabeza != nullptr){
                std::string direccionCP;
                {
                    std::ostringstream ostmCP;
                    ostmCP << reinterpret_cast<std::uintptr_t>(esc->pasajeros->cabeza);
                    direccionCP = ostmCP.str();
                }
                graph+= "\t\t "+ direccion + " -> "+direccionCP+";\n";


            }
            graph+= "\t\t subgraph "+direccion+to_string(contador)+"{\n";
            esc->pasajeros->cadenaPasajero(graph);
            graph+= "\t\t }\n";
            esc = esc->siguiente;
            contador++;
        }

        if (esc->siguiente == nullptr && esc->anterior != nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(esc);
                direccion = ostm.str();
            }
            std::string direccionAnt;
            {
                std::ostringstream ostmS;
                ostmS << reinterpret_cast<std::uintptr_t>(esc->anterior);
                direccionAnt = ostmS.str();
            }


            graph+= "\t\t "+ direccion+ "[label=\""+esc->desk+"\"];\n";
            graph+= "\t\t "+ direccionAnt+ "[label=\""+esc->anterior->desk+"\"];\n";
            graph+= "\t\t "+ direccion + " -> "+direccionAnt+";\n";

            if (esc->pasajeros->cabeza != nullptr){
                std::string direccionCP;
                {
                    std::ostringstream ostmCP;
                    ostmCP << reinterpret_cast<std::uintptr_t>(esc->pasajeros->cabeza);
                    direccionCP = ostmCP.str();
                }
                graph+= "\t\t "+ direccion + " -> "+direccionCP+";\n";
            }

            graph+= "\t\t subgraph "+direccion+to_string(this->listadesktop->tamanioE)+"{\n";
            esc->pasajeros->cadenaPasajero(graph);
            graph+= "\t\t }\n";

        }else if (esc->siguiente == nullptr && esc->anterior == nullptr){
            std::string direccion;
            {
                std::ostringstream ostm;
                ostm << reinterpret_cast<std::uintptr_t>(esc);
                direccion = ostm.str();
            }

            graph+= "\t\t "+ direccion+ "[label=\""+esc->desk+"\"];\n";

            if (esc->pasajeros->cabeza != nullptr){
                std::string direccionCP;
                {
                    std::ostringstream ostmCP;
                    ostmCP << reinterpret_cast<std::uintptr_t>(esc->pasajeros->cabeza);
                    direccionCP = ostmCP.str();
                }
                graph+= "\t\t "+ direccion + " -> "+direccionCP+";\n";
                graph+= "\t\t subgraph "+direccion+"0"+"{\n";
                esc->pasajeros->cadenaPasajero(graph);
                graph+= "\t\t }\n";
            }

        }
    }else{
        graph +="Vacio DX";
    }
}



Mantenimiento::Mantenimiento(int numero)
{
    this->numero = numero;
    this->avionesM = new Cola();
    this->siguiente = nullptr;
}

ListaMantenimiento::ListaMantenimiento()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
}

void ListaMantenimiento::insertar(int numero)
{
    Mantenimiento *nuevo = new Mantenimiento(numero);
    if (this->primero == nullptr){
        this->primero = nuevo;
        this->ultimo = nuevo;
    }else{
        this->ultimo->siguiente = nuevo;
        this->ultimo = nuevo;
    }
}

void ListaMantenimiento::insertarA(Avion avion, int numero)
{
    if (this->primero != nullptr){
        Mantenimiento *busca = this->buscarM(numero);
        if (busca != nullptr){
            busca->avionesM->pushA(avion);
        }else{
            cout<<"No se encontro la estacion !!" << endl;
        }
    }else{
        cout<<"Vacios!!" << endl;
    }

}

Mantenimiento *ListaMantenimiento::buscarM(int numero)
{
    if (this->primero != nullptr){
        Mantenimiento *buscar = this->primero;
        while(buscar != nullptr){
            if(buscar->numero == numero){
                return buscar;
            }
            buscar = buscar->siguiente;
        }
    }
    return nullptr;
}

void ListaMantenimiento::recorrer()
{
    if(this->primero != nullptr){
        Mantenimiento *aux = this->primero;
        while(aux != nullptr){
            cout << to_string(aux->numero) << endl;
            aux->avionesM->recorrerA();
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !!" << endl;
    }
}
