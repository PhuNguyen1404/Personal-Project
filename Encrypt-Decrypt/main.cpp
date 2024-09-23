#include <iostream>
#include <string>
#include "encryption.h"

using namespace std;

int main()
{

    string filename;
    char mode;

    cout << "Enter the file name: ";
    std::getline(cin >> ws, filename);

    cout << "Enccrypt (e) or Decrypt (d)?";
    cin >> mode;

    if (mode == 'e' || mode == 'E')
    {
        if (encryptFile(filename, true))
        {
            cout << "Encrypt " << filename << " successfully" << endl;
        }
        else
        {
            cerr << "ERROR: Cannot encrypt " << filename << endl;
        }
    }
    else if (mode == 'd' || mode == 'D')
    {
        if (encryptFile(filename, false))
        {
            cout << "Decrypt " << filename << " successfully" << endl;
        }
        else
        {
            cerr << "ERROR: Cannot decrypt " << filename << endl;
        }
    }
    else
    {
        cerr << "ERROR: Invalid!" << endl;
    }

    return 0;
}