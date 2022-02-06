using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Rudniev_Snake_V2
{
    partial class View : UserControl
    {
        Model model;
        public View(Model model)
        {
            InitializeComponent();
            this.model = model;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < model.area.Size; i++)
                for (int j = 0; j < model.area.Size; j++)
                    if (model.area.Grid[i, j] == 1)
                        e.Graphics.DrawImage(model.area.ImgWall, new Point(i * 20, j * 20));
            e.Graphics.DrawImage(model.food.ImgFood, new Point(model.food.X * 20, model.food.Y * 20));
            for (int i = 1; i < model.snake.Size; i++)
                e.Graphics.DrawImage(model.snake.ImgBody, new Point(model.snake.Location[i, 0] * 20, model.snake.Location[i, 1] * 20));
            switch (model.snake.direction)
            {
                case Direction.up:
                    e.Graphics.DrawImage(model.snake.ImgHead_up, new Point(model.snake.Location[0, 0] * 20, model.snake.Location[0, 1] * 20));
                    break;
                case Direction.down:
                    e.Graphics.DrawImage(model.snake.ImgHead_down, new Point(model.snake.Location[0, 0] * 20, model.snake.Location[0, 1] * 20));
                    break;
                case Direction.left:
                    e.Graphics.DrawImage(model.snake.ImgHead_left, new Point(model.snake.Location[0, 0] * 20, model.snake.Location[0, 1] * 20));
                    break;
                case Direction.right:
                    e.Graphics.DrawImage(model.snake.ImgHead_right, new Point(model.snake.Location[0, 0] * 20, model.snake.Location[0, 1] * 20));
                    break;
            }

            if (model.gameStatus == Status.over)
                return;

            Thread.Sleep(model.SpeedGame);
            Invalidate();
        }

        private void View_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToUpper() == "W" && model.snake.direction != Direction.down)
                model.snake.direction = Direction.up;
            else if (e.KeyChar.ToString().ToUpper() == "S" && model.snake.direction != Direction.up)
                model.snake.direction = Direction.down;
            else if (e.KeyChar.ToString().ToUpper() == "A" && model.snake.direction != Direction.right)
                model.snake.direction = Direction.left;
            else if (e.KeyChar.ToString().ToUpper() == "D" && model.snake.direction != Direction.left)
                model.snake.direction = Direction.right;
        }
    }
}
