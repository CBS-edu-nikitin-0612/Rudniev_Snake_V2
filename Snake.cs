using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Rudniev_Snake_V2
{
    class Snake
    {
        private Image imgHead_up = Properties.Resources.SnakeHead_up;
        private Image imgHead_down = Properties.Resources.SnakeHead_down;
        private Image imgHead_left = Properties.Resources.SnakeHead_left;
        private Image imgHead_right = Properties.Resources.SnakeHead_right;
        private Image imgBody = Properties.Resources.SnakeBody;
        public Image ImgHead_up { get => imgHead_up; }
        public Image ImgHead_down { get => imgHead_down; }
        public Image ImgHead_left { get => imgHead_left; }
        public Image ImgHead_right { get => imgHead_right; }
        public Image ImgBody { get => imgBody; }

        private int size;
        public Direction direction;
        public int[,] Location;
        private int[,] phantomTail;
        public int Size { get => size; set => size = value; }


        public Snake() : this(12) { }
        public Snake(int sizeArea)
        {
            size = 3;
            int center = sizeArea / 2;
            direction = Direction.up;
            this.Location = new int[size, 2];
            for (int i = 0; i < size; i++)
            {
                Location[i, 0] = center;
                Location[i, 1] = center + i;
            }
            phantomTail = new int[1, 2];
        }
        public void Move()
        {
            phantomTail[0, 0] = Location[size - 1, 0];
            phantomTail[0, 1] = Location[size - 1, 1];
            for (int i = size - 1; i > 0; i--)
            {
                Location[i, 0] = Location[i - 1, 0];
                Location[i, 1] = Location[i - 1, 1];
            }
            if (direction == Direction.up)
                Location[0, 1] -= 1;
            else if (direction == Direction.down)
                Location[0, 1] += 1;
            else if (direction == Direction.left)
                Location[0, 0] -= 1;
            else if (direction == Direction.right)
                Location[0, 0] += 1;
        }
        public void LengthUp()
        {
            int[,] temp = new int[size + 1, 2];
            temp[size, 0] = phantomTail[0, 0];
            temp[size, 1] = phantomTail[0, 1];
            for (int i = 0; i < size; i++)
            {
                temp[i, 0] = Location[i, 0];
                temp[i, 1] = Location[i, 1];
            }
            size = size + 1;
            Location = new int[size, 2];
            Location = temp;
        }
    }
}
