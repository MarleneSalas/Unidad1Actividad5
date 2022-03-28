using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Unidad1Actividad5
{
    public class Cronometro : INotifyPropertyChanged
    {
        public int Tiempo { get; set; }

        public ICommand IncrementarCommand { get; set; }
        public ICommand DecrementarCommand { get; set; }
        public ICommand ReiniciarCommand { get; set; }

        public Cronometro()
        {
            IncrementarCommand = new RelayCommand(Incrementar);
            DecrementarCommand = new RelayCommand(Decrementar);
            ReiniciarCommand = new RelayCommand(Reiniciar);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Incrementar()
        {
            if (Tiempo > 999)
            { Reiniciar(); }
            else
            {
                Tiempo++;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Decrementar()
        {
            if (Tiempo == 0)
            { Reiniciar(); }
            else
            {
                Tiempo--;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Reiniciar()
        {
            Tiempo = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
    public class NumerosBinarios : INotifyPropertyChanged
    {
        int numero;
        bool jugar;
        public int Valor { get; set; }
        public byte Correctos { get; set; }
        public byte Incorrectos { get; set; }
        public string Verificacion { get; set; }

        public ICommand GenerarCommand { get; set; }
        public ICommand VerificarCommand { get; set; }

        public NumerosBinarios()
        {
            GenerarCommand = new RelayCommand(GenerarNuevo);
            VerificarCommand = new RelayCommand(Verificar);
        }

        public string Binario
        {
            get { return Convert.ToString(numero, 2); }
        }

        public bool Jugar => jugar;
        public event PropertyChangedEventHandler? PropertyChanged;
        public void GenerarNuevo()
        {
            Random r = new Random();
            numero = r.Next(1, 255);
            jugar = true;
            Verificacion = "...";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Verificar()
        {
            if (jugar)
            {
                if (Valor == numero)
                {
                    jugar = false;
                    Correctos++;
                    Verificacion = "¡Es correcto!";
                }
                else
                {
                    Incorrectos++;
                    Verificacion = "Es incorrecto";
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
    public class CalculadoraDeFracciones : INotifyPropertyChanged
    {
        public int Numerador1 { get; set; }
        public int Denominador1 { get; set; }
        public int Numerador2 { get; set; }
        public int Denominador2 { get; set; }
        public int ResultadoN { get; set; }
        public int ResultadoD { get; set; }
        public string Mensaje { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LimpiarCommand { get; set; }
        public ICommand SumarCommand { get; set; }
        public ICommand RestarCommand { get; set; }

        public CalculadoraDeFracciones()
        {
            Mensaje = "Rellena los campos vacíos...";
            LimpiarCommand = new RelayCommand(Limpiar);
            SumarCommand = new RelayCommand(Sumar);
            RestarCommand = new RelayCommand(Restar);
        }
        public void Limpiar()
        {
            Mensaje = "Rellena los campos vacíos...";
            Numerador1 = 0;
            Denominador1 = 0;
            Numerador2 = 0;
            Denominador2 = 0;
            ResultadoN = 0;
            ResultadoD = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public void Sumar()
        {
            if (Numerador1 != 0 && Denominador1 != 0 && Numerador2 != 0 && Denominador2 != 0)
            {
                if (Denominador1 == Denominador2)
                {
                    ResultadoN = Numerador1 + Numerador2;
                    ResultadoD = Denominador2;
                }
                else
                {
                    ResultadoN = Numerador1 * Denominador2 + Denominador1 * Numerador2;
                    ResultadoD = Denominador1 * Denominador2;
                }
                Mensaje = "¡Resultado listo!";
            }
            else
            {
                Mensaje = "¡Introduce números mayores a 0!";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Restar()
        {
            if (Numerador1 != 0 && Denominador1 != 0 && Numerador2 != 0 && Denominador2 != 0)
            {
                if (Denominador1 == Denominador2)
                {
                    ResultadoN = Numerador1 - Numerador2;
                    ResultadoD = Denominador2;
                }
                else
                {
                    ResultadoN = Numerador1 * Denominador2 - Denominador1 * Numerador2;
                    ResultadoD = Denominador1 * Denominador2;
                }
                Mensaje = "¡Resultado listo!";
            }
            else
            {
                Mensaje = "¡Introduce números mayores a 0!";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
