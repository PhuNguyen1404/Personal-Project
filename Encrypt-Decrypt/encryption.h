#ifndef ENCRYPTION_H
#define ENCRYPTION_H

#include <string>
using namespace std;

bool encryptFile(const string &filename, bool encrypted, char cipherType, int shift, const string &vigenereKey);

#endif
