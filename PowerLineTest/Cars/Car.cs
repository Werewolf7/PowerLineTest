using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerLineTest.Cars.CarsEnums;

namespace PowerLineTest.Cars
{
    internal abstract class Car
    {
        #region Свойства
        /// <summary>
        /// Тип машины
        /// </summary>
        public abstract TypeCars Type { get; }
        /// <summary>
        /// Средний расход топлива
        /// </summary>
        public double AverageFuelConsumption { get; set; } = default(double);
        /// <summary>
        /// Объем бака
        /// </summary>
        public double TankCapacity { get; set; } = default(double);
        /// <summary>
        /// Текущее кол-во топлива
        /// </summary>
        public double CurrentFuelQuantity { get; set; } = default(double);
        /// <summary>
        /// Скорость
        /// </summary>
        public double Speed { get; set; } = default(double);
        #endregion

        #region Методы
        /// <summary>
        /// Кол-во км, которое может пройти машина на 1л топлива
        /// </summary>
        /// <returns></returns>
        private double KilometersPerLiter() => 100 / AverageFuelConsumption;

        /// <summary>
        /// Расчёт запаса хода без учетов пассажиров/груза - 'чистый'
        /// </summary>
        /// <param name="fuel">На полном баке/на текущем кол-ве</param>
        /// <returns></returns>
        public virtual double CalculationPowerReservePure(CarsEnums.FuelQuantity fuel)
        {
            double kilometersPerLiter = KilometersPerLiter();
            return fuel switch
            {
                CarsEnums.FuelQuantity.OnFull => kilometersPerLiter * TankCapacity,
                CarsEnums.FuelQuantity.OnRemainder => kilometersPerLiter * CurrentFuelQuantity
            };
        }
        /// <summary>
        /// Расчёт запаса хода с учётом загрузки
        /// </summary>
        /// <param name="load">Загрузка</param>
        /// <returns></returns>
        public virtual double CalculationPowerReserveWithLoad(uint load) 
        { 
            return CalculationPowerReservePure(CarsEnums.FuelQuantity.OnRemainder); 
        }

        /// <summary>
        /// Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет.
        /// </summary>
        /// <param name="fuelQuantity">Кол-во топлива для расчёта</param>
        /// <param name="distanceKm">Дистанция в км</param>
        /// <returns></returns>
        public virtual double TimeOvercomeDistance(double fuelQuantity, double distanceKm)
        {
            //Не совсем понятно зачем нам нужно количество топлива для данного расчёта, кроме как для обработки случая, который ниже в if
            if (KilometersPerLiter() * fuelQuantity < distanceKm)
            {
                Console.WriteLine("Машина не сможет преодолеть данное расстояние, топлива меньше чем требуется для преодоления дистанции");
                return -1;
            }
            return distanceKm / Speed;
        }
        #endregion
    }
}
