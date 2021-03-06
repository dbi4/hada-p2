﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    
    public class VelocidadMaximaExcedidaArgs : EventArgs
    {
        private int _velocidad;
        public int velocidad
        {
            get {return _velocidad;}
            set
            {
                _velocidad = value;
            }
        }
        public VelocidadMaximaExcedidaArgs(int v)
        {
            velocidad = v;
        }
    }

    public class TemperaturaMaximaExcedidaArgs : EventArgs
    {
        private int _temperatura;
        public int temperatura
        {
            get {return _temperatura;}
            set
            {
                _temperatura = value;
            }
        }
        public TemperaturaMaximaExcedidaArgs(int t)
        {
            temperatura = t;
        }
    }

    public class CombustibleMinimoExcedidoArgs : EventArgs
    {
        private int _combustible;
        public int combustible
        {
            get {return _combustible;}
            set
            {
                _combustible = value;
            }
        }
        public CombustibleMinimoExcedidoArgs(int c)
        {
            combustible = c;
        }
    }

    public class Vehiculo
    {
        
        public event EventHandler<VelocidadMaximaExcedidaArgs> velocidadMaximaExcedida;
        public event EventHandler<TemperaturaMaximaExcedidaArgs> temperaturaMaximaExcedida;
        public event EventHandler<CombustibleMinimoExcedidoArgs> combustibleMinimoExcedido;

        public static int maxVelocidad { get; set; }
        public static int maxTemperatura { get; set;  }
        public static int minCombustible { get; set; }
      
        public static Random rand
        { private get; set; }

        private string _nombre;
        public string nombre
        {
            get
            {
                return _nombre;
            }
            private set
            {
                _nombre = value;
            }
        }

        private int _velocidad;
        private int velocidad
        {
            set
            {
                if (value <= 0)
                {
                    _velocidad = 0;
                }
                else
                {
                    _velocidad = value;
                }
                if (value > maxVelocidad)
                {
                    EventHandler<VelocidadMaximaExcedidaArgs> ev = velocidadMaximaExcedida;
                    if (ev != null)
                    {
                        ev(this, new VelocidadMaximaExcedidaArgs(_velocidad));

                    }
                }
            }

            get { return _velocidad; }
        }

        private int _temperatura;
        private int temperatura
        {
            get { return _temperatura; }

            set
            {
                _temperatura = value;
                if (value > maxTemperatura)
                {   
                    EventHandler<TemperaturaMaximaExcedidaArgs> ev = temperaturaMaximaExcedida;
                    if (ev != null)
                    {
                        ev(this, new TemperaturaMaximaExcedidaArgs(_temperatura));
                    }
                }
            }

            
        }

        private int _combustible;
        private int combustible
        {
            get { return _combustible; }
            set
            {
                if (value <= 0)
                {
                    _combustible = 0;
                }
                else if (value >= 100)
                {
                    _combustible = 100;
                }
                else
                {
                    _combustible = value;
                }
                if (value < minCombustible)
                {
                    EventHandler<CombustibleMinimoExcedidoArgs> ev = combustibleMinimoExcedido;
                    if (ev != null)
                    {
                        ev(this, new CombustibleMinimoExcedidoArgs(_combustible));
                    }
                }
            }
        }

        public Vehiculo(string nombre, int velocidad, int temperatura, int combustible)
        {
            this.velocidad = velocidad;
            this.nombre = nombre;
            this.temperatura = temperatura;
            this.combustible = combustible;
        }

        public void incVelocidad()
        {
            velocidad += rand.Next(1,7+1);
        }

        public void incTemperatura()
        {
            temperatura += rand.Next(1, 5 + 1);
        }

        public void decCombustible()
        {
            combustible -= rand.Next(1, 5 + 1);
        }

        public bool todoOk()
        {
            return (temperatura <= maxTemperatura && combustible >= minCombustible);
        }

        public void mover()
        {
            if (this.todoOk())
            {
                this.incVelocidad();
                this.incTemperatura();
                this.decCombustible();
            }
        }

        override public string ToString()
        {
            string res = "[" + nombre + "] Velocidad: " + velocidad + " km/h; Temperatura: " + temperatura + " ºC; Combustible: " + combustible + " %; Ok: ";
            
            if (this.todoOk())
            {
                res += "True";
            }
            else
            {
                res += "False";
            }
            return res;
        }

    }
}
