using System;

namespace TareaSemana2
{
    public class Cuadrado
    {
        private double lado;

        public Cuadrado(double ladoInicial)
        {
            this.lado = ladoInicial;
        }

        // CalcularArea es una funcion que devuelve un valor double, se utiliza para calcular el area de un cuadrado multiplicando lado por lado, 
        // utiliza el atributo lado de la clase
        public double CalcularArea()
        {
            return this.lado * this.lado;
        }

        // CalcularPerimetro es una funcion que devuelve un valor double, se utiliza para calcular el perimetro sumando los cuatro lados, 
        // utiliza el atributo lado de la clase
        public double CalcularPerimetro()
        {
            return 4 * this.lado;
        }
    }
}