using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services
{
    public class AuthService
    {
        private readonly string _rutaUsuarios;

        public AuthService()
        {
            // 🧭 Ruta fija y exacta según tu carpeta real
            _rutaUsuarios = @"D:\escritorio\Tecnicas de Programacion\MercaditoMovil-Story-1.1.2-Authentication-and-Role-Access\MercaditoMovil\MercaditoMovil.Infrastructure\DataFiles\People\users.csv";
            Console.WriteLine($"📁 Buscando archivo en: {_rutaUsuarios}");
        }

        public Usuario? IniciarSesion(string correo, string contrasena)
        {
            if (!File.Exists(_rutaUsuarios))
            {
                Console.WriteLine("❌ No se encontró el archivo users.csv en la ruta especificada.");
                return null;
            }

            using var parser = new TextFieldParser(_rutaUsuarios);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            if (parser.EndOfData)
            {
                Console.WriteLine("⚠️ El archivo está vacío");
                return null;
            }

            var headers = parser.ReadFields() ?? Array.Empty<string>();
            for (int i = 0; i < headers.Length; i++)
                headers[i] = headers[i].Trim('"', ' ').Trim();

            int idxUserId = Array.IndexOf(headers, "UserId");
            int idxEmail = Array.IndexOf(headers, "Email");
            int idxPassword = Array.IndexOf(headers, "Password");
            int idxFirst = Array.IndexOf(headers, "FirstName");
            int idxLast1 = Array.IndexOf(headers, "FirstLastName");
            int idxLast2 = Array.IndexOf(headers, "SecondLastName");

            correo = correo.Trim().ToLower();
            contrasena = contrasena.Trim();

            while (!parser.EndOfData)
            {
                var campos = parser.ReadFields();
                if (campos == null || campos.Length < headers.Length)
                    continue;

                string email = (campos[idxEmail] ?? "").Trim('"', ' ').ToLower();
                string pass = (campos[idxPassword] ?? "").Trim('"', ' ');

                email = email.Replace("\r", "").Replace("\n", "").Trim();
                pass = pass.Replace("\r", "").Replace("\n", "").Trim();

                Console.WriteLine($"📄 Leído -> Email: '{email}' | Password: '{pass}'");

                if (email == correo && pass == contrasena)
                {
                    Console.WriteLine("✅ Coincidencia encontrada");
                    string nombre = $"{campos[idxFirst]} {campos[idxLast1]} {campos[idxLast2]}".Trim();

                    return new Usuario
                    {
                        UserId = campos[idxUserId],
                        Nombre = nombre,
                        Correo = email
                    };
                }
            }

            Console.WriteLine("❌ Ninguna coincidencia encontrada.");
            return null;
        }
    }
}





