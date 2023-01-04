using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson_6
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rainy,
        snowy
    }
    class WeatherControl:DependencyObject 
    {
        public static readonly DependencyProperty TempProperty;
        
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty,value);
        }


        public string WindDirection { get; set; }
        public int WindSpeed { get; set; } 
        public Precipitation Precipitation { get; set; }

        public WeatherControl (int temp, string windDir, int windSp, Precipitation prec)
        {
            this.Temp = temp;
            this.WindDirection = windDir;
            this.WindSpeed = windSp;
            this.Precipitation = prec;
        }
        

        // Статический конструктор для класса WeatherControl

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemp))
                );
                                 

                
        }

        //Метод для проверки корректности введенной температуры

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v=(int) baseValue;
            if (v > -50 && v < 50)
                return v;
            else
                if (v < -50)
                return -50;
            else
                return 50;
        }
    }
}
