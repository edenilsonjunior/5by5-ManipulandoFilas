using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoFilas
{
    internal class Numero
    {

        int num;
        Numero? proximo;

        public Numero(int num)
        {
            this.num = num;
            proximo = null;
        }

        public void SetProximo(Numero proximo)
        {
            this.proximo = proximo;
        }

        public Numero? GetProximo()
        {
            return proximo;
        }

        public int GetNumero()
        {
            return num;
        }

        public override string? ToString()
        {
            return num.ToString();
        }
    }
}
