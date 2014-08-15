#include <iostream>
#include "header.h"

using namespace std;

// Variables
string name;

int main()
{
    Intro();
    Dog();
    Door();

    End();
    return 0;
}

void Intro()
{
    PrintLine("Welcome to the lands of Gorktoria!");
    PrintLine("What is your name, adventurer?");

    name = GetInput();
    PrintLine("Welcome " + name);

    PrintLine("");
}

void Dog()
{
    PrintLine("A stray dog sniffs your shoe...");
    PrintLine("A - Walk away like the sissy you are.");
    PrintLine("B - Pat the smelly dog.");
    PrintLine("C - Feed the dirty animal.");
    PrintLine("D - Take a shit.");

    char input = GetInput();

    switch (input)
    {
    case 'a':
        PrintLine("You start running away from the dog");
        PrintLine("The dog gets scared and chews your foot off.");
        PrintLine("You have no foot. Good job.");
        PrintLine("You loose: [1] Foot.");
        break;

    case 'b':
        PrintLine("You bend down and pat the smelly animal");
        PrintLine("It likes you.");
        PrintLine("You now have a dirty dog that follow you.");
        PrintLine("You receive: [1] Dirty Dog");
        break;

    case 'c':
        PrintLine("You take out a knife and cut off your finger.");
        PrintLine("The dog is pleased with your offering.");
        PrintLine("The dog shits out a magical stone.");
        PrintLine("You receive: [1] Magic stone");
        break;

    case 'd':
        PrintLine("You pull down your pants and shit.");
        PrintLine("You now have shit in your underwear. Good job.");

        break;

    default:
        PrintLine("You have no idea how to do that...");
        PrintLine("You pull down your pants and shit.");
        break;
    }

    PrintLine("");

    PrintLine("R - Play scene again");

    input = GetInput();

    if (input == 'r')
        Dog();
}

void Door()
{
        PrintLine("You are at a door");
    PrintLine("A - Knock on the door");
    PrintLine("B - Kick the door down");
    PrintLine("C - Do NOT knock on the door");
    PrintLine("D - Take a shit.");

    char input = GetInput();

    switch (input)
    {
    case 'a':
        PrintLine("You knock on the door and break your face.");
        PrintLine("Good job Mr smarty pants.");
        break;

    case 'b':
        PrintLine("You get angry and kick the door down");
        PrintLine("Inside you find 2 gay people");
        break;

    case 'c':
        PrintLine("You decide to do nothing");
        PrintLine("Well you sure a are boring.");
        break;

    case 'd':
        PrintLine("You put your shit on the door");
        PrintLine("Now it smells like something died here");
        break;

    default:
        PrintLine("You have no idea how to do that...");
        PrintLine("You pull down your pants and shit.");
        break;
    }

    PrintLine("");

	PrintLine("R - Play scene again");

    input = GetInput();

    if (input == 'r')
        Door();
}


char GetInput()
{

    cout << "> ";

    string tmpValue;
    getline(cin, tmpValue);
    PrintLine("");
    return tmpValue[0];

}

void End()
{
    cout << "Press [ENTER] to exit...";
    //cin.clear();
    //cin.ignore(255, '\n');
    cin.get();
}
void PrintLine(string text)
{
    cout << text << endl;
}

void Print(string text)
{
    cout << text;
}
