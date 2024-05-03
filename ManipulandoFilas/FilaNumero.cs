using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoFilas
{
    internal class FilaNumero
    {
        Numero? head;
        Numero? tail;
        int tamanho;
        int qntPares;
        int qntImpares;

        public FilaNumero()
        {
            this.head = null;
            this.tail = null;
        }

        public void Enqueue(Numero aux)
        {
            if (IsEmpty())
            {
                head = aux;
                tail = aux;
            }
            else
            {
                tail.SetProximo(aux);
                tail = aux;
            }

            if(aux.GetNumero() % 2 == 0)
            {
                qntPares++;
            }
            else
            {
                qntImpares++;
            }

            tamanho++;
        }

        public Numero? Dequeue()
        {
            if (!IsEmpty())
            {
                Numero aux = head;

                if (head == tail)
                    head = tail = null;
                else
                    head = head.GetProximo();

                tamanho--;

                if(aux.GetNumero() % 2 == 0)
                    qntPares--;
                else
                    qntImpares--;
                
                return aux;
            }
            return null;
        }

        public int[] GetPares()
        {
            int[] numerosPares = new int[qntPares];
            int indice = 0;
            Numero aux = head;

            while (aux != null)
            {
                if (aux.GetNumero() % 2 == 0)
                {
                    numerosPares[indice++] = aux.GetNumero();
                }
                aux = aux.GetProximo();
            }
            return numerosPares;
        }

        public int[] GetImpares()
        {
            int[] numerosImpares = new int[qntImpares];
            int indice = 0;
            Numero aux = head;

            while (aux != null)
            {
                if (aux.GetNumero() % 2 != 0)
                {
                    numerosImpares[indice++] = aux.GetNumero();
                }
                aux = aux.GetProximo();
            }
            return numerosImpares;
        }

        public float? GetMedia()
        {
            if (tamanho == 0)
            {
                return null;
            }

            float media;
            int sum = 0;
            int total = 0;

            Numero aux = head;
            while (aux != null)
            {
                sum += aux.GetNumero();
                total++;
                aux = aux.GetProximo();
            }

            media = sum / total;

            return media;
        }

        public int? GetMenorNumero()
        {

            if (IsEmpty())
                return null;

            Numero aux = head;
            int menor = head.GetNumero();

            while (aux != null)
            {
                if (aux.GetNumero() < menor)
                    menor = aux.GetNumero();

                aux = aux.GetProximo();
            }
            return menor;
        }

        public int? GetMaiorNumero()
        {

            if (IsEmpty())
                return null;

            Numero aux = head;
            int maior = head.GetNumero();

            while (aux != null)
            {
                if (aux.GetNumero() > maior)
                    maior = aux.GetNumero();

                aux = aux.GetProximo();
            }
            return maior;
        }

        public int GetQntPares()
        {
            return qntPares;
        }

        public int GetQntImpares()
        {
            return qntImpares;
        }

        public int GetTamanho()
        {
            return tamanho;
        }

        public void Print()
        {

            if (IsEmpty())
            {
                Console.WriteLine("-->Fila vazia!");
            }
            else
            {
                Numero aux = head;

                while (aux != null)
                {
                    Console.WriteLine($"--> {aux}");
                    aux = aux.GetProximo();
                }
            }
        }

        public bool IsEmpty()
        {
            return head == null && tail == null;
        }
    }
}
