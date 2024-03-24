using System;

namespace Centaur.MoneyManagements
{
    public class PercentOfEquity
    {
        private readonly double _money;
        private readonly double _percent;
        private readonly double _unitSize;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <returns></returns>
        /// <param name="lotSize">Размер лота</param>
        public int GetShares(int lotSize)
        {
            double result = _money * (_percent / 100.0) / _unitSize;

            result /= lotSize;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Метод управления размером позиции PercentOfEquity
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="percent">Параметр метода управления размером позиции</param>
        /// <param name="price">Гарантийное обеспечение или цена инструмента</param>
        public PercentOfEquity(double money, double percent, double price)
        {
            _money = money;
            _percent = percent;
            _unitSize = price;
        }
    }
}
