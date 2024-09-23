#include "Encrypt_Manager.h"
#include <fstream>
#include <iostream>

using namespace std;
using namespace CryptoPP;

EncryptionManager::EncryptionManager() {}

void EncryptionManager::encryptFile(const string& filename, const string& algorithm) {
    ifstream file(filename, ios::binary);
    if (!file) {
        cerr << "Error opening file: " << filename << endl;
        return;
    }

    string content((istreambuf_iterator<char>(file)), istreambuf_iterator<char>());
    file.close();

    string ciphertext;
    if (algorithm == "AES") {
        ciphertext = aes.encrypt(content);
    }
    else if (algorithm == "RSA") {
        ciphertext = rsa.encrypt(content);
    }
    else if (algorithm == "DES") {
        ciphertext = des.encrypt(content);
    }
    else {
        cerr << "Unsupported algorithm: " << algorithm << endl;
        return;
    }

    ofstream outFile(filename + ".enc", ios::binary);
    outFile.write(ciphertext.data(), ciphertext.size());
    outFile.close();

    cout << "File encrypted successfully." << endl;
}

void EncryptionManager::decryptFile(const string& filename, const string& algorithm) {
    ifstream file(filename, ios::binary);
    if (!file) {
        cerr << "Error opening file: " << filename << endl;
        return;
    }

    string content((istreambuf_iterator<char>(file)), istreambuf_iterator<char>());
    file.close();

    string plaintext;
    if (algorithm == "AES") {
        plaintext = aes.decrypt(content);
    }
    else if (algorithm == "RSA") {
        plaintext = rsa.decrypt(content);
    }
    else if (algorithm == "DES") {
        plaintext = des.decrypt(content);
    }
    else {
        cerr << "Unsupported algorithm: " << algorithm << endl;
        return;
    }

    ofstream outFile(filename + ".dec", ios::binary);
    outFile.write(plaintext.data(), plaintext.size());
    outFile.close();

    cout << "File decrypted successfully." << endl;
}