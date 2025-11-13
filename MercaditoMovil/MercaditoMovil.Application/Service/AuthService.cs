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
            _rutaUsuarios =
                @"C:\Users\Fernando Madriz\Desktop\Story1.2.1–Create-Cart_Structure\MercaditoMovil\MercaditoMovil\MercaditoMovil.Infrastructure\DataFiles\People\users.csv";
        }

        public Usuario? IniciarSesion(string correo, string contrasena)
        {
            if (!File.Exists(_rutaUsuarios))
            {
                // No mostramos MessageBox aquí (capa Application)
                return null;
            }

            using var parser = new TextFieldParser(_rutaUsuarios);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            var headers = parser.ReadFields();
            if (headers == null)
                return null;

            // Normalizar encabezados
            for (int i = 0; i < headers.Length; i++)
                headers[i] = Limpiar(headers[i]);

            // Indices según tu archivo real
            int iUserId = Array.IndexOf(headers, "UserId");
            int iEmail = Array.IndexOf(headers, "Email");
            int iPassword = Array.IndexOf(headers, "Password");
            int iFirst = Array.IndexOf(headers, "FirstName");
            int iLast1 = Array.IndexOf(headers, "FirstLastName");
            int iLast2 = Array.IndexOf(headers, "SecondLastName");
            int iMarket = Array.IndexOf(headers, "MarketId");

            correo = Limpiar(correo).ToLower();
            contrasena = Limpiar(contrasena);

            while (!parser.EndOfData)
            {
                var campos = parser.ReadFields();
                if (campos == null)
                    continue;

                string email = Limpiar(campos[iEmail]).ToLower();
                string pass = Limpiar(campos[iPassword]);

                if (email == correo && pass == contrasena)
                {
                    return new Usuario
                    {
                        UserId = Limpiar(campos[iUserId]),
                        Nombre = $"{Limpiar(campos[iFirst])} {Limpiar(campos[iLast1])} {Limpiar(campos[iLast2])}",
                        Correo = email,
                        MarketId = Limpiar(campos[iMarket])
                    };
                }
            }

            return null;
        }

        private string Limpiar(string s)
        {
            if (s == null) return "";
            return s.Replace("\"", "")
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Trim();
        }
    }
}
