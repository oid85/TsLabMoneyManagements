using System;

namespace Centaur.MoneyManagements
{
    public class MaxPercentRisk
    {
        private readonly double _money;
        private readonly double _percent;
        private readonly double _margin;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <param name="stop">Размер стопа (цена входа минус цена стопа)</param>
        /// <param name="lotSize">Размер лота</param>
        /// <returns></returns>
        public int GetShares(double stop, int lotSize)
        {
            double result = _percent * (_money / 100.0) / stop;

            if (result * _margin > _money) // Если недостаточно капитала
                result = _money / _margin;

            result /= lotSize;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Текущее значение риска
        /// </summary>
        /// <param name="money">Текущий размер депозита</param>
        /// <param name="levelStop">Текущий уровень стопа</param>
        /// <param name="curPrice">Текущая цена</param>
        /// <param name="lots">Количество лотов в позиции</param>
        /// <returns></returns>
        public double GetRisk(double money, double levelStop, double curPrice, double lots)
        {
            return Math.Abs(curPrice - levelStop) / money * 100.0 * lots;
        }

        /// <summary>
        /// Метод управления размером позиции MaxPercentRisk
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="percent">Параметр метода управления размером позиции</param>
        /// <param name="margin">Гарантийное обеспечение</param>
        public MaxPercentRisk(double money, double percent, double margin)
        {
            _money = money;
            _percent = percent;
            _margin = margin;
        }
    }
}
