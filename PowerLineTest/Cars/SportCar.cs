using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerLineTest.Cars.CarsEnums;

namespace PowerLineTest.Cars
{
    internal class SportCar : Car
    {
        #region Свойства
        /// <summary>
        /// Тип машины
        /// </summary>
        public override TypeCars Type { get; } = TypeCars.Sport;
        #endregion

        #region Методы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="averageFuelConsumption">Средний расход</param>
        /// <param name="tankCapacity">Объем бака</param>
        /// <param name="currentFuelQuantity">Текущее кол-во топлива</param>
        /// <param name="speed">Скорость</param>
        public SportCar(
            double averageFuelConsumption,
            double tankCapacity,
            double currentFuelQuantity,
            double speed)
        {
            AverageFuelConsumption = averageFuelConsumption;
            TankCapacity = tankCapacity;
            CurrentFuelQuantity = currentFuelQuantity;
            Speed = speed;
        }
        #endregion
    }
}
