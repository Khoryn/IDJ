using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralepipedo
{
    class Paralepipedo
    {
        private int height;
        private int width;
        private int length;

        public Paralepipedo()
        {
            height = 0;
            width = 0;
            length = 0;
        }

        public Paralepipedo(int n)
        {
            height = n;
            width = n;
            length = n;
        }

        public Paralepipedo(int h, int w, int l)
        {
            height = h;
            width = w;
            length = l;
        }

        public int Height
        {
            get { return height; }
            set
            {
                height = value;

                if (value < 0)
                {
                    height = 0;
                }
            }
        }

        public int Width
        {
            get { return width; }
            set
            {
                width = value;

                if (value < 0)
                {
                    width = 0;
                }
            }
        }

        public int Length
        {
            get { return length; }
            set
            {
                length = value;

                if (value < 0)
                {
                    length = 0;
                }
            }
        }

        public int Volume()
        {
            int value = height * width * length;

            return value;
        }

        public int TotalArea()
        {
            int value = ((2 * height * width) + (2 * height * length) + (2 * width * length));

            return value;
        }

        public string ConvertToString()
        {
            string value = "The height is " + height + " | " + " The width is " + width + " | " + " The length is " + length;

            return value;
        }

        public bool IsACube()
        {
            if (height == width && width == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Is3D()
        {
            if (height != 0 && width != 0 && length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
