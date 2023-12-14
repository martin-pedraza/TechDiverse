using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Rectangulo
    {
        public float area;
        public float perimetro;
        private Punto vertice1;
        private Punto vertice2;
        private Punto vertice3;
        private Punto vertice4;

        public Rectangulo(Punto vertice1, Punto vertice3)
        {
            this.vertice1 = vertice1;
            this.vertice3 = vertice3;
            this.vertice2 = new Punto(vertice3.GetX, vertice1.GetY);
            this.vertice4 = new Punto(vertice1.GetX, vertice3.GetY);
            this.area = this.Area;
            this.perimetro = this.Perimetro;
        }
        private float Area
        {
            get
            {
                int baseRectangulo = Math.Abs(vertice3.GetX - vertice1.GetX);
                int alturaRectangulo = Math.Abs(vertice3.GetY - vertice1.GetY);
                return (float)baseRectangulo * alturaRectangulo;
            }
        }
        private float Perimetro
        {
            get
            {
                int baseRectangulo = Math.Abs(vertice3.GetX - vertice1.GetX);
                int alturaRectangulo = Math.Abs(vertice3.GetY - vertice1.GetY);
                return (float)baseRectangulo * 2 + alturaRectangulo * 2;
            }
        }
    }
}
