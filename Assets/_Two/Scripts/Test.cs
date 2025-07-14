using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Two
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Shoes a = new Shoes(1);
            Shoes b = new Shoes(2);

            int bSize = (int)b;
        }
    }

    public struct Shoes
    {
        public int size;

        public Shoes(int size)
        {
            this.size = size;
        }

        public static implicit operator Shoes(int size) => new Shoes(size);
        public static explicit operator int (Shoes shoes) => shoes.size;
    }
}
