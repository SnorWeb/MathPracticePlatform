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

        public (int number1, int number2) GenerateMultiplicationExercise(int min, int max)
        {
            int number1 = GetRandomNumber(min, max);
            int number2 = GetRandomNumber(min, max);
            return (number1, number2);
        }

        public (int number1, int number2) GenerateDivisionExercise(int min, int max)
        {
            int divisor = GetRandomNumber(1, 10);
            int dividend = divisor * GetRandomNumber(1, 10);

            return(dividend, divisor);
        }


    }
}
