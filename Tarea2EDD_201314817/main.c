#include <stdio.h>
#include "Lista.h"
#include "stdio.h"
#include "stdlib.h"
void inicio();
void insertar(List *lista);
void elimination(List *lista);
int main()
{
    printf("Hello World!\n");
    inicio();
    return 0;
}

void inicio()
{
    List *lista = (List*)malloc(sizeof(List));
    lista->cabeza = NULL;
    lista->cola = NULL;

    int n=0;
    while(n < 4)
    {
        printf("------------Bienvenido----------\n");
        printf("\t 1. Insertar un numero en la lista\n");
        printf("\t 2. Recorrer la lista\n");
        printf("\t 3. Eliminar un numero de la lista\n");
        printf("\t Seleccione lo que desea hacer ");
        scanf("%d", &n);
        switch (n) {
        case 1:
            insertar(lista);
            break;
        case 2:
            recorrer(lista);
            break;
        case 3:
            elimination(lista);
            break;
        default:
            break;
        }

    }
}

void insertar(List *lista){
    int n;
    printf("\t \t Ingrese un numero a la lista ");
    scanf("%d", &n);
    agregar(lista, n);
    printf("\t \t El valor %d ya que ha ingresado \n", n);

}

void elimination(List *lista){
    int n;
    printf("\t \t Ingrese el numero que desea eliminar ");
    scanf("%d", &n);
    eliminar(lista, n);
    printf("\t \t El numero %d ha sido eliminado... ", n);


}

