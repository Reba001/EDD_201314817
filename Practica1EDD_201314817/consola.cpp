#include "consola.h"
#include "ui_consola.h"

Consola::Consola(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Consola)
{
    ui->setupUi(this);
}

Consola::~Consola()
{
    delete ui;
}
