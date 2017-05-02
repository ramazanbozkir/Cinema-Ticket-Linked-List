using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama1
{
    public abstract class LinkedListADT
    {
        public Node Head;
        public int Size = 0;
        public abstract void InsertPos(int position, Musteri value);
        public abstract void DeletePos(int position);
        public abstract Node GetElement(int position);
    }
}
