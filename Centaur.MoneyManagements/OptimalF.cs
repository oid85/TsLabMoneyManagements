using System;

namespace Centaur.MoneyManagements
{
    public class OptimalF
    {
        private readonly double _money;
        private readonly double _optimalF;
        private readonly double _price;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <returns></returns>
        /// <param name="lotSize">Размер лота</param>
        public int GetShares(int lotSize)
        {
            double result = _money * _optimalF / _price;

            result /= lotSize;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Метод управления размером позиции OptimalF
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="optimalF">Оптимальное F</param>
        /// <param name="price">Цена инструмента</param>
        public OptimalF(double money, double optimalF, double price)
        {
            _money = money;
            _optimalF = optimalF;
            _price = price;
        }
    }
}
