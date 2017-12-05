using System.Text;

namespace LuizaEM.Domain.Shared
{
    public static class ValidationPassword
    {
        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var pass = (password += "|A08AC742-AAE4-4A19-8A4F-2845584DA0CE");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.ASCII.GetBytes(pass));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
