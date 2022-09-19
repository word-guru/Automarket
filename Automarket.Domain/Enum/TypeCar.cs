using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassegerCar = 0,
        [Display(Name = "Седан")]
        Sedan,
        [Display(Name = "Хэтчбек")]
        MatchBack,
        [Display(Name = "Минивэн")]
        Minivan,
        [Display(Name = "Спортивная машина")]
        SportsCar,
        [Display(Name = "Внедорожник")]
        Suv,
    }
}
