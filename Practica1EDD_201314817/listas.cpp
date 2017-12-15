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

void Desktops::finalizarRegistro(int &numero)
{
    if (this->listadesktop->primero != nullptr){
        Escritorios *aux = this->listadesktop->primero;
        while(aux != nullptr){
            if (aux->pasajeros->cabeza != nullptr){
                if (aux->pasajeros->cabeza->pasajero.getTurnos() < 1){
                    Nodo *passs = aux->pasajeros->pop();
                    numero = passs->pasajero.getMaletas();
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
                    aux->pasajeros->cabeza->pasajero.setTurnos(--t);
                    numero = -1;
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
