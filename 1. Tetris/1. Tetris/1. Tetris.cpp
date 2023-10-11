#include <iostream>
#include <Windows.h>
#include <conio.h>

using namespace std;

class Figure abstract
{
protected:
    char form[4][4] = { { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
    string color;
    string name;
public:
    virtual void SetForm() = 0;
    virtual void SetColor() = 0;
    virtual void SetName() = 0;

    void Print()
    {
        cout << "Form:" << endl;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
                cout << form[i][j] << form[i][j];
            cout << endl;
        }
        cout << "Color:  " << color << endl;
        cout << "Name:   " << name << endl;
    }
};

class Orange_Ricky : public Figure
{
public:
    void SetForm()
    {
        form[0][0] = char(219);
        form[0][1] = char(219);
        form[0][2] = char(219);
        form[0][3] = char(219);
        form[1][0] = char(219);
    }
    void SetColor()
    {
        color = "Orange";
    }
    void SetName()
    {
        name = "Orange Ricky";
    }
};

class Blue_Ricky : public Figure
{
public:
    void SetForm()
    {
        form[1][0] = char(219);
        form[1][1] = char(219);
        form[1][2] = char(219);
        form[1][3] = char(219);
        form[0][0] = char(219);
    }
    void SetColor()
    {
        color = "Blue";
    }
    void SetName()
    {
        name = "Blue Ricky";
    }
};

class Cleveland_Z : public Figure
{
public:
    void SetForm()
    {
        form[0][0] = char(219);
        form[0][1] = char(219);
        form[1][1] = char(219);
        form[1][2] = char(219);
    }
    void SetColor()
    {
        color = "Red";
    }
    void SetName()
    {
        name = "Cleveland Z";
    }
};

class Rhode_Island_Z : public Figure
{
public:
    void SetForm()
    {
        form[1][0] = char(219);
        form[1][1] = char(219);
        form[0][1] = char(219);
        form[0][2] = char(219);
    }
    void SetColor()
    {
        color = "Green";
    }
    void SetName()
    {
        name = "Rhode Island Z";
    }
};

class Teewee : public Figure
{
public:
    void SetForm()
    {
        form[0][1] = char(219);
        form[1][0] = char(219);
        form[1][1] = char(219);
        form[1][2] = char(219);
    }
    void SetColor()
    {
        color = "Yellow";
    }
    void SetName()
    {
        name = "Teewee";
    }
};

class Hero : public Figure
{
public:
    void SetForm()
    {
        form[0][0] = char(219);
        form[1][0] = char(219);
        form[2][0] = char(219);
        form[3][0] = char(219);
    }
    void SetColor()
    {
        color = "Dark blue";
    }
    void SetName()
    {
        name = "Hero";
    }
};


class Creator abstract
{
public:
    virtual Figure* FactoryMethod() = 0;
};

class Orange_Ricky_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Orange_Ricky();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};

class Blue_Ricky_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Blue_Ricky();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};

class Cleveland_Z_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Cleveland_Z();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};

class Rhode_Island_Z_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Rhode_Island_Z();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};

class Teewee_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Teewee();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};

class Hero_creator : public Creator
{
public:
    Figure* FactoryMethod()override
    {
        Figure* fg = new Hero();
        fg->SetForm();
        fg->SetColor();
        fg->SetName();
        return fg;
    }
};


class Client
{
    Creator* pCreator;

public:
    Client(Creator* c)
    {
        pCreator = c;
    }
    Figure* Create()
    {
        return pCreator->FactoryMethod();
    }
};

void ClientFunc(Creator* pCreator)
{
    Client* client = nullptr;
    client = new Client(pCreator);
    Figure* pFigure = client->Create();
    pFigure->Print();
    delete pFigure;
    delete client;
}

int main()
{
    int choice;
    bool flag = true;

    while (flag == true)
    {
        system("cls");
        cout << "Which figure do you want to create?" << endl;
        cout << "1 - Orange Ricky" << endl;
        cout << "2 - Blue Ricky" << endl;
        cout << "3 - Cleveland_Z" << endl;
        cout << "4 - Rhode Island Z" << endl;
        cout << "5 - Teeweee" << endl;
        cout << "6 - Hero" << endl;
        cout << "0 - Exit" << endl;

        choice = _getch();

        if (choice == '1')
        {
            system("cls");
            Creator* pCreator = new Orange_Ricky_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        if (choice == '2')
        {
            system("cls");
            Creator* pCreator = new Blue_Ricky_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        if (choice == '3')
        {
            system("cls");
            Creator* pCreator = new Cleveland_Z_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        if (choice == '4')
        {
            system("cls");
            Creator* pCreator = new Rhode_Island_Z_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        if (choice == '5')
        {
            system("cls");
            Creator* pCreator = new Teewee_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        if (choice == '6')
        {
            system("cls");
            Creator* pCreator = new Hero_creator();
            ClientFunc(pCreator);
            delete pCreator;
            system("pause");
        }
        else if (choice == '0')
        {
            break;
        }
    }
}

