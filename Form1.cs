using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Rudniev_Snake_V2
{
    public partial class MainForm : Form
    {
        View view;
        Model model;

        Thread modelPlay;

        public MainForm() : this(12) { }
        public MainForm(int sizeArea) : this(sizeArea, 1000) { }
        public MainForm(int sizeArea, int speedGame)
        {
            InitializeComponent();
            model = new Model(sizeArea, speedGame);

            view = new View(model);
            view.Width = sizeArea * 20;
            view.Height = sizeArea * 20;
            this.Controls.Add(view);
            this.Width = view.Width + 16;
            this.Height = view.Height + 39;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            modelPlay = new Thread(model.Play);
            modelPlay.Start();
            if (model.gameStatus == Status.over)
                modelPlay.Abort();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
                modelPlay.Abort();
            MessageBox.Show($"Game over! Your score: {(model.snake.Size - 3) * 10}", "Snake");
        }
    }
}
