using System;
using System.Collections.Generic;
using System.Linq;

namespace arvore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int[] array = CriaArray();

            BTree btr = new BTree();

            foreach (int item in array)
            {
                btr.Add(item);
            }
           
            btr.Print();
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para sair:");
            Console.ReadKey();
        }

        private static int[] CriaArray()
        {
            int[] numeros = new int[100];
            Random rm = new Random();
            for (int xx = 0; xx < 100; xx++)
            {
                while (true)
                {
                    int temp = rm.Next(1, 1000);

                    if (numeros.Contains(temp) == false)
                    {
                        numeros[xx] = temp;
                        break;
                    }
                }
            }

            return numeros;
        }

        public class BNode
        {
            public int item;
            public BNode right;
            public BNode left;

            public BNode(int item)
            {
                this.item = item;
            }
        }

        public class BTree
        {
            private BNode _root;
            private int _count;
            private IComparer<int> _comparer = Comparer<int>.Default;

            public BTree()
            {
                _root = null;
                _count = 0;
            }

            public bool Add(int Item)
            {
                if (_root == null)
                {
                    _root = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(_root, Item);
                }
            }

            private bool Add_Sub(BNode Node, int Item)
            {
                if (_comparer.Compare(Node.item, Item) < 0)
                {
                    if (Node.right == null)
                    {
                        Node.right = new BNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.right, Item);
                    }
                }
                else if (_comparer.Compare(Node.item, Item) > 0)
                {
                    if (Node.left == null)
                    {
                        Node.left = new BNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.left, Item);
                    }
                }
                else
                {
                    return false;
                }
            }

            public void Print()
            {
                Print(_root, 4);
            }

            public void Print(BNode p, int padding)
            {
                if (p != null)
                {
                    if (p.right != null)
                    {
                        Print(p.right, padding + 4);
                    }
                    if (padding > 0)
                    {
                        Console.Write(" ".PadLeft(padding));
                    }
                    if (p.right != null)
                    {
                        Console.Write("/\n");
                        Console.Write(" ".PadLeft(padding));
                    }
                    Console.Write(p.item.ToString() + "\n ");
                    if (p.left != null)
                    {
                        Console.Write(" ".PadLeft(padding) + "\\\n");
                        Print(p.left, padding + 4);
                    }
                }
            }
        }
    }
}
