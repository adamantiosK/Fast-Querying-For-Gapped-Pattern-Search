using System.Runtime.InteropServices;

namespace FSGPM.Algo_Helper_Implementations
{
    public static class ExternalImportedCodeFunctions
    {
        private const string dllPath = @"C:\Code\DTU\Thesis\FSGPM\FSGPM\x64\Debug\ExternalDC3Implementation.dll";

        [DllImport(dllPath)]
        private static extern void GetSuffixArrayFromText(string input, out IntPtr result, out int length);

        [DllImport(dllPath)]
        private static extern void FreeMemory(IntPtr ptr);

        public static int[] GetSuffixFromExternalCPlusPlusImplementation(string text)
        {
            GetSuffixArrayFromText(text, out IntPtr result, out int length);

            int[] suffixArray = new int[length];
            Marshal.Copy(result, suffixArray, 0, length);

            FreeMemory(result);

            return suffixArray;
        }
    }
}
