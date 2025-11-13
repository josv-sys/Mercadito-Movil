using System.Collections.Generic;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class MarketRepository
    {
        private readonly string _file;

        public MarketRepository()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                 "DataFiles", "Markets", "markets.csv");
        }

        public List<Feria> GetAll()
        {
            if (!File.Exists(_file))
                return new List<Feria>();

            return File.ReadAllLines(_file)
                .Skip(1)
                .Select(line => line.Split(','))
                .Where(p => p.Length >= 5)
                .Select(p => new Feria
                {
                    MarketId = p[0],
                    MarketName = p[1],
                    Province = p[2],
                    Canton = p[3],
                    District = p[4]
                })
                .ToList();
        }

        public Feria? GetById(string id)
            => GetAll().FirstOrDefault(f => f.MarketId == id);
    }
}
