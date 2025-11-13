using System.Collections.Generic;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class ProducerRepository
    {
        private readonly string _file;

        public ProducerRepository()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                 "DataFiles", "Producers", "producers.csv");
        }

        public List<Producer> GetAll()
        {
            if (!File.Exists(_file))
                return new List<Producer>();

            return File.ReadAllLines(_file)
                .Skip(1)
                .Select(l => l.Split(','))
                .Where(p => p.Length >= 8)
                .Select(p => new Producer
                {
                    ProducerId = p[0],
                    ProducerCode = p[1],
                    NationalId = p[2],
                    Name = p[3],
                    Email = p[4],
                    Phone = p[5],
                    MarketId = p[6],
                    UserId = p[7]
                })
                .ToList();
        }
    }
}
