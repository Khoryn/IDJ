using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retangulo
{
    class Rectangle
    {
        private int length;
        private int width;


        // Constructors

        public Rectangle()
        {

        }

        public Rectangle(int l, int w)
        {
            length = l;
            width = w;
        }

        public int Width
        {
            get { return width; }
            set
            {
                width = value;

                if (value < 1)
                {
                    width = 1;
                }
                if (value > 20)
                {
                    width = 20;
                }
            }
        }

        // Properties

        public int Length
        {
            get { return length; }
            set
            {
                length = value;

                if (value < 1)
                {
                    length = 1;
                }
                if (value > 20)
                {
                    length = 20;
                }
            }
        }

        public int Perimeter()
        {
            int value = 2 * (length + width);

            return value;
        }

        public int Area()
        {
            int value = length * width;

            return value;
        }

        public bool Square()
        {
            if (length == width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ConvertToString()
        {
            string value = "The dimensions are " + length + " and " + width;

            return value;
        }
    }
}
