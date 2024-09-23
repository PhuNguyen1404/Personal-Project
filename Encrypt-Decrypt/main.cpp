#include <iostream>
#include <string>
#include "encryption.h"

using namespace std;

int main()
{
    string filename;
    char mode, cipherType;
    int shift = 0;
    string vigenereKey;

    cout << "Enter the file name: ";
    std::getline(cin >> ws, filename);

    cout << "Choose Cipher (1: Caesar, 2: Atbash, 3: Vigenere): ";
    cin >> cipherType;

    if (cipherType == '1')
    {
        cout << "Enter the shift for Caesar Cipher: ";
        cin >> shift;
    }
    else if (cipherType == '3')
    {
        cout << "Enter the key for Vigenère Cipher: ";
        cin >> vigenereKey;
    }

    cout << "Encrypt (e) or Decrypt (d)? ";
    cin >> mode;

    if (mode == 'e' || mode == 'E')
    {
        if (encryptFile(filename, true, cipherType, shift, vigenereKey))
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
        if (encryptFile(filename, false, cipherType, shift, vigenereKey))
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
