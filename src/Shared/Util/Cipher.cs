using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Shared.Util
{
    public class Cipher
    {
        private IntPtr m_hCryptProv = IntPtr.Zero;
        private IntPtr m_hHash = IntPtr.Zero;
        private static IntPtr m_hKey = IntPtr.Zero;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptAcquireContext(ref IntPtr phProv, string pszContainer, string pszProvider, uint dwProvType, uint dwFlags);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptCreateHash(IntPtr hProv, uint Algid, IntPtr hKey, uint dwFlags, ref IntPtr phHash);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptHashData(IntPtr hHash, byte[] pbData, int dwDataLen, uint dwFlags);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptDeriveKey(IntPtr hProv, uint Algid, IntPtr hBaseData, uint dwFlags, ref IntPtr phKey);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptDecrypt(IntPtr hKey, IntPtr hHash, bool final, uint dwFlags, byte[] pbData, ref int pdwDataLen);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptDestroyHash(IntPtr hHash);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptDestroyKey(IntPtr hKey);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool CryptReleaseContext(IntPtr hProv, uint dwFlags);

        public static bool Decrypt(byte[] pData, string Password, int dwDataSize)
        {
            IntPtr p_m_hCryptProv = IntPtr.Zero;
            IntPtr p_m_hHash = IntPtr.Zero;

            if (!CryptAcquireContext(ref p_m_hCryptProv, null, "Microsoft Enhanced Cryptographic Provider v1.0", 1, 8) &&
                !CryptAcquireContext(ref p_m_hCryptProv, null, "Microsoft Enhanced Cryptographic Provider v1.0", 1, 0))
            {
                return false;
            }

            if (!CryptCreateHash(p_m_hCryptProv, 0x8003, IntPtr.Zero, 0, ref p_m_hHash) ||
                !CryptHashData(p_m_hHash, Encoding.ASCII.GetBytes(Password), Encoding.ASCII.GetByteCount(Password), 0) ||
                !CryptDeriveKey(p_m_hCryptProv, 0x6801, p_m_hHash, 1, ref m_hKey) ||
                !CryptDecrypt(m_hKey, IntPtr.Zero, true, 0, pData, ref dwDataSize))
            {
                return false;
            }

            if (p_m_hHash != IntPtr.Zero)
            {
                CryptDestroyHash(p_m_hHash);
            }

            if (m_hKey != IntPtr.Zero)
            {
                CryptDestroyKey(m_hKey);
            }

            if (p_m_hCryptProv != IntPtr.Zero)
            {
                CryptReleaseContext(p_m_hCryptProv, 0);
            }

            return true;
        }
    }
}
