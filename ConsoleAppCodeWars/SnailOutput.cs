using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeWars
{
    public class SnailOutput
    {
        private enum Vector
        {
            Up,
            Down,
            Left,
            Right,
            End
        }

        private List<Point> points;
        private int[][] ints;
        private int _size;
        private delegate Vector ReadVector(Point pointStart);

        public SnailOutput(int size)
        {
            _size = size;
            points = new List<Point>();
            ints = InitArray(size);
        }

        private int[][] InitArray(int size)
        {
            int num = 0;
            ints = new int[size][];
            for (int i = 0; i < size; i++)
            {
                ints[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    num++;
                    Console.WriteLine($"|{i}|{j}| = {num}");
                    ints[i][j] = num;
                }
            }
            return ints;
        }
        private bool IsReadable(Point point)
        => (points.FirstOrDefault(x => x.X == point.X && x.Y == point.Y) == null) &&
        (point.X < _size) && (point.Y < _size) && (point.X >= 0) && (point.Y >= 0) ?
        true : false;
        private bool TryAddPoints(Point point)
        {
            if (IsReadable(point))
            {
                points.Add(point);
                return true;
            }
            else
                return false;
        }
        private void Operarion(ref Point point, Vector vector)
        {
            if (vector == Vector.Right)
                point.Y++;
            else if (vector == Vector.Down)
                point.X++;
            else if (vector == Vector.Left)
                point.Y--;
            else if (vector == Vector.Up)
                point.X--;
        }
        private Vector SwapVector(Vector vector)
        {
            if (vector == Vector.Right)
                return Vector.Down;
            else if (vector == Vector.Down)
                return Vector.Left;
            else if (vector == Vector.Left)
                return Vector.Up;
            else if (vector == Vector.Up)
                return Vector.Right;
            throw new Exception("The vector is not initialized");
        }
        private Vector Read(Point pointStart, Vector vector)
        {
            if (points.Count != 0)
                points.Remove(points.Last());
            Point activepoint = pointStart;
            int i = 0;
            while (TryAddPoints(new Point(activepoint)))
            {
                Operarion(ref activepoint, vector);
                i++;
            }
            if (i == 1)
                return Vector.End;
            else
                return SwapVector(vector);
        }
        private Point SetStartPoint(Point point)
        {
            if (point == null)
                return new Point(0, 0);
            else
                return points.Last();
        }
        public void Select()
        {
            string text = String.Empty; 
            points.ForEach(p => text+= $"{ints[p.X][p.Y]}, ");
            text = text.Remove(text.Length-2, 2);
            Console.WriteLine(text);
        }
        public void Reading()
        {
            Point startpoint = null;
            Vector vector = Vector.Right;
            while (true)
            {
                startpoint = SetStartPoint(startpoint);
                vector = Read(startpoint, vector);
                if (vector == Vector.End)
                    break;
            }
        }
    }
}
