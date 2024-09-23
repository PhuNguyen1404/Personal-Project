#ifndef ENCRYPTION_MANAGER_H
#define ENCRYPTION_MANAGER_H

#include <string>
#include "AES.h"
#include "RSA.h"
#include "DES.h"

using namespace std;
using namespace CryptoPP;

class EncryptionManager {
public:
    EncryptionManager();
    void encryptFile(const string& filename, const string& algorithm);
    void decryptFile(const string& filename, const string& algorithm);

private:
    AES_method aes;
    RSA_method rsa;
    DES_method des;
};

#endif // ENCRYPTION_MANAGER_H