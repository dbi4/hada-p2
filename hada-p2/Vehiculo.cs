using System;
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
        //EVENTOS VelocidadMaximaExcedidaArgs TemperaturaMaximaExcedidaArgs CombustibleMinimoExcedidaArgs
        // velocidadMaximaExcedida temperaturaMaximaExcedida combustibleMinimoExcedida
        public EventHandler<VelocidadMaximaExcedidaArgs> velocidadMaximaExcedida;
        public EventHandler<TemperaturaMaximaExcedidaArgs> temperaturaMaximaExcedida;
        public EventHandler<CombustibleMinimoExcedidoArgs> combustibleMinimoExcedido;

        public static int maxVelocidad;
        public static int maxTemperatura;
        public static int minCombustible;
        //preguntar
        public static Random _rand;
        public static Random rand
        {
            set { }
            private get
            {
                return rand.Next(); //cuidaddo
            }
        }
        public string nombre
        {
            get
            {
                return nombre;
            }
            private set
            {
                nombre = value;
            }
        }
        private int _velocidad;
        private int velocidad
        {
            set
            {
                if (value > maxVelocidad)
                {
                    //disparar el evento velocidadMaximaExcedida
                    EventHandler<VelocidadMaximaExcedidaArgs> ev = velocidadMaximaExcedida;
                    if (ev != null)
                    {
                        ev(this, new VelocidadMaximaExcedidaArgs(value));
                        
                    }
                }
                else if (value <= 0)
                {
                    _velocidad = 0;
                }
                else
                {
                    _velocidad = value;
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
                if (value > maxTemperatura)
                {
                    //disparar el evento velocidadMaximaExcedida
                    EventHandler<TemperaturaMaximaExcedidaArgs> ev = temperaturaMaximaExcedida;
                    if (ev != null)
                    {
                        ev(this, new TemperaturaMaximaExcedidaArgs(value));
                        //tem.Add(this);
                    }
                }
                else
                {
                    _temperatura = value;
                }
            }

            
        }

        private int _combustible;
        private int combustible
        {
            get { return _combustible; }
            set
            {
                if (value < minCombustible)
                {
                    //disparar el evento combiustibleMinimoExcedido
                    EventHandler<CombustibleMinimoExcedidoArgs> ev = combustibleMinimoExcedido;
                    if (ev != null)
                    {
                        ev(this, new CombustibleMinimoExcedidoArgs(value));
                        //com.Add(this);
                    }
                }
                else if (value <= 0)
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
            }
        }

        //
        //protected virtual void 


        public Vehiculo(string nombre, int velocidad, int temperatura, int combustible)
        {
            this.velocidad = velocidad;
            this.nombre = nombre;
            this.temperatura = temperatura;
            this.combustible = combustible;
            //Aqui se connecta el evento con el manejador
            /*
             Vehiculo v = new ...
             v.velocidad maxima event...
             */
        }
        public void incVelocidad()
        {
            velocidad += rand.Next(1,7+1);//ciudado
        }
        public void incTemperatura()
        {
            temperatura += rand.Next(1, 5 + 1);//cuidado
        }
        public void decCombustible()
        {
            combustible -= rand.Next(1, 5 + 1);//cuidado
        }
        public bool todoOk()
        {
            return (temperatura <= maxTemperatura && combustible >= minCombustible) ? true : false;
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
            string res = "[" + nombre + "] Velocidad:" + velocidad + " km/h; Temperatura: " + temperatura + " ºC; Combustible: " + combustible + " %;Ok: ";
            //(this.todoOk()) ? res += "True" : res += "False";
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
