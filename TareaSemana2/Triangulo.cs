using System;

namespace TareaSemana2
{
    public class Triangulo
    {
        private double baseTriangulo;
        private double alturaTriangulo;

        public Triangulo(double baseInicial, double alturaInicial)
        {
            this.baseTriangulo = baseInicial;
            this.alturaTriangulo = alturaInicial;
        }

        // CalcularArea es una funcion que devuelve un valor double, se utiliza para calcular el area de un triangulo, utiliza los atributos base y altura de la clase
        public double CalcularArea()
        {
            return (this.baseTriangulo * this.alturaTriangulo) / 2;
        }

        // CalcularPerimetro es una funcion que devuelve un valor double, se utiliza para calcular el perimetro sumando los lados y la hipotenusa, 
        // utiliza los atributos base y altura de la clase
        public double CalcularPerimetro()
        {
            double hipotenusa = Math.Sqrt(Math.Pow(this.baseTriangulo, 2) + Math.Pow(this.alturaTriangulo, 2));
            return this.baseTriangulo + this.alturaTriangulo + hipotenusa;
        }
    }
}