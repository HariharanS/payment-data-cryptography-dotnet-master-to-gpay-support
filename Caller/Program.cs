using GooglePay.PaymentDataCryptography;
using System;
using System.IO;

namespace Caller
{
    class Program
    {
        // openssl pkcs8 -topk8 -inform PEM -outform DER -in key.pem -nocrypt | base64 | paste -sd "\0" -
        private const string base64PrivateKey = "";

        static void Main(string[] args)
        {
            //load the decrypted payload
            string payload1 = File.ReadAllText("payload1.txt");
            //true -> test, leave empty in prodcde
            var keyProvider = new GoogleKeyProvider(true);

            var parser = new PaymentMethodTokenRecipient("gateway:eway", keyProvider);

            parser.AddPrivateKey(base64PrivateKey);

            var plainText = parser.Unseal(payload1);

            Console.WriteLine(plainText);
        }
    }
}
