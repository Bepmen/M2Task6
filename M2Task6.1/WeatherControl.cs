using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace M2Task6._1
{
    internal class WeatherControl : DependencyObject
    {
        // Объявляем свойсто зависимости
        public static readonly DependencyProperty TemperatureProperty;

        public string WindDirection { get; set; } // автосвоиство направление ветра
        public string WindSpeed { get; set; } // автосвойство скорость ветра

        //Объявляем свойство зависимости температура
        public int Temperature
        {
            get { return (int) GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        //Сатический конструктор выполняем регистрацию сз
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new PropertyMetadata(
                    0,
                    null,
                    new CoerceValueCallback(CoerseTemperature)
                ));
        }

        // Метод проверка корректности значений сз
        private static object CoerseTemperature(DependencyObject d, object baseValue)
        {
            int t = (int) baseValue;
            if (t > 50 && t < -50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }

        // Конструктор инициализируем поля 
        public WeatherControl(int temperature, string windDirection, string windSpeed)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
        }

        // добавляем перечисление погоды
        public enum Precipitation
        {
            sunny = 0,
            cloudy = 1,
            rain = 2,
            snow = 3
        }

        public string Print(Precipitation precipitation)
        {
            switch (precipitation)
            {
                case Precipitation.sunny:
                    Console.WriteLine("солнечно");
                    break;
                case Precipitation.cloudy:
                    Console.WriteLine("облачно");
                    break;
                case Precipitation.rain:
                    Console.WriteLine("дождь");
                    break;
                case Precipitation.snow:
                    Console.WriteLine("снег");
                    break;
            }

            return $"{Temperature} {WindDirection} {WindSpeed} {precipitation}";
        }
    }
}
