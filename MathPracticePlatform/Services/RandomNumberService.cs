using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPracticePlatform.Services
{
    public class RandomNumberService
    {
        private readonly Random _random;

        public RandomNumberService()
        {
            _random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return _random.Next(min, max +1);
        }
    }
}
