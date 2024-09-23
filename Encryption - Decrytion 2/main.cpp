#include <iostream>
#include "Encrypt_Manager.h"

using namespace std;
using namespace CryptoPP;

int main() {
    EncryptionManager manager;
    string filename, algorithm, action;

    cout << "Enter filename: ";
    cin >> filename;

    cout << "Enter algorithm (AES, RSA, DES): ";
    cin >> algorithm;

    cout << "Enter action (encrypt/decrypt): ";
    cin >> action;

    if (action == "encrypt") {
        manager.encryptFile(filename, algorithm);
    }
    else if (action == "decrypt") {
        manager.decryptFile(filename, algorithm);
    }
    else {
        cerr << "Invalid action." << endl;
    }

    return 0;
}