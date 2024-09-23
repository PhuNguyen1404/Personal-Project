#include "encryption.h"
#include <fstream>
#include <cctype>

using namespace std;

bool performCeaserCipher(string &content, bool encrypted)
{
    int shift = encrypted ? 3 : -3;

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

bool encryptFile(const string& filename, bool encrypted)
{
    // open the file
    ifstream inFile(filename);
    if (!inFile)
    {
        return false;
    }

    // read the file contents

    string content((istreambuf_iterator<char>(inFile)), {});
    inFile.close();

    if (performCeaserCipher(content, encrypted))
    {
        // create an output file and write the modified content
        ofstream outFile(encrypted ? "encrypted_" + filename : "encrypted_" + filename);

        if (!outFile)
        {
            return false;
        }

        outFile << content;

        outFile.close();

        return true;
    }

}
