#include "AES.h"

AES_method::AES_method() {
    AutoSeededRandomPool prng;
    key.resize(AES::DEFAULT_KEYLENGTH);
    iv.resize(AES::BLOCKSIZE);
    prng.GenerateBlock(key, key.size());
    prng.GenerateBlock(iv, iv.size());
}

void AES_method::setKey(const SecByteBlock& key) {
    this->key = key;
}

void AES_method::setIV(const SecByteBlock& iv) {
    this->iv = iv;
}

string AES_method::encrypt(const string& plaintext) {
    string ciphertext;
    CBC_Mode<AES>::Encryption encryptor;
    encryptor.SetKeyWithIV(key, key.size(), iv);

    StringSource(plaintext, true,
        new StreamTransformationFilter(encryptor,
            new StringSink(ciphertext)
        )
    );

    return ciphertext;
}

string AES_method::decrypt(const string& ciphertext) {
    string recovered;
    CBC_Mode<AES>::Decryption decryptor;
    decryptor.SetKeyWithIV(key, key.size(), iv);

    StringSource(ciphertext, true,
        new StreamTransformationFilter(decryptor,
            new StringSink(recovered)
        )
    );

    return recovered;
}