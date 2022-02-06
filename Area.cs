using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Rudniev_Snake_V2
{
    class Area
    {
        private Image imgWall = Properties.Resources.Wall;
        public Image ImgWall { get => imgWall; }

        private int size;
        public int Size
        {
            get => size;
            set
            {
                if (value <= 12)
                    size = 12;
                else if (value <= 16)
                    size = 16;
                else if (value <= 20)
                    size = 20;
                else
                    size = 24;
            }
        }

        private int[,] grid;
        public int[,] Grid { get => grid; set => grid = value; }

        private int[,] createGrid(int size)
        {
            int[,] temp = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == 0)
                        temp[i, j] = 1;
                    else if (i + 1 == size)
                        temp[i, j] = 1;
                    else if (j == 0)
                        temp[i, j] = 1;
                    else if (j + 1 == size)
                        temp[i, j] = 1;
                    else
                        temp[i, j] = 0;
            return temp;
        }

        public Area() : this(12) { }
        public Area(int size)
        {
            this.Size = size;
            this.grid = createGrid(this.size);
        }

    }
}
