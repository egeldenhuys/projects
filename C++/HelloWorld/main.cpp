#include <iostream>

using namespace std;

void PrintLine(string value)
{
    cout << value << endl;
}

void Print(string value)
{
    cout << value;
}

void Act1()
{
    char input;

    // The angry Dog
    PrintLine("Oh no!, and angry dog is approaching you!");
    PrintLine("What do you do?");
    PrintLine("a - Run away like a sissy girl.");
    PrintLine("b - Kick the dog.");
    PrintLine("c - Crap yourself.");
    cin >> input;

    switch (input)
    {
    case 'a':
        PrintLine("You start running like a sissy little girl. Good job.");
        PrintLine("You have outrun the dog.");
        break;

    case 'b':
        PrintLine("You kick the dog so hard it does a back flip.");
        PrintLine("The dog is dead.");
        PrintLine("You receive: (1) Dog skull, (1) Dog Fur, (67) Dog Teeth");
        break;

    case 'c':
        PrintLine("You get so scared you crap on the floor.");
        PrintLine("The dog is disgusted with your foul actions and decides to run away.");
        break;

    default:
        PrintLine("You do not know what is going on, and pee yourself. Good Job.");
        break;
    }

    PrintLine("a - Play again");
    cin >> input;

    if (input == 'a')
        Act1();

}

int main()
{

    string name = "John Mah Bool";

    // Introduction
    PrintLine("Welcome to the lands of Ghortak!");
    PrintLine("What do you say your name is adventurer?");
    cin >> name;

    PrintLine("Welcome " + name);

    Act1();

    return 0;
}
