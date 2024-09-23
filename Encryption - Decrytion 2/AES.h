#ifndef AES_H
#define AES_H

#include <string>
#include "cryptopp564/aes.h"
#include "cryptopp564/modes.h"
#include "cryptopp564/filters.h"
#include "cryptopp564/osrng.h"

using namespace std;
using namespace CryptoPP;

class AES_method {
public:
    AES_method();
    void setKey(const SecByteBlock& key);
    void setIV(const SecByteBlock& iv);
    string encrypt(const string& plaintext);
    string decrypt(const string& ciphertext);

private:
    SecByteBlock key;
    SecByteBlock iv;
};

#endif // !AES_H
