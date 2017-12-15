#ifndef CONSOLA_H
#define CONSOLA_H

#include <QDialog>

namespace Ui {
class Consola;
}

class Consola : public QDialog
{
    Q_OBJECT

public:
    explicit Consola(QWidget *parent = 0);
    ~Consola();

private:
    Ui::Consola *ui;
};

#endif // CONSOLA_H
