﻿using System;

namespace Geometria
{
    public class Punto
    {
        private int x;
        private int y;

        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX { get { return this.x; } }
        public int GetY { get { return this.y; } }

    }
}
