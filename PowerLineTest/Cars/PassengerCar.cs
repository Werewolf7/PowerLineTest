using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerLineTest.Cars.CarsEnums;

namespace PowerLineTest.Cars
{
    internal class PassengerCar : Car
    {
        #region Поля
        /// <summary>
        /// Кол-во пассажиров в машине
        /// </summary>
        private uint _passengers;
        #endregion

        #region Свойства
        /// <summary>
        /// Тип машины
        /// </summary>
        public override TypeCars Type { get; } = TypeCars.Passenger;
        /// <summary>
        /// Возможно число пассажиров
        /// </summary>
        public uint PermissibleNumberPassengers { get; set; } = default(uint);
        public uint Passengers 
        {
            get { return _passengers; }
            set
            {
                if (value > PermissibleNumberPassengers)
                {
                    Console.WriteLine("Столько пассажиров не поместится в данную машину");
                }
                else
                {
                    _passengers = value;
                }
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="passengers">Текущее кол-во пассажиров</param>
        /// <param name="permissibleNumberPassengers">Возможное кол-во пассажиров в машине</param>
        /// <param name="averageFuelConsumption">Средний расход</param>
        /// <param name="tankCapacity">Объем бака</param>
        /// <param name="currentFuelQuantity">Текущее кол-во топлива</param>
        /// <param name="speed">Скорость</param>
        public PassengerCar(
            uint passengers,
            uint permissibleNumberPassengers,
            double averageFuelConsumption,
            double tankCapacity,
            double currentFuelQuantity,
            double speed)
        {
            Passengers = passengers;
            PermissibleNumberPassengers = permissibleNumberPassengers;
            AverageFuelConsumption = averageFuelConsumption;
            TankCapacity = tankCapacity;
            CurrentFuelQuantity = currentFuelQuantity;
            Speed = speed;
        }
        /// <summary>
        /// Расчёт запаса хода с учётом пассажиров
        /// </summary>
        /// <param name="passengers">Кол-во пассажиров</param>
        /// <returns></returns>
        public override double CalculationPowerReserveWithLoad(uint passengers)
        {
            double reducingPowerReserve = passengers * 0.06;
            double currentPowerReserve = CalculationPowerReservePure(CarsEnums.FuelQuantity.OnRemainder);
            return currentPowerReserve - (currentPowerReserve * reducingPowerReserve);
        }
        #endregion
    }
}
