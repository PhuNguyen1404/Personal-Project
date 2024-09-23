#include "RSA.h"

RSA_method::RSA_method() {
    generateKeys();
}

void RSA_method::generateKeys() {
    privateKey.GenerateRandomWithKeySize(prng, 3072);
    publicKey = privateKey;
}

string RSA_method::encrypt(const string& plaintext) {
    string ciphertext;
    RSAES_OAEP_SHA_Encryptor encryptor(publicKey);

    StringSource(plaintext, true,
        new PK_EncryptorFilter(prng, encryptor,
            new StringSink(ciphertext)
        )
    );

    return ciphertext;
}

string RSA_method::decrypt(const string& ciphertext) {
    string recovered;
    RSAES_OAEP_SHA_Decryptor decryptor(privateKey);

    StringSource(ciphertext, true,
        new PK_DecryptorFilter(prng, decryptor,
            new StringSink(recovered)
        )
    );

    return recovered;
}