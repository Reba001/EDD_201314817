#include "listas.h"


Listas::Listas()
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

void Listas::insertarS(int numero)
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

void Listas::insertarD(int numero)
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

void Listas::insertarC(int numero)
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

void Listas::insertarDEsc(char esc)
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

void Listas::insertarSD(int numero)
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

void Listas::insertarDD(int numero)
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

void Listas::insertarCD(int numero)
{
    Nodo *nuevo = new Nodo(numero);
    if(this->cabezaC == nullptr)
    {
        nuevo->izquierda = nuevo;
        nuevo->derecha = nuevo;
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

void Listas::recorrerS()
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

void Listas::recorrerD()
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

void Listas::recorrerC()
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

void Listas::eliminarS(int numero)
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

void Listas::eliminarD(int numero)
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

void Listas::eliminarC(int numero)
{
    if(this->cabezaC != nullptr)
    {
        if (this->cabezaC->numero == numero){
            if (this->cabezaC->siguiente != this->cabezaC){
                Nodo *aux = this->cabezaC;
                this->cabezaC = this->cabezaC->siguiente;
                delete aux;
            }else{
                delete this->cabezaC;
            }
        }else{
            Nodo *aux = this->cabezaC;
            do{
                if (aux->numero == numero){
                    aux->anterior->siguiente = aux->siguiente;
                    aux->siguiente->anterior = aux->anterior;
                    delete aux;
                    this->tamanioC--;
                    return;
                }
                aux = aux->siguiente;

            }while(aux->siguiente != this->cabezaC);

            if (aux->siguiente == this->cabezaC && aux->numero == numero){
                aux->anterior->siguiente = this->cabezaC;
                this->colaC = aux->anterior;
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

Nodo::Nodo()
{


}

Nodo::Nodo(int numero)
{
    this->numero;
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->arriba = nullptr;
    this->abajo = nullptr;
}

Nodo::Nodo(Pasajero pasajero)
{
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
    this->cabeza = nullptr;
    this->tamanio = 0;
}

Nodo * Cola::pop()
{
    if (this->cabeza != nullptr){
        if (this->cabeza->siguiente != nullptr){
            Nodo *aux = this->cabeza;
            this->cabeza = this->cabeza->siguiente;
            aux->siguiente = nullptr;
            this->tamanio--;
            return aux;
        }else{
            aux = this->cabeza;
            this->cabeza = nullptr;
            this->tamanio--;
            return aux;
        }
    }
    cout << "Vacio DX !! " << endl;
    return nullptr;
}

void Cola::recorrer()
{
    if(this->cabeza != nullptr){
        Nodo * aux = this->cabeza;
        while (aux != nullptr){
            cout << "Pila : " << aux->pasajero.toString() << endl ;
            aux = aux->siguiente;
        }
    }else{
        cout << "Vacio DX !!" << endl;
    }
}

void Cola::push(Pasajero pasajero)
{
    Nodo *nuevo = new Nodo(pasajero);
    if (this->cabeza = nullptr){
        this->cabeza = nuevo;
        this->cola = nuevo;
    }else{
        this->cola->siguiente = nuevo;
        this->cola = nuevo;
    }
    this->tamanio++;
}

Escritorios::Escritorios()
{
    this->Desk = new Listas();
    this->pasajero = nullptr;
    this->documents = nullptr;
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
        Nodo *aux = this->cabeza;
        this->cabeza = this->cabeza->siguiente;
        this->cabeza->anterior = nullptr;
        delete aux;

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
    delete this->cabeza;
}

Escritorios::Escritorios(char desk)
{
    this->desk = desk;
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->documentos = nullptr;
    this->pasajeros = nullptr;
}

ListaEscritorio::ListaEscritorio()
{
    this->primero = nullptr;
}

void ListaEscritorio::insertar(Escritorios *desktop)
{
    if (this->primero == nullptr){
        this->primero = desktop;
        this->ultimo = desktop;
    }else{
        this->ultimo->siguiente = desktop;
        desktop->anterior = this->ultimo;
        this->ultimo = desktop;
    }
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


