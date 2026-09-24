using System;

namespace KT_12_Point2D
{
    public struct Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                throw new ArgumentException(" Координаты X и Y не могут быть равны нулю ");
            }

            X = x;
            Y = y;
        }

        public Quadrant GetQuadrant()
        {
            if (X > 0 && Y > 0) return Quadrant.First;
            if (X < 0 && Y > 0) return Quadrant.Second;
            if (X < 0 && Y < 0) return Quadrant.Third;
            return Quadrant.Fourth;
        }

        public override string ToString()
        {
            return $"Точка ({X}, {Y}) -> Четверть: {GetQuadrant()}";
        }
    }
}