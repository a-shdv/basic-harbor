﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBoat
{
    public partial class FormBoat : Form
    {
        private Boat boat;

        // Конструктор
        public FormBoat()
        {
            InitializeComponent();
        }
        
        // Метод отрисовки лодки
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBoats.Width, pictureBoxBoats.Height);
            Graphics gr = Graphics.FromImage(bmp);
            boat.DrawTransport(gr);
            pictureBoxBoats.Image = bmp;
        }

        // Обработка нажатия кнопки "Create"
        private void buttonCreate_Click(object sender, EventArgs e)
        { 
            Random rnd = new Random();
            boat= new Boat();
            boat.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Khaki, Color.DeepSkyBlue, true, true, true, true);
            boat.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBoats.Width, pictureBoxBoats.Height);
            Draw();
        }

        // Обработка нажатия кнопок перемещения
        private void buttonMove_Click(object sender, EventArgs e)
        {
            // Получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    boat.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    boat.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    boat.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    boat.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
