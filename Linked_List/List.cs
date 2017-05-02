using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama1
{
    
        public class List : LinkedListADT
        {

            public override void InsertPos(int position, Musteri musteri)
            {
                Node newNode = new Node { Data = musteri };
                if (Head == null)
                    Head = newNode;
                else if (position > Size + 1)
                    throw new Exception("Hata");
                else if (position == 0)
                {
                    Node temp = Head;
                    Head = newNode;
                    newNode.Next = temp;
                }
                else
                {
                    Node posNode = Head;
                    if (posNode.Next != null)
                    {
                        for (int i = 0; i < position - 1; i++)
                            posNode = posNode.Next;
                    }
                    if (posNode.Next != null)
                    {
                        Node temp = posNode.Next;
                        posNode.Next = newNode;
                        newNode.Next = temp;
                    }
                    else
                        posNode.Next = newNode;
                }
                Size++;

            }
            public override void DeletePos(int position)
            {
                Node posNode = Head;
                if (Head == null)
                    throw new Exception("Bos");
                if (Size > position)
                {
                    Node prevNode = posNode;
                    for (int i = 0; i < position; i++)
                    {
                        prevNode = posNode;
                        posNode = posNode.Next;
                    }
                    if (posNode == Head)
                        Head = posNode.Next;
                    else if (posNode.Next != null)
                    {
                        prevNode.Next = posNode.Next;
                        posNode = null;
                    }
                    else if (posNode.Next == null)
                    {
                        prevNode.Next = null;
                        posNode = null;
                    }
                }
                Size--;
            }


            public override Node GetElement(int position)
            {
                if (Head == null)
                    throw new Exception("Liste Bos");
                else
                {
                    Node temp = new Node();
                    temp = Head;
                    if (temp.Next != null)
                    {
                        for (int i = 0; i < position; i++)
                            temp = temp.Next;
                    }
                    return temp;
                }
            }


        }
    
}
