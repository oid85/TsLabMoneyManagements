using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Centaur.MoneyManagements
{
    public class Pyramid
    {
        private double _money;
        private double _deltaMoney;
        private double _deltaPos;

        /// <summary>
        /// Размер позиции
        /// </summary>
        /// <param name="lotSize">Размер лота</param>
        /// <returns></returns>
        public int GetShares(int lotSize)
        {
            double result = Math.Floor(_money / _deltaMoney) * _deltaPos;

            result /= lotSize;

            result = Math.Floor(result);

            result = Math.Max(result, 1.0);

            return Convert.ToInt32(result);
        }

        [Test]
        public void GetSharesTest()
        {
            _deltaMoney = 5000.0;
            _deltaPos = 1.0;

            _money = 6000.0;
            Assert.IsTrue(GetShares(1) == 1);

            _money = 11000.0;
            Assert.IsTrue(GetShares(1) == 2);

            _money = 16000.0;
            Assert.IsTrue(GetShares(1) == 3);

            _money = 21000.0;
            Assert.IsTrue(GetShares(1) == 4);

            _money = 26000.0;
            Assert.IsTrue(GetShares(1) == 5);

            _deltaMoney = 5000.0;
            _deltaPos = 2.0;

            _money = 6000.0;
            Assert.IsTrue(GetShares(1) == 2);

            _money = 11000.0;
            Assert.IsTrue(GetShares(1) == 4);

            _money = 16000.0;
            Assert.IsTrue(GetShares(1) == 6);

            _money = 21000.0;
            Assert.IsTrue(GetShares(1) == 8);

            _money = 26000.0;
            Assert.IsTrue(GetShares(1) == 10);
        }

        /// <summary>
        /// Метод управления размером позиции Pyramid
        /// </summary>
        /// <param name="money">Деньги, выделенные системе</param>
        /// <param name="deltaMoney">Увеличение депозита для увеличения размера позиции</param>
        /// <param name="deltaPos">Шаг увеличения размера позиции</param>
        public Pyramid(double money, double deltaMoney, double deltaPos)
        {
            _money = money;
            _deltaMoney = deltaMoney;
            _deltaPos = deltaPos;
        }

        /// <summary>
        /// Конструктор для тестов
        /// </summary>
        public Pyramid()
        {

        }
    }
}
