#include "DES.h"

DES_method::DES_method() {
    AutoSeededRandomPool prng;
    key.resize(DES::DEFAULT_KEYLENGTH);
    iv.resize(DES::BLOCKSIZE);
    prng.GenerateBlock(key, key.size());
    prng.GenerateBlock(iv, iv.size());
}

void DES_method::setKey(const SecByteBlock& key) {
    this->key = key;
}

void DES_method::setIV(const SecByteBlock& iv) {
    this->iv = iv;
}

string DES_method::encrypt(const string& plaintext) {
    string ciphertext;
    CBC_Mode<DES>::Encryption encryptor;
    encryptor.SetKeyWithIV(key, key.size(), iv);

    StringSource(plaintext, true,
        new StreamTransformationFilter(encryptor,
            new StringSink(ciphertext)
        )
    );

    return ciphertext;
}

string DES_method::decrypt(const string& ciphertext) {
    string recovered;
    CBC_Mode<DES>::Decryption decryptor;
    decryptor.SetKeyWithIV(key, key.size(), iv);

    StringSource(ciphertext, true,
        new StreamTransformationFilter(decryptor,
            new StringSink(recovered)
        )
    );

    return recovered;
}