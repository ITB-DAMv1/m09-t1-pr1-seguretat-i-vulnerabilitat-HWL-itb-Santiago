using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string hash = "";
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Registro");
            Console.WriteLine("2. Verificación");
            Console.WriteLine("3. Encriptación RSA");
            Console.Write("Selecciona una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    hash = ComputeSha256Hash(username + password);
                    Console.WriteLine("Hash guardado: " + hash);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Username: ");
                    string userVerify = Console.ReadLine();
                    Console.Write("Password: ");
                    string passVerify = Console.ReadLine();
                    string verifyHash = ComputeSha256Hash(userVerify + passVerify);
                    Console.WriteLine(verifyHash == hash ? "Datos correctos" : "Datos incorrectos");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("¿Que texto desea enciptar?");
                    string toRsa = Console.ReadLine();
                    using (RSA rsa = RSA.Create())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(toRsa);
                        byte[] encrypted = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
                        byte[] decrypted = rsa.Decrypt(encrypted, RSAEncryptionPadding.OaepSHA256);
                        Console.WriteLine("Texto encriptado: " + Convert.ToBase64String(encrypted));
                        Console.WriteLine("Texto desencriptado: " + Encoding.UTF8.GetString(decrypted));
                        Console.ReadLine();
                    }
                    break;
            }
        }
    }

    public static string ComputeSha256Hash(string toHash)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(toHash);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}