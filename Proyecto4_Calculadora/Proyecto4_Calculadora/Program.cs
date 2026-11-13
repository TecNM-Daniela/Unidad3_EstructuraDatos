using System;
using System.Collections.Generic;
using System.Globalization;

namespace Proyecto4_Calculadora
{
    internal class Program
    {
        static int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;

            if (operador == '*' || operador == '/')
                return 2;

            if (operador == '^')
                return 3;

            return 0;
        }

        static string InfijaAPosfija(string expresion)
        {
            Pila pila = new Pila();
            string salida = "";

            foreach (char caracter in expresion)
            {
                if (char.IsDigit(caracter))
                {
                    salida += caracter;
                }
                else if (caracter == '(')
                {
                    pila.Apilar(caracter);
                }
                else if (caracter == ')')
                {
                    while (!pila.Vacia() && pila.Tope() != '(')
                    {
                        salida += pila.Desapilar();
                    }

                    if (!pila.Vacia())
                        pila.Desapilar();
                }
                else if ("+-*/^".Contains(caracter))
                {
                    while (!pila.Vacia() &&
                           pila.Tope() != '(' &&
                           Prioridad(pila.Tope()) >= Prioridad(caracter))
                    {
                        salida += pila.Desapilar();
                    }

                    pila.Apilar(caracter);
                }
            }

            while (!pila.Vacia())
                salida += pila.Desapilar();

            return salida;
        }

        static int Calcular(string expresion)
        {
            Stack<int> pila = new Stack<int>();

            foreach (char c in expresion)
            {
                if (char.IsDigit(c))
                    pila.Push(c - '0');
                else
                {
                    int b = pila.Pop();
                    int a = pila.Pop();

                    if (c == '+') pila.Push(a + b);
                    if (c == '-') pila.Push(a - b);
                    if (c == '*') pila.Push(a * b);
                    if (c == '/') pila.Push(a / b);
                    if (c == '^') pila.Push((int)Math.Pow(a, b));
                }
            }

            return pila.Pop();
        }

        static void Main()
        {
            Console.WriteLine("====Calculadora====");
            Console.Write("Expresión: ");

            string expresion = Console.ReadLine();

            string postfija = InfijaAPosfija(expresion);

            Console.WriteLine("Postfija: " + postfija);

            Console.WriteLine("Resultado: " + Calcular(postfija));

            Console.ReadKey();
        }
    }
}
