#include "Lista.h"

//implemetancion de las operaciones de la lista

void agregar(List * lista, int valor)
{
    Nodo *nuevo = (Nodo *)malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;
    if (lista->cabeza == NULL)
    {
        lista->cabeza = nuevo;
        lista->cola = nuevo;
    }
    else
    {
        lista->cola->siguiente = nuevo;
        nuevo->anterior = lista->cola;
        lista->cola = nuevo;
    }
}

void recorrer(List *lista)
{
    if (lista->cabeza != NULL)
    {
        Nodo *actual = lista->cabeza;
        while(actual != NULL){
            printf("%d\n", actual->valor);
            actual = actual->siguiente;
        }
    }else{
        printf("Lista Vacia! DX \n");
    }
}

void eliminar(List *lista, int valor)
{
    if (lista->cabeza == NULL){
        printf("Lista Vacia!! DX \n");
    }else {
        if (lista->cabeza->valor == valor){
            if (lista->cabeza->siguiente == NULL){
                lista->cabeza = NULL;
                lista->cola = NULL;
                free(lista->cabeza);
                free(lista->cola);
            }else{
                lista->cabeza = lista->cabeza->siguiente;
                lista->cabeza->anterior = NULL;
                free(lista->cabeza->anterior);
            }
        }else{
            Nodo * aux = lista->cabeza;
            while (aux->siguiente != NULL)
            {
                if (aux->valor == valor)
                {
                    aux->siguiente->anterior = aux->anterior;
                    aux->anterior->siguiente = aux->siguiente;
                    aux->siguiente = NULL;
                    aux->anterior = NULL;
                    aux = NULL;
                    free(aux);
                    return;
                }

                aux = aux->siguiente;
            }
            if (aux->siguiente == NULL && aux->valor == valor)
            {
                lista->cola = aux->anterior;
                lista->cola->siguiente = NULL;
                free(lista->cola->siguiente);

            }else{
                printf("Valor no encontrado \n");
            }

        }

    }

}
