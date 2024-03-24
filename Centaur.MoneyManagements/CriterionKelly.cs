using System;

namespace Centaur.MoneyManagements
{
    public class CriterionKelly
    {
        private readonly double _money;
        private readonly double _margin;

        private double _winningProbability;
        private double _winLossRatio;

        private int _winTrades;
        private int _lossTrades;
        private double _winMoney;
        private double _lossMoney;
        private double _koeffKelly;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <param name="lotSize">Размер лота</param>
        /// <returns></returns>
        public int GetShares(int lotSize)
        {
            double result = _money * (_winningProbability - ((1.0 - _winningProbability) / _winLossRatio)) / _margin;
            
            result /= lotSize;

            result *= _koeffKelly;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Метод управления размером позиции MaxPercentRisk
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="margin">Гарантийное обеспечение</param>
        /// <param name="winTrades">Количество прибыльных сделок</param>
        /// <param name="lossTrades">Количество убыточных сделок</param>
        /// <param name="winMoney">Сумма прибылей</param>
        /// <param name="lossMoney">Сумма убытков</param>
        /// <param name="koeffKelly">На какую часть от размера по критерию Келли будем входить в позицию</param>        
        public CriterionKelly(double money, double margin, int winTrades, int lossTrades, double winMoney, double lossMoney, double koeffKelly)
        {
            _money = money;
            _margin = margin;
            _winTrades = winTrades;
            _lossTrades = lossTrades;
            _winMoney = winMoney;
            _lossMoney = lossMoney;
            _koeffKelly = koeffKelly;
            _winningProbability = (double) _winTrades / ((double) _winTrades + (double) _lossTrades); // Доля прибыльных сделок
            _winLossRatio = _winMoney / _lossMoney; // Отношение прибыли к убыткам
        }
    }
}
