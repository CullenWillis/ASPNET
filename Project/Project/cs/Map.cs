using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Project.cs
{
    public class Map
    {
        public Stack<Triangles> triangles;

        private readonly int columns;
        private readonly int rows;
        private readonly int resolution;

        private int IDCount = 1;

        // Constructor
        public Map()
        {
            columns = 600;
            rows = 600;
            resolution = 100;

            PopulateTriangles();
        }

        // Fill the stack with Triangle objects
        private void PopulateTriangles()
        {
            triangles = new Stack<Triangles>();

            Point p1;
            Point p2;
            Point p3;

            // Loop through gird and plot 3 coordinates to make triangles
            for (int y = 0; y < columns; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    // Get points
                    p1 = new Point(x * resolution, (y + 1) * resolution);
                    p2 = new Point(x * resolution, y * resolution);
                    p3 = new Point((x + 1) * resolution, (y + 1) * resolution);

                    // Fill Stack with points
                    triangles.Push(GetStack(y, 1, p1, p2, p3));

                    // Get points
                    p1 = new Point((x + 1) * resolution, y * resolution);

                    // Fill Stack with points
                    triangles.Push(GetStack(y, 2, p1, p2, p3));
                }
            }
        }

        // create and return a new Triangle object
        private Triangles GetStack(int y, int half, Point p1, Point p2, Point p3)
        {
            // Make temp of triangles and fill necessary data
            Triangles temp = new Triangles
            {
                ID = GetID(y, half),
                point1 = p1,
                point2 = p2,
                point3 = p3
            };

            return temp;
        }

        // Calculate the ID based of y axis and which half the triangle is on
        private string GetID(int y, int half)
        {
            string ID = "";

            // Get letter based on Y value
            if (y == 0)
            {
                ID = "A";
            }
            else if (y == 1)
            {
                ID = "B";
            }
            else if (y == 2)
            {
                ID = "C";
            }
            else if (y == 3)
            {
                ID = "D";
            }
            else if (y == 4)
            {
                ID = "E";
            }
            else if (y == 5)
            {
                ID = "F";
            }

            // Concatenate count onto String
            ID += IDCount;

            // If count reaches max limit (12) reset, else increment by 1
            if(IDCount == 12)
            {
                IDCount = 1;
            }
            else
            {
                IDCount++;
            }

            return ID;
        }
        
        // Calculate the coordinates of the triangle
        public string GetLocation(Point v1, Point v2, Point v3)
        {
            string location = "";

            // Loop through triangles
            foreach(Triangles t in triangles)
            {
                // If coordinates match create string defining where the triangle is
                if (t.point1 == v1 && t.point2 == v2 && t.point3 == v3)
                {
                    int y = (t.point3.X / resolution);
                    int x = (t.point3.Y / resolution);
                    location = "This triangle is in row: " + x + ", column: " + y + " and is titled '" + t.ID + "'";
                }
            }

            // if coordinates don't match produce error string
            if(location == "")
            {
                location = "Invalid location, please try again.";
            }

            return location;
        }
    }
}