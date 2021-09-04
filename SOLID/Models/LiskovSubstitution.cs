using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Models
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle() { }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Area => Width * Height;
    }

    public class Square : Rectangle
    {
        public Square(int side)
        {
            Width = Height = side;
        }

        public new int Width
        {
            set { base.Width = base.Height = value; }
        }
        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
}
