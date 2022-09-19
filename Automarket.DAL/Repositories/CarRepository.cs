using Automarket.DAL.Interface;
using Automarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Cars entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cars entity)
        {
            throw new NotImplementedException();
        }

        public Cars Get(int id)
        {
            throw new NotImplementedException();
        }

        public Cars GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cars>> Select()
        {
            return await _db.Car.ToListAsync();
        }
    }
}
