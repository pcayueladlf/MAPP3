namespace Listas
{
    class Lista
    {
        // clase interna Nodo
        private class Nodo
        {
            public int dato;
            public Nodo sig;
            public Nodo(int e = 0, Nodo x = null)
            {
                dato = e;
                sig = x;
            }
        }
        // fin clase Nodo

        Nodo pri;


        public Lista()
        {
            pri = null;
        }

        public bool InsertaPos(int e, int pos)
        {
            if (pos == 0)
            {
                pri = new Nodo(e, pri);
                return true;
            }
            else
            {
                Nodo aux = pri;
                while (aux != null && pos > 1)
                {
                    aux = aux.sig;
                    pos--;
                }
                if (aux != null)
                {
                    aux.sig = new Nodo(e, aux.sig);                
                }               
            }
            return (pos != 0 && aux != null);
        }

        public void InsertaPri(int e)
        {
            pri = new Nodo(e, pri);
        }


        // devuelve pos de elem e en la lista; -1 si no está
        public int PosElto(int e)
        {
            Nodo aux = pri;
            int pos = 0;
            while (aux != null && aux.dato != e)
            {
                pos++;
                aux = aux.sig;
            }
            if (aux == null) return -1;
            else return pos;
            return -1;
        }

        public void InsertUlt(int e)
        {
            if (pri == null)
            {
                pri = new Nodo(e);
            }
            else
            {
                Nodo aux = pri;
                while(aux.sig != null)
                    aux = aux.sig;
                aux.sig = new Nodo(e);
            }
        }

        public bool BorraPrimElto(int e)
        {
            if (pri == null) return false;
            else if (pri.dato == e)
            {
                pri = pri.sig;
                return true;
            }
            else
            {
                Nodo ant = BuscaAnt(e);
                if(ant==null) return false;
                else
                {
                    ant.sig = ant.sig.sig;
                    return true;
                }
            }

        }

        //busca el nodo anterior al primer nodo con dato e y devuelve una referencia hacia dicho nodo
        private Nodo BuscaAnt(int e) 
        {
            //primero debo comprobar pri y luego pri.sig -> si no lo hago así ESTÁ MAL !!
            if (pri == null || pri.sig == null) return null;
            else
            {
                Nodo aux = pri;
                //pregunto si el siguiente no es nulo (si no lo es, paso) y si el elemento es el que busco (si no lo es, también paso)
                while (aux.sig != null && aux.sig.data != e)
                    aux = aux.sig;
                if (aux.sig != null) return null; 
                else return aux;
            }
        }


        public int Suma()
        {
            int suma = 0;
            Nodo aux = pri;
            while (aux != null)
            {
                suma += aux.dato;
                aux = aux.sig;
            }
            return suma;
        }

        public int CuentaOcurrencias(int e)
        {
            int count = 0;
            Nodo aux = pri;
            while (aux != null)
            {
                if (aux.dato == e) count++;
                aux = aux.sig;
            }
            return count;
        }

        private Nodo NesimoNodo(int n)
        {
            Nodo aux = pri;
            while (aux != null && n > 0)
            {
                aux = aux.sig;
                n--;
            }
            return aux;
        }

        public int Nesimo(int n)
        {
            Nodo nodo = NesimoNodo(n);
            if (nodo == null)
                throw new ArgumentException("Índice fuera de rango");
            return nodo.dato;
            
        }

        public void InsertaNesimo(int n,int e)
        {
            if (n == 0)
            {
                pri = new Nodo(e, pri);
            }
            else
            {
                Nodo prev = NesimoNodo(n - 1);
                if (prev == null)
                    throw new ArgumentException("Posición fuera de rango");
                prev.sig = new Nodo(e, prev.sig);
            }
        }

        public bool BorraElto(int e)
        {
            return BorraPrimElto(e);
        }

        public void BorraTodos(int e)
        {
            while (pri != null && pri.dato == e)
                pri = pri.sig;

            Nodo aux = pri;
            while(aux != null && aux.sig != null)
            {
                if (aux.sig.dato == e)
                    aux.sig = aux.sig.sig;
                else aux = aux.sig;
            }
        }

        public void BorraNesimo(int n)
        {
            if (n == 0 && pri != null)
                pri = pri.sig;
            else
            {
                Nodo prev = NesimoNodo(n - 1);
                if (prev == null || prev.sig == null)
                    throw new ArgumentException("Posición fuera de rango");
                prev.sig=prev.sig.sig;

            }
        }

        public void Invierte()
        {
            Nodo prev = null, current = pri, next;
            while(current != null)
            {
                next = current.sig;
                current.sig = prev;
                prev = current;
                current = next;
            }
            pri = prev;
        }

        public bool Iguales(Lista 1)
        {
            Nodo aux = pri, aux2 = 1.pri;
            bool igual;
            while (aux1 != null && aux2 != null && igual)
            {
                if (aux1.dato != aux2.dato)
                    igual = false;
                aux1 = aux1.sig;
                aux2 = aux2.sig;
            }

        }

        // public int ElmentoEnPos(int pos){}

        // public bool BorraPos(int pos){}


        // public bool BorraTodosElto(int e){}

        // public int Longitud(){}

        public int CuentaElto(int e){ }


        // public void Intercambia(int pos1, int pos2){}


        // public void Init(){ }
        // public int Next(){ }

        // public void Retrocede(){ }


        public override string ToString()
        {
            string s = "";
            Nodo aux = pri;
            while (aux != null)
            {
                s += aux.dato + " ";
                aux = aux.sig;
            }
            return s;
        }


    }
}