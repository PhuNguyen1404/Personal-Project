#ifndef RSA_H
#define RSA_H

#include <string>
#include "cryptopp564/rsa.h"
#include "cryptopp564/filters.h"
#include "cryptopp564/osrng.h"

using namespace std;
using namespace CryptoPP;

class RSA_method {
public:
    RSA_method();
    void generateKeys();
    string encrypt(const string& plaintext);
    string decrypt(const string& ciphertext);

private:
    RSA::PrivateKey privateKey;
    RSA::PublicKey publicKey;
    AutoSeededRandomPool prng;
};

#endif // RSA_H