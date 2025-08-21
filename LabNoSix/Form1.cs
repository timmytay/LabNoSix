using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LabNoSix.Emitter;
using static LabNoSix.Particle;

namespace LabNoSix
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера

        GravityPoint point; // добавил поле под первую точку

        public Form1()
        {

            InitializeComponent();
            picDisplay.MouseWheel += picDisplay_MouseWheel;
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Olive,
                ColorTo = Color.FromArgb(0, Color.LimeGreen),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);
            // до сюда НЕ ТРОГАЕМ

            // привязываем гравитоны к полям
            point = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
                IsActive = false
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point);
        }

        int counter = 0; // добавлю счетчик чтобы считать вызовы функции
        double tempSpeed = 0;
        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            lblActiveParticles.Text = $"Частицы: {emitter.ActiveParticlesCount.ToString()}";
            picDisplay.Invalidate();
        }

        // добавляем переменные для хранения положения мыши
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // это не трогаем
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point.X = e.X;
            point.Y = e.Y;
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // ЛКМ – добавить счетчик
            {
                var counter = new CounterPoint
                {
                    X = e.X,
                    Y = e.Y
                };
                emitter.impactPoints.Add(counter);
            }
            else if (e.Button == MouseButtons.Right) // ПКМ – удалить ближайший
            {
                // Ищем ближайший счетчик
                CounterPoint closest = null;
                float minDist = float.MaxValue;

                foreach (var point in emitter.impactPoints.OfType<CounterPoint>())
                {
                    float dx = point.X - e.X;
                    float dy = point.Y - e.Y;
                    float distance = dx * dx + dy * dy;

                    if (distance < minDist)
                    {
                        minDist = distance;
                        closest = point;
                    }
                }

                if (closest != null)
                    emitter.impactPoints.Remove(closest);
            }
        }

        private void chbGraviton_CheckedChanged(object sender, EventArgs e)
        {
            point.IsActive = chbGraviton.Checked; // включаем/выключаем гравитон
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            // Находим ближайший CounterPoint
            CounterPoint closestCounter = null;
            float minDistance = float.MaxValue;

            foreach (var point in emitter.impactPoints.OfType<CounterPoint>())
            {
                float dx = point.X - e.X;
                float dy = point.Y - e.Y;
                float distance = dx * dx + dy * dy;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCounter = point;
                }
            }

            // Если нашли CounterPoint и он близко к курсору (например, в радиусе 100px)
            if (closestCounter != null && minDistance < 10000) // 100px * 100px = 10000
            {
                // Изменяем радиус с проверкой границ
                int newRadius = closestCounter.Radius + (e.Delta > 0 ? 5 : -5);
                closestCounter.Radius = Math.Max(10, Math.Min(200, newRadius));
            }
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point.Power = tbGraviton.Value;
            lblGraviton.Text = $"{tbGraviton.Value} ед."; // добавил вывод значения
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value;
            lblSpreading.Text = $"{tbSpreading.Value}°"; // добавил вывод значения
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = tbSpeed.Value / 5;
            emitter.SpeedMax = tbSpeed.Value;
            lblSpeed.Text = $"{tbSpeed.Value} см/с"; // добавил вывод значения
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            emitter.LifeMax = tbLife.Value;
            tempSpeed = tbLife.Value / 5;
            emitter.LifeMin = (int)Math.Round(tempSpeed);
            lblLife.Text = $"{tbLife.Value} т.";
        }

        private void tbParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbParticlesPerTick.Value;
            lblParticlesPerTick.Text = $"{tbParticlesPerTick.Value} ч/т";
        }
    }
}
