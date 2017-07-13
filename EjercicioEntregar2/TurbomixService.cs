using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEntregar2
{
    public class TurbomixService
    {
        public IBascula Bascula { get; set; }
        public ICocina Cocina { get; set; }

        public TurbomixService(IBascula _Bascula, ICocina _Cocina)
        {
            this.Bascula = _Bascula;
            this.Cocina = _Cocina;
        }

        public Plato PrepararPlato(Alimento mAlimento1, Alimento mAlimento2)
        {
            float Peso1 = Bascula.Pesar(mAlimento1);
            float Peso2 = Bascula.Pesar(mAlimento2);
            Cocina.Calentar(mAlimento1, mAlimento2);

            return new Plato(mAlimento1, mAlimento2);
        }

        public void PrepararPlatoConReceta(Alimento mAlimento1, Alimento mAlimento2, Receta receta)
        {
            if (this.ComprobarReceta(mAlimento1, mAlimento2, receta))
            {
                Cocina.Calentar(mAlimento1, mAlimento2);
                Plato plato = new Plato(mAlimento1, mAlimento2);
                Console.Write("Se ha cocinado la receta con los ingredientes correctos");
            }
            else
            {
                Console.Write("Los ingredientes no coinciden");
            }



        }

        private Boolean ComprobarReceta(Alimento mAlimento1, Alimento mAlimento2, Receta receta)
        {
            if(mAlimento1.Nombre != receta.mAlimento1.Nombre || mAlimento2.Nombre != receta.mAlimento2.Nombre)
            {
                return false;
            }

            if (mAlimento1.Calentado || mAlimento2.Calentado)
            {
                return false;
            }

            if (mAlimento1.Peso < receta.mAlimento1.Peso || mAlimento2.Peso < receta.mAlimento2.Peso)
            {
                return false;
            }
            return true;
        }



    }
}
