using System;
using System.Text;
using System.Threading.Tasks;
using Coordinates;

namespace Hoja5
{
    internal class SetCoor
    {
        Coor[] coors; //array con coordenadas
        int oc; //componentes ocupadas del array

        public SetCoor(int tam = 10)
        {
            coors = new Coor[tam]; //inicializa con el tamaño dado
            oc = 0; //inicializa el contador de ocupadas

        }

        private int SearchElem(Coor c)
        {
            int i = 0;
            bool encontrado = false;
            while (i < oc && !encontrado)
            {
                i++;
                if (coors[i] == c) encontrado = true;
                else if (i == oc && !encontrado) i = -1;
            }

            return i;
         
        }

        public bool Add(Coor c)
        {
            bool encontrado;

            //si la coordenada ya existe en el conjunto no la añade
            if (SearchElem(c) != -1)
                encontrado = false;

            //si no está, comprueba si hay espacio
            if (oc < coors.Length)
            {
                coors[oc] = c;
                oc++;
                encontrado = true;
            }
            //si no hay espacio lanza mensaje de error
            else
            {
                Console.WriteLine("No hay espacio en el conjunto");
                encontrado = false;
            }
            return encontrado;

        }

        public bool Belongs (Coor c)
        {
            return SearchElem(c) != -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for(int i = 0; i < oc; i++)
            {
                sb.Append(coors[i].ToString());
                if(i<oc-1) sb.Append(',');
            }
            sb.Append('}');
            return sb.ToString();
        }

        public bool Remove (Coor c)
        {
            bool encontrado = true;
            int index = SearchElem(c);

            //si no está, no se elimina
            if (index == -1) encontrado = false; 

            //desplazamos los elementos a la izq
            for(int i=index;i<oc; i++)
            {
                coors[i] = coors[i + 1];
            }
            //reduzco el número de elementos ocupados
            oc--;
            return encontrado;
        }
        public Coor PopElem()
        {
            if (oc == 0) throw new InvalidOperationException("Conjunto vacío");

            Coor primElem = coors[0];
            Remove(primElem);
            return primElem;

        }

        public int Size() { return oc; }

        public static SetCoor operator+(SetCoor s1, SetCoor s2)
        {
            SetCoor result= new SetCoor(s1.oc+s2.oc);
            foreach(var coor in s1.coors)
            {
                if (coor != null && !result.Belongs(coor))
                    result.Add(coor);
            }
            foreach (var coor in s2.coors)
            {
                if (coor != null && !result.Belongs(coor))
                    result.Add(coor);
            }

            return result;

        }

        public static SetCoor operator-(SetCoor s1, SetCoor s2)
        {
            SetCoor result = new SetCoor(s1.oc);
            foreach (var coor in s1.coors)
            {
                if (coor != null && !s2.Belongs(coor))
                    result.Add(coor);
            }

            return result;
        }

        public static SetCoor operator&(SetCoor s1, SetCoor s2)
        {
            SetCoor result = new SetCoor(Math.Min(s1.oc, s2.oc));
            foreach(var coor in s1.coors)
            {
                if(coor!=null&&s2.Belongs(coor))
                    result.Add(coor);
            }

            return result;
        }

        public static bool operator==(SetCoor s1, SetCoor s2)
        {
            bool iguales = true ;
            if (s1.Size() != s2.Size()) iguales = false;

            foreach(var coor in s1.coors)
            {
                if (coor != null && !s2.Belongs(coor)) 
                    iguales = false;
            }

            return iguales;
        }

        public static bool operator!=(SetCoor s1, SetCoor s2)  { return !(s1==s2); }

        //verifica si es subconjunto
        public bool IsSubset(SetCoor s)
        {
            bool subconjunto = true;
            foreach(var coor in this.coors)
            {
                if (coor != null && !s.Belongs(coor)) subconjunto = false;
            }

            return subconjunto;
        }

        public SetCoor Copy()
        {
            SetCoor copy= new SetCoor(this.oc);
            foreach(var coor in this.coors)
            {
                if (coor != null) copy.Add(coor);
            }
            return copy;
        }





    }
}
