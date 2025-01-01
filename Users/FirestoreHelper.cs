using Google.Cloud.Firestore;
using System;
using System.IO;

namespace CoordinateTrackerAndClicker.Users
{
    internal static class FirestoreHelper
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""mouse-tracker-and-clicker"",
          ""private_key_id"": ""6765dc70c1122028185c304b2edc4ddee0dc85d6"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDhDiPbOk6SuCqR\n8wn/0IOgIP5m7Fw3KUGThXEyBzHo3f9jr1ssHTotO1L8SWSW563GyRb5DJs9A7U4\nP32+3107QTnZM/rN1+RnvBEQWX6NFmLNxh2ZejOD7i8TybtVYIp7lgbGgfGiDTH9\ngDODSn9iVhrvmYRbtLrgt77nSgtMZ94GQlN+EoVnIecDAk4MdaJP0OkVmMiO6575\nJsV4LUVTWsl+uklsiYFJ5XNjOxh2vMB4XPHBE4byCqldt/3OC43JDDZr1L6Ebc1m\nKHOmsPLFxe70q06MDQx44wvXy+3h/ICc00CjIBhL/tG7r2fiLdAhunaVzwGRPmG2\nEDXzYPGFAgMBAAECggEALR4rFQ+u4d4W9rR9HDJeuPL0XYjkAdD9CwiVBV0I5fDf\nesoUYpcnaxr6C4bhKhmfLntw5hPfaU99fJ3J5UKdS7xLTx6LGMo/yYYb+6WdZ8aF\nn1Ao7fRgMIJHINXv/vFAQf91M0Wovf6cN4CEkz0TpZCyjLc/oCzuzA86L98ZvcKy\nlZtCYQ9doh3rAc55916/mMi6k8BeFoiofFGzb9+QiijPTfNRLCnUUexV+0pryFFs\nYxUBYHQ/gBan/oxPmHN8Q8NfMy6V25bLdwnmEBxtOq8/BG9umzFrcMBdDVM24yHt\n/TY3b1OBG7WBLOpi8ytm1+55cnUA44gfMF3PCOQmUQKBgQD8OputxC5yLpE8Ox8z\nkgs/owdtyPIRMcoUmuWJLeC7bRteevlvb6udDVB+w0ZZycrOdRplnUJ5vfY7/mxg\nPvFJ6I1hqoVsDo7KoJXfwxzBsGqn1FrInyF7ExYeA5Mj6VRHJfaO8ohXCwxnlXeL\nUb0AClye6hZGtjQ0Z6oZIl/7WQKBgQDka4axVTLoEAkv+9Vt+SPXdzoYpg7WA+Le\nFbCp4+0dK5jGkXuZtUKoOAJ4ppypqBlg4XTAJ7iKaln3cl1ucxd7/3G6cx8xrwlN\nJe/ZXI9I4cByxLpEEw0gttTfdJDvBkVRUhIoReLKtZmJj2o98CIOLD981Zhg51qY\nimbxTZreDQKBgBSrzPRpvpC3BkoUYlM8pdVaTBKQRF5qYTBdHXCnpOJXZ8XPeD/M\nvBjL7Yvl/w7+vbM736TyRW9qxRJXoJQmtGmlOGkHq5WWf9dVX9MNz36EMcl9Ws9U\nU08d2lMtYdKwnaqTDujaMZhInISkuD5fvYiSUNLpRlgXOKIO2N7kdU9JAoGAU3QV\nmeSO3Mo/ERDpQWys86PTzf2dngN9d7Zk/S0RDH9JKgMtLVNULzGHdZ0pz7Ji00qL\n5Uid27RPemCGUjwqcFs7qes1kmlo9I7PupJepzoTndrSUtzDBxjFXX6xFSMtYDCk\nAaLG4VjH58JGBqsdRiBUcb94FK9yIhku0yqPUmECgYEA2DNiZPaK2y7YuFkx4XpT\n8YD99Cb5MYbAEzcGYegkIj6LeOR24MHvAgyNgh0TJoySqeNdjqQxd5JEkDtpvYOK\n24Vaec2k0uwYziaATnw5EIf8+VGG2/DQjpZzRekcWjO9fGflfhAKcPMKVAGbUqiw\n+SnzOA31/40OifHLM0jlRDE=\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-2hhws@mouse-tracker-and-clicker.iam.gserviceaccount.com"",
          ""client_id"": ""109883568065326717659"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-2hhws%40mouse-tracker-and-clicker.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        } ";

        static string filePath = "";
        public static FirestoreDb Database { get; private set; }
        public static void SetEnvironmentVariable()
        {
            filePath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filePath, fireconfig);
            File.SetAttributes(filePath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            Database = FirestoreDb.Create("mouse-tracker-and-clicker");
            File.Delete(filePath);
        }
    }
}
