using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Rudniev_Snake_V2
{
    class Food
    {
        private Image imgFood = Properties.Resources.Food;
        public Image ImgFood { get => imgFood; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Food(int sizeArea, Snake snake)
        {
            bool temp;
            do
            {
                temp = false;
                X = new Random().Next(1, sizeArea - 2);
                Y = new Random().Next(1, sizeArea - 2);
                for (int i = 0; i < snake.Location.Length / 2; i++)
                    if (X == snake.Location[i, 1] && Y == snake.Location[i, 0])
                        temp = true;
            } while (temp);
        }
    }
}
