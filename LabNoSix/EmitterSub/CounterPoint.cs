using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNoSix.EmitterSub
{
    public class CounterPoint : IImpactPoint
    {
        public int Count = 0;
        public int SmallCount = 0;
        public int MediumCount = 0;
        public int LargeCount = 0;
        public int Radius = 40;

        private Color baseColor = Color.Orange;
        private const int MaxCountForSaturation = 1000;

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius + particle.Radius)
            {
                Count++;

                if (particle.Radius < 5) SmallCount++;
                else if (particle.Radius <= 7) MediumCount++;
                else LargeCount++;

                particle.Life = 0;
            }
        }

        public override void Render(Graphics g)
        {
            float saturation = 0.3f + (Math.Min(Count, MaxCountForSaturation) / (float)MaxCountForSaturation * 0.7f);
            Color circleColor = AdjustColorSaturation(baseColor, saturation);

            g.DrawEllipse(
                new Pen(circleColor, 2),
                X - Radius,
                Y - Radius,
                Radius * 2,
                Radius * 2
            );

            string info = $"Всего: {Count}\n" +
                          $"Мелкие: {SmallCount}\n" +
                          $"Средние: {MediumCount}\n" +
                          $"Крупные: {LargeCount}";

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(
                info,
                new Font("Arial", 8),
                new SolidBrush(Color.White),
                new RectangleF(X - Radius, Y - Radius, Radius * 2, Radius * 2),
                stringFormat
            );
        }

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
}
