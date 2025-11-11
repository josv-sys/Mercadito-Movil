using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO; // TextFieldParser
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// CSV repository using TextFieldParser and quoted fields.
    /// </summary>
    public sealed class CsvUserRepository : IUserRepository
    {
        private readonly string _csvPath;

        private const string Header =
            "UserId,Username,Password,FirstName,LastName1,LastName2,NationalId,Email,Phone,ExactAddress,Province,Canton,District,MarketId";

        /// <summary>
        /// Builds repository with CSV path.
        /// </summary>
        public CsvUserRepository(string csvPath)
        {
            _csvPath = csvPath ?? throw new ArgumentNullException(nameof(csvPath));
        }

        /// <summary>
        /// Sequential scan by username.
        /// </summary>
        public User? GetByUsername(string username)
        {
            if (!File.Exists(_csvPath)) return null;

            using var parser = new TextFieldParser(_csvPath, Encoding.UTF8);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            // Skip header
            if (!parser.EndOfData) _ = parser.ReadLine();

            while (!parser.EndOfData)
            {
                string[]? fields;
                try { fields = parser.ReadFields(); }
                catch { continue; }

                if (fields is null || fields.Length < 14) continue;

                var u = new User(
                    fields[0], fields[1], fields[2], fields[3], fields[4], fields[5],
                    fields[6], fields[7], fields[8], fields[9], fields[10], fields[11], fields[12], fields[13]);

                if (string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
                    return u;
            }

            return null;
        }

        /// <summary>
        /// Appends user row creating file and header when needed.
        /// </summary>
        public bool Add(User user, out string error)
        {
            try
            {
                EnsureFile();

                using var stream = new FileStream(_csvPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                using var writer = new StreamWriter(stream, new UTF8Encoding(false));

                var line = string.Join(",",
                    Q(user.UserId),
                    Q(user.Username),
                    Q(user.Password),
                    Q(user.FirstName),
                    Q(user.LastName1),
                    Q(user.LastName2),
                    Q(user.NationalId),
                    Q(user.Email),
                    Q(user.Phone),
                    Q(user.ExactAddress),
                    Q(user.Province),
                    Q(user.Canton),
                    Q(user.District),
                    Q(user.MarketId));

                writer.WriteLine(line);
                error = string.Empty;
                return true;
            }
            catch (IOException ioEx)
            {
                error = $"Error de E/S al escribir usuarios: {ioEx.Message}";
                return false;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                error = $"Permisos insuficientes para acceder a usuarios: {uaEx.Message}";
                return false;
            }
            catch (Exception ex)
            {
                error = $"Error inesperado al registrar usuario: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Ensures CSV directory and header exist.
        /// </summary>
        private void EnsureFile()
        {
            var dir = Path.GetDirectoryName(_csvPath);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(_csvPath))
            {
                using var s = new FileStream(_csvPath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                using var w = new StreamWriter(s, new UTF8Encoding(false));
                w.WriteLine(Header);
                return;
            }

            using var fs = new FileStream(_csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var r = new StreamReader(fs, Encoding.UTF8, true);
            var first = r.ReadLine();
            if (string.Equals(first, Header, StringComparison.Ordinal)) return;

            var temp = _csvPath + ".tmp";
            using (var w = new StreamWriter(temp, false, new UTF8Encoding(false)))
            {
                w.WriteLine(Header);
                if (first is not null) w.WriteLine(first);
                while (!r.EndOfStream) w.WriteLine(r.ReadLine());
            }
            r.Dispose(); fs.Dispose();
            File.Copy(temp, _csvPath, true);
            File.Delete(temp);
        }

        /// <summary>
        /// Quotes and escapes CSV field.
        /// </summary>
        private static string Q(string value)
        {
            value ??= string.Empty;
            var escaped = value.Replace("\"", "\"\"");
            return $"\"{escaped}\"";
        }
    }
}
