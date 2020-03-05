﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Autovia
    {
        private List<Vehiculo> vel = new List<Vehiculo>();
        private List<Vehiculo> tem = new List<Vehiculo>();
        private List<Vehiculo> com = new List<Vehiculo>();
        private List<Vehiculo> lv = new List<Vehiculo>();
        public Autovia(int nc)
        {
            for (int i = 0; i < nc; i++)
            {
                string n = "Vehiculo_" + i;
                int c, t, ve;
                ve = c = t = 50;
                Vehiculo v = new Vehiculo(n, ve, t, c);
                // velocidadMaximaExcedida temperaturaMaximaExcedida combustibleMinimoExcedida
                v.velocidadMaximaExcedida += cuandoVelocidadMaximaExcedida;
                v.temperaturaMaximaExcedida += cuandoTemperaturaMaximaExcedida;
                v.combustibleMinimoExcedido += cuandoCombustibleMinimoExcedido;
                lv.Add(v);
            }
            //Conectar los manejadores

        }
        public bool moverCoches()
        {
            int i = 0;
            foreach (Vehiculo c in lv)
            {
                if (c.todoOk())
                {
                    c.mover();
                    i++;
                }
            }
            return (i == 0) ? false : true;
        }
        public void moverCochesEnBucle()
        {
            int i = 1;
            while (i>0)
            {
                i = 0;
                foreach (Vehiculo c in lv)
                {
                    if (c.todoOk())
                    {
                        i++;
                    }
                }
                if (i > 0)
                {
                    this.moverCoches();
                }
            }
            
            
        }
        public List<Vehiculo> getCochesExcedenLimiteVelocidad()
        {
            return new List<Vehiculo>(vel);
        }
        public List<Vehiculo> getCochesExcedenLimiteTemperatura()
        {
            return new List<Vehiculo>(tem);
        }
        public List<Vehiculo> getCochesExcedenMinimoCombustible()
        {
            return new List<Vehiculo>(com);
        }
        override public string ToString()
        {
            string res = "[Autivía] Exceso velocidad: ";
            res += vel.Count;
            res += ", Exceso temperatura: ";
            res += tem.Count;
            res += ", Déficit combustible: ";
            res += com.Count;
            return res;
        }
        //VelocidadMaximaExcedidaArgs TemperaturaMaximaExcedidaArgs CombustibleMinimoExcedidaArgs
        private void cuandoVelocidadMaximaExcedida(Object s, VelocidadMaximaExcedidaArgs e)
        {
            Vehiculo v = (Vehiculo)s;
            string res = "¡¡Velocidad máxima excedida!!\nVehiculo: "; //+ nombrecoche;
            res += v.nombre;
            res += "\nVelocidad: ";
            res += e.velocidad;
            res += " ºC";
            if (!vel.Contains(v))
            {
                vel.Add(v);
            }
            Console.WriteLine(res);
        }
        private void cuandoTemperaturaMaximaExcedida(Object s, TemperaturaMaximaExcedidaArgs e)
        {
            Vehiculo v = (Vehiculo)s;
            string res = "¡¡Temperatura máxima excedida!!\nVehiculo: "; //+ nombrecoche;
            res += v.nombre;
            res += "\nTemperatura: ";
            res += e.temperatura;
            res += " km/h";
            if (!tem.Contains(v))
            {
                tem.Add(v);
            }
            Console.WriteLine(res);
        }
        private void cuandoCombustibleMinimoExcedido(Object s, CombustibleMinimoExcedidoArgs e)
        {
            Vehiculo v = (Vehiculo)s;
            string res = "¡¡Combustible mínimo excedido!!\nVehiculo: "; //+ nombrecoche;
            res += v.nombre;
            res += "\nCombustible: ";
            res += e.combustible;
            res += " %";
            if (!com.Contains(v))
            {
                com.Add(v);
            }
            Console.WriteLine(res);
        }
    }
}
