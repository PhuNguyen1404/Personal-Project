#include "encryption.h"
#include <fstream>
#include <cctype>
#include <iostream>

using namespace std;

// Perform Caesar Cipher
bool performCaesarCipher(string &content, bool encrypted, int shift)
{
    shift = encrypted ? shift : -shift;
    for (char &ch : content)
    {
        if (isalpha(ch))
        {
            char base = isupper(ch) ? 'A' : 'a';
            ch = static_cast<char>((ch - base + shift + 26) % 26 + base);
        }
    }
    return true;
}

// Perform Atbash Cipher
bool performAtbashCipher(string &content)
{
    for (char &ch : content)
    {
        if (isalpha(ch))
        {
            char base = isupper(ch) ? 'A' : 'a';
            ch = base + ('Z' - ch);
        }
    }
    return true;
}

// Perform Vigenère Cipher
bool performVigenereCipher(string &content, bool encrypted, const string &key)
{
    int keyLength = key.length();
    int j = 0; // key index

    for (char &ch : content)
    {
        if (isalpha(ch))
        {
            char base = isupper(ch) ? 'A' : 'a';
            int shift = (key[j % keyLength] - base) * (encrypted ? 1 : -1);
            ch = static_cast<char>((ch - base + shift + 26) % 26 + base);
            j++;
        }
    }
    return true;
}

bool encryptFile(const string &filename, bool encrypted, char cipherType, int shift, const string &vigenereKey)
{
    // Open the file
    ifstream inFile(filename);
    if (!inFile)
    {
        return false;
    }

    // Read the file contents
    string content((istreambuf_iterator<char>(inFile)), {});
    inFile.close();

    // Choose the cipher type
    switch (cipherType)
    {
    case '1': // Caesar Cipher
        if (!performCaesarCipher(content, encrypted, shift))
        {
            return false;
        }
        break;
    case '2': // Atbash Cipher
        if (!performAtbashCipher(content))
        {
            return false;
        }
        break;
    case '3': // Vigenère Cipher
        if (!performVigenereCipher(content, encrypted, vigenereKey))
        {
            return false;
        }
        break;
    default:
        cerr << "ERROR: Invalid cipher type!" << endl;
        return false;
    }

    // Create an output file and write the modified content
    ofstream outFile(encrypted ? "encrypted_" + filename : "decrypted_" + filename);
    if (!outFile)
    {
        return false;
    }

    outFile << content;
    outFile.close();

    return true;
}
