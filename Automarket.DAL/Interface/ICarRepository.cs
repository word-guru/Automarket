using Automarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Interface
{
    public interface ICarRepository : IBaseRepository<Cars>
    {
        Cars GetByName(string name);
    }
}
