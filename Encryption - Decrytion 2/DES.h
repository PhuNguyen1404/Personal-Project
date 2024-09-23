#ifndef DES_H
#define DES_H

#include <string>
#include "cryptopp564/des.h"
#include "cryptopp564/modes.h"
#include "cryptopp564/filters.h"
#include "cryptopp564/osrng.h"

using namespace std;
using namespace CryptoPP;

class DES_method {
public:
    DES_method();
    void setKey(const SecByteBlock& key);
    void setIV(const SecByteBlock& iv);
    string encrypt(const string& plaintext);
    string decrypt(const string& ciphertext);

private:
    SecByteBlock key;
    SecByteBlock iv;
};

#endif // DES_H