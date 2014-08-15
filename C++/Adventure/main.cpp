#include <iostream>
#include <Windows.h>
#include "stuff.h"

using namespace std;

string name;

int main()
{

    Intro();
    Act1();

    cout << "Press ENTER to end the adventure...";
    cin.clear();
    cin.ignore(255, '\n');
    cin.get();

    return 0;
}

void Intro()
{
    // Get player name and welcome them to the game
    cout << "Welcome to the lands of Gianus traveller!" << endl;
    cout << "What is your name?" << endl;

    cout << "> ";
    getline(cin, name);
    cout << endl;

    cout << "Welcome " << name << endl;
    cout << endl;
}

void Act1()
{
    Print("You see a poor child playing in the street...");
    Print("A - Kick the child");
    Print("B - Give the child your money");
    Print("C - Shit in the child's begging hat");
    Print("D - Steal the child's money");

    cout << "> ";
    char choice = ' ';

    cin >> choice;
    cout << endl;

    switch (choice)
    {
    case 'a':
        Print("You kick the child.");
        Print("Now why the hell did you do that?");
        Print("The child runs away");
        break;

    case 'b':
        Print("You give the child all your money. You poor sod.");
        break;

    case 'c':
        Print("You slowly pull down your pants");
        Print("You push as hard as you can");
        Print("You shit all over the kid and his dead dog.");
        Print("Good Job kind sir!");
        break;

    case 'd':
        Print("The kid has no money to steal, so you shit on him instead.");
        break;

    default:
        Print("You do not know how to do that action.");
        Print("You pull out your penis and swing it wildly");
        Act1();
        break;
    }
    cout << endl;
    Act1();
}

void Print(string text)
{
    cout << text << endl;
}

