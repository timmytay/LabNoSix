using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LabNoSix.Particle;

namespace LabNoSix
{
    class Emitter
    {        
        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // <<< ТАК ВОТ

        // Добавляем счетчик всех созданных частиц
        public int ActiveParticlesCount
        {
            get { return particles.Count(p => p.Life > 0); }
        }


        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 1; // пусть гравитация будет силой один пиксель за такт, нам хватит

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 4; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public int ParticlesPerTick = 1; // добавил новое поле

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик

            foreach (var particle in particles)
            {
                if (particle.Life <= 0) // если частицы умерла
                {
                    /* 
                     * то проверяем надо ли создать частицу
                     */
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // это не трогаем
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public abstract class IImpactPoint
        {
            public float X; // ну точка же, вот и две координаты
            public float Y;

            // абстрактный метод с помощью которого будем изменять состояние частиц
            // например притягивать
            public abstract void ImpactParticle(Particle particle);

            // базовый класс для отрисовки точечки
            public virtual void Render(Graphics g)
            {
                g.FillEllipse(
                        new SolidBrush(Color.Red),
                        X - 5,
                        Y - 5,
                        10,
                        10
                    );

            }

        }
        public class GravityPoint : IImpactPoint
        {
            public int Power = 50; // сила притяжения
            public bool IsActive = true; // активен ли гравитон

            public override void ImpactParticle(Particle particle)
            {
                if (!IsActive) return; // если гравитон неактивен – ничего не делаем

                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY);
                if (r + particle.Radius < Power / 2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                    particle.SpeedX += gX * Power / r2;
                    particle.SpeedY += gY * Power / r2;
                }
            }

            public override void Render(Graphics g)
            {
                if (!IsActive) return; // если неактивен – не рисуем

                g.DrawEllipse(
                    new Pen(Color.Red),
                    X - Power / 2,
                    Y - Power / 2,
                    Power,
                    Power
                );

                var stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                g.DrawString(
                    $"{Power}",
                    new Font("Verdana", 14),
                    new SolidBrush(Color.White),
                    X,
                    Y,
                    stringFormat
                );
            }
        }

        public class CounterPoint : IImpactPoint
        {
            public int Count = 0;
            public int SmallCount = 0;    // < 5px
            public int MediumCount = 0;   // 5-10px
            public int LargeCount = 0;    // > 10px
            public int Radius = 40;

            // Базовый цвет счетчика
            private Color baseColor = Color.Orange;
            private const int MaxCountForSaturation = 1000; // Максимум для насыщенности

            public override void ImpactParticle(Particle particle)
            {
                float dx = X - particle.X;
                float dy = Y - particle.Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance < Radius + particle.Radius)
                {
                    Count++;

                    // Классификация частиц по размеру
                    if (particle.Radius < 5) SmallCount++;
                    else if (particle.Radius <= 7) MediumCount++;
                    else LargeCount++;

                    particle.Life = 0; // Уничтожаем частицу
                }
            }

            public override void Render(Graphics g)
            {
                // Рассчитываем насыщенность цвета (от 0.3 до 1.0) на основе 1000 частиц
                float saturation = 0.3f + (Math.Min(Count, MaxCountForSaturation) / (float)MaxCountForSaturation * 0.7f);
                Color circleColor = AdjustColorSaturation(baseColor, saturation);

                // Рисуем окружность
                g.DrawEllipse(
                    new Pen(circleColor, 2),
                    X - Radius,
                    Y - Radius,
                    Radius * 2,
                    Radius * 2
                );

                // Формируем текст с детализацией
                string info = $"Всего: {Count}\n" +
             $"Мелкие: {SmallCount}\n" +
             $"Средние: {MediumCount}\n" +
             $"Крупные: {LargeCount}";

                var stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;  // Выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center;  // Выравнивание по вертикали

                // Рисуем текст с переносами строк
                g.DrawString(
                    info,
                    new Font("Arial", 8),
                    new SolidBrush(Color.White),
                    new RectangleF(X - Radius, Y - Radius, Radius * 2, Radius * 2),
                    stringFormat
                );
            }

            // Метод для изменения насыщенности цвета (остается без изменений)
            private Color AdjustColorSaturation(Color color, float saturation)
            {
                float r = color.R / 255f;
                float g = color.G / 255f;
                float b = color.B / 255f;

                float max = Math.Max(r, Math.Max(g, b));
                float min = Math.Min(r, Math.Min(g, b));
                float h, s, l = (max + min) / 2f;

                if (max == min)
                {
                    h = s = 0f;
                }
                else
                {
                    float d = max - min;
                    s = l > 0.5f ? d / (2f - max - min) : d / (max + min);

                    if (max == r) h = (g - b) / d + (g < b ? 6f : 0f);
                    else if (max == g) h = (b - r) / d + 2f;
                    else h = (r - g) / d + 4f;

                    h /= 6f;
                }

                s = saturation;

                float q = l < 0.5f ? l * (1 + s) : l + s - l * s;
                float p = 2f * l - q;

                r = HueToRGB(p, q, h + 1f / 3f);
                g = HueToRGB(p, q, h);
                b = HueToRGB(p, q, h - 1f / 3f);

                return Color.FromArgb(color.A, (int)(r * 255), (int)(g * 255), (int)(b * 255));
            }

            private float HueToRGB(float p, float q, float t)
            {
                if (t < 0f) t += 1f;
                if (t > 1f) t -= 1f;
                if (t < 1f / 6f) return p + (q - p) * 6f * t;
                if (t < 1f / 2f) return q;
                if (t < 2f / 3f) return p + (q - p) * (2f / 3f - t) * 6f;
                return p;
            }
        }

        public class AntiGravityPoint : IImpactPoint
        {
            public int Power = 100; // сила отторжения

            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
                particle.SpeedY -= gY * Power / r2; // и тут
            }
        }

        public void Render(Graphics g)
        {
            // не трогаем
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints) // тут теперь  impactPoints
            {
                /* это больше не надо
                g.FillEllipse(
                    new SolidBrush(Color.Red),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
                */
                point.Render(g); // это добавили
            }
        }
        // добавил новый метод, виртуальным, чтобы переопределять можно было
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public class TopEmitter : Emitter
        {
            public int Width; // длина экрана

            public override void ResetParticle(Particle particle)
            {
                base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое

                // а теперь тут уже подкручиваем параметры движения
                particle.X = Particle.rand.Next(Width); // позиция X -- произвольная точка от 0 до Width
                particle.Y = 0;  // ноль -- это верх экрана 

                particle.SpeedY = 1; // падаем вниз по умолчанию
                particle.SpeedX = Particle.rand.Next(-2, 2); // разброс влево и вправа у частиц 
            }
        }
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;


            return particle;
        }
    }
}
