using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    class Matriz
    {
        const int MAXF = 100;
        const int MAXC = 100;
        private int[,] x;
        private int f, c;


        public Matriz()
        {
            this.x = new int[MAXF, MAXC];
            this.f = 0; 
            this.c = 0;
        }

        public void cargar(int nf, int nc, int a, int b)
        {
            f = nf; c = nc;
            int f1, c1;
            Random r = new Random();
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a, b);
                }
            }
        }
        public string descargar()
        {
            string s = "";
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    s = s + x[f1, c1] + "\x09";
                }
                s = s + "\x0d" + "\x0a";
            }
            return s;
        }


        // Aqui va el ejercicio 1
        public bool pertenece(int a, int b, int j, int g)
        {
            int s = 0;
            while (a <= b)
            {
                if (x[a,j] == g)
                {
                    s++;
                }
                a++;
            }
            return s > 0;
        }
        public void pregunta01()
        {
            int s;
            for (int j = 1; j <= this.c; j++)
            {
                s = 0;
                for (int i = 1; i <= this.f; i++)
                {
                    if (!this.pertenece(1, i - 1, j, x[i, j]))
                        s++;
                }
                x[f + 1, j] = s;
            }
            f++;
        }



        // Aqui va el ejercicio 2
        public void inter(int f1, int c1, int f2, int c2)
        {
            int aux = x[f1, c1];
            x[f1, c1] = x[f2, c2];
            x[f2, c2] = aux;
        }

        public void pregunta02()
        {
            int filElim = 0;
            int sumMen = 0;
            int s;
            for (int i = 1; i <= this.f; i++)
            {
                s = 0;
                for (int j = 1; j <= this.c; j++)
                {
                    s = s + x[i, j];
                }
                x[i, c + 1] = s;
                if (i == 1)
                {
                    filElim = i;
                    sumMen = s;
                }
                else if (s < sumMen)
                {
                    filElim = i;
                    sumMen = s;
                }

            }
            c++;
            this.deleteFil(filElim);
        }

        public void deleteFil(int fil)
        {
            for (int i = fil; i < this.f; i++)
            {
                for (int j = 1; j <= this.c; j++)
                {
                    this.inter(i, j, i + 1, j);
                }
            }
            f = f - 1;
        }

    }
}
