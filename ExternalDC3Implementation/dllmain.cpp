#include "pch.h"
#include "dc3.hpp"  // Include the necessary header file
#include <string>

#define EXPORTED_METHOD extern "C" __declspec(dllexport)

EXPORTED_METHOD void GetSuffixArrayFromText(const char* input, int** result, int* length)
{
    std::string str(input);
    std::vector<std::string::size_type> suffArr = dc3::suffixArray(str.cbegin(), str.cend());
    *length = suffArr.size();

    *result = new int[*length];
    for (int i = 0; i < *length; i++)
    {
        (*result)[i] = suffArr[i];
    }
}

EXPORTED_METHOD void FreeMemory(int* ptr)
{
    delete[] ptr;
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}