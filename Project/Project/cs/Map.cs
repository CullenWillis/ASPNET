using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Project.cs
{
    public class Map
    {
        private Stack<Triangles> triangles;

        private double[,] grid;

        private int columns;
        private int rows;
        private int resolution;

        public Map()
        {
            grid = null;

            columns = 60;
            rows = 60;
            resolution = 10;

            makeGrid();

            populateTriangles();

            if (grid != null)
                System.Diagnostics.Debug.WriteLine("Grid have been intialized.");

            if(triangles != null)
            {
                System.Diagnostics.Debug.WriteLine("Triangles have been intialized.");
            }
        }

        private double[,] make2DArray(int cols, int rows)
        {
            double[,] array = new double[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    array[x, y] = y;
                }
            }

            return array;
        }

        private void makeGrid()
        {
            Random rnd = new Random();
            rows = rows / resolution;
            columns = columns / resolution;

            grid = make2DArray(rows, columns);

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    double random = rnd.Next(2);
                    double floor = Math.Floor(random);

                    grid[x, y] = floor;
                }
            }
        }

        private void populateTriangles()
        {
            triangles = new Stack<Triangles>();
            
            Point p1;
            Point p2;
            Point p3;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    p1 = new Point(i * resolution, j * resolution);
                    p2 = new Point((i + 1) * resolution, (j + 1) * resolution);
                    p3 = new Point(i * resolution, (j + 1) * resolution);

                    
                    triangles.Push(getStack(p1, p2, p3));

                    p2 = new Point((i + 1) * resolution, j * resolution);
                    p3 = new Point((i + 1) * resolution, (j + 1) * resolution);

                    triangles.Push(getStack(p1, p2, p3));
                }
            }
        }

        private Triangles getStack(Point p1, Point p2, Point p3)
        {
            Triangles temp = new Triangles();

            temp.point1 = p1;
            temp.point2 = p2;
            temp.point3 = p3;

            return temp;
        }

        public void getLocation()
        {

        }
    }
}