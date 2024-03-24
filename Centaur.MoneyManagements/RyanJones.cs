using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Centaur.MoneyManagements
{
    public class RyanJones
    {
        private double _money;
        private List<Tuple<double, double>> _levels;
        private double _deltaMoney;
        private double _deltaPos;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <param name="lotSize">Размер лота</param>
        /// <returns></returns>
        public int GetShares(int lotSize)
        {
            double result = 0.0;

            for (int i = 0; i < _levels.Count - 1; i++)
                if (_money >= _levels[i].Item2 && _money < _levels[i + 1].Item2)
                {
                    result = _levels[i].Item1;
                    break;
                }

            result /= lotSize;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        private void CreateLevels()
        {
            _levels = new List<Tuple<double, double>>();

            _levels.Add(new Tuple<double, double>(1.0, _deltaMoney));

            // Формируем 1000 уровней
            for (int i = 1; i < 1000; i++)
            {
                double shareSize = _levels[i - 1].Item1 + _deltaPos;
                double equityLevel = _levels[i - 1].Item2 + shareSize * _deltaMoney;
                _levels.Add(new Tuple<double, double>(shareSize, equityLevel));
            }
        }

        [Test]
        public void CreateLevelsTest()
        {
            _deltaMoney = 5000.0;
            _deltaPos = 1.0;

            CreateLevels();

            Assert.IsTrue(Math.Abs(_levels[0].Item1 - 1.0) < 0.0001 && Math.Abs(_levels[0].Item2 - 5000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[1].Item1 - 2.0) < 0.0001 && Math.Abs(_levels[1].Item2 - 15000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[2].Item1 - 3.0) < 0.0001 && Math.Abs(_levels[2].Item2 - 30000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[3].Item1 - 4.0) < 0.0001 && Math.Abs(_levels[3].Item2 - 50000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[4].Item1 - 5.0) < 0.0001 && Math.Abs(_levels[4].Item2 - 75000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[5].Item1 - 6.0) < 0.0001 && Math.Abs(_levels[5].Item2 - 105000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[6].Item1 - 7.0) < 0.0001 && Math.Abs(_levels[6].Item2 - 140000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[7].Item1 - 8.0) < 0.0001 && Math.Abs(_levels[7].Item2 - 180000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[8].Item1 - 9.0) < 0.0001 && Math.Abs(_levels[8].Item2 - 225000.0) < 0.0001);
            Assert.IsTrue(Math.Abs(_levels[9].Item1 - 10.0) < 0.0001 && Math.Abs(_levels[9].Item2 - 275000.0) < 0.0001);
        }

        [Test]
        public void GetSharesTest()
        {
            _deltaMoney = 5000.0;
            _deltaPos = 1.0;

            CreateLevels();

            _money = 6000.0;
            Assert.IsTrue(GetShares(1) == 1);

            _money = 16000.0;
            Assert.IsTrue(GetShares(1) == 2);

            _money = 31000.0;
            Assert.IsTrue(GetShares(1) == 3);

            _money = 51000.0;
            Assert.IsTrue(GetShares(1) == 4);

            _money = 76000.0;
            Assert.IsTrue(GetShares(1) == 5);
        }

        /// <summary>
        /// Метод управления размером позиции Pyramid
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="deltaMoney">Увеличение депозита для увеличения размера позиции</param>
        /// <param name="deltaPos">Шаг увеличения размера позиции</param>
        public RyanJones(double money, double deltaMoney, double deltaPos)
        {
            _money = money;
            _deltaMoney = deltaMoney;
            _deltaPos = deltaPos;

            CreateLevels();
        }

        /// <summary>
        /// Конструктор для тестов
        /// </summary>
        public RyanJones()
        {

        }
    }
}
