using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Rudniev_Snake_V2
{
    class Model
    {
        public Area area;
        public Snake snake;
        public Food food;

        private int sizeArea;
        public int SpeedGame;
        public Status gameStatus;
        public Model(int sizeArea, int speedGame)
        {
            area = new Area(sizeArea);
            snake = new Snake(sizeArea);
            food = new Food(sizeArea, snake);

            this.sizeArea = sizeArea;
            this.SpeedGame = speedGame;
            this.gameStatus = Status.play;
        }

        public void Play()
        {
            while (gameStatus != Status.over)
            {
                Thread.Sleep(SpeedGame);
                snake.Move();
                gameStatus = statusCheck();
                if (gameStatus == Status.over)
                    return;
                if (gameStatus == Status.eat)
                {
                    EatFood();
                    if (SpeedGame > 100)
                        SpeedGame -= 20;
                    gameStatus = Status.play;
                }
            }
        }

        private Status statusCheck()
        {
            if (area.Grid[snake.Location[0, 1], snake.Location[0, 0]] == 1)
                return Status.over;
            else if (snake.Location[0, 0] == food.X && snake.Location[0, 1] == food.Y)
                return Status.eat;
            for (int i = 2; i < snake.Size; i++)
                if (snake.Location[0, 0] == snake.Location[i, 0] && snake.Location[0, 1] == snake.Location[i, 1])
                    return Status.over;
            return Status.play;
        }
        private void EatFood()
        {
            this.snake.LengthUp();
            this.food = new Food(sizeArea, snake);
        }
    }
}
