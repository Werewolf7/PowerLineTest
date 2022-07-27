using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerLineTest.Cars.CarsEnums;

namespace PowerLineTest.Cars
{
    internal class CargoCar : Car
    {
        #region Поля
        /// <summary>
        /// Текущая загрузка машины
        /// </summary>
        private uint _loadCapacity;
        #endregion

        #region Свойства
        /// <summary>
        /// Тип машины
        /// </summary>
        public override TypeCars Type { get; } = TypeCars.Cargo;
        /// <summary>
        /// Предельная загрузка в кг
        /// </summary>
        public uint PossibleLoadCapacity { get; set; } = default(uint);
        public uint LoadCapacity
        {
            get { return _loadCapacity; }
            set
            {
                if (value > PossibleLoadCapacity)
                {
                    Console.WriteLine("Невозможно загрузить такое кол-во груза в машину");
                }
                else
                {
                    _loadCapacity = value;
                }
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="loadCapacity">Текущая загрузка</param>
        /// <param name="possibleLoadCapacity">Возможное кол-во груза в кг</param>
        /// <param name="averageFuelConsumption">Средний расход</param>
        /// <param name="tankCapacity">Объем бака</param>
        /// <param name="currentFuelQuantity">Текущее кол-во топлива</param>
        /// <param name="speed">Скорость</param>
        public CargoCar(
            uint loadCapacity, 
            uint possibleLoadCapacity, 
            double averageFuelConsumption,
            double tankCapacity,
            double currentFuelQuantity,
            double speed)
        {
            LoadCapacity = loadCapacity;
            PossibleLoadCapacity = possibleLoadCapacity;
            AverageFuelConsumption = averageFuelConsumption;
            TankCapacity = tankCapacity;
            CurrentFuelQuantity = currentFuelQuantity;
            Speed = speed;
        }
        /// <summary>
        /// Расчёт запаса хода с учётом загрузки
        /// </summary>
        /// <param name="cargoKg">Загрузка в кг</param>
        /// <returns></returns>
        public override double CalculationPowerReserveWithLoad(uint cargoKg)
        {
            double reducingPowerReserve = cargoKg / 200 * 0.04;
            double currentPowerReserve = CalculationPowerReservePure(CarsEnums.FuelQuantity.OnRemainder);
            return currentPowerReserve - (currentPowerReserve * reducingPowerReserve);
        }
        #endregion
    }
}
