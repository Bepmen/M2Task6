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
        public static readonly DependencyProperty TemperatureProperty;

        private string windDirection;


        public int Temperatyre
        {
            get { return (int) GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperatyre),
                typeof(int),
                typeof(WeatherControl),
                new PropertyMetadata(
                    0,
                    null,
                    new CoerceValueCallback(CoerseTemperature)
                ));

        }

        private static object CoerseTemperature(DependencyObject d, object baseValue)
        {
            int t = (int) baseValue;
            if (t > 50 && t < -50)
            {
                return t;
            }
            else
            {
                return $"Значение {t} вне диапазона температур";
            }
        }

        
    }
}
