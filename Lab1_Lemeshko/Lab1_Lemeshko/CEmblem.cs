using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab1_Lemeshko
{
    class CEmblem
    {
        // Константи
        const int DefaultRadius = 50; // Радіус кола за замовчуванням, пікс
       
                                      // Поля
        private Graphics graphics;
        private int _radius; // Підтримуюче поле для властивості Radius
                             // Властивості
        public int X { get; set; } // Координата X центра кола
        public int Y { get; set; } // Координата Y центра кола
        public int Radius
        { // Радіус кола
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }


            // Конструктор, створює об'єкт кола (для заданої поверхні
            // малювання GDI+) з заданими координатами.
            // Радіус кола приймається за замовчуванням
      public CEmblem(Graphics graphics, int X, int Y)

      {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = DefaultRadius;

       }

        // Конструктор, створює об'єкт кола (для заданої поверхні
        // малювання GDI+) з заданими координатами та радіусом
        public CEmblem(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }
        public Point RotatePoint(Point pointToRotate, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 90);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            int x = (int)(cosTheta * (pointToRotate.X) - sinTheta * (pointToRotate.Y));
            int y = (int)(sinTheta * (pointToRotate.X) + cosTheta * (pointToRotate.Y));
            return new Point(x, y);
        }
        // Малює коло на поверхні малювання GDI+.
        // Параметри кола задає перо pen
        private void Draw(Pen pen)
        {
            // Малюємо коло
            Rectangle circleRect = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, circleRect);

            // Малюємо квадрат
            int squareSideLength = 2 * Radius;
            Rectangle squareRect = new Rectangle(X - 2 * Radius - squareSideLength / 2, Y - squareSideLength / 2, squareSideLength, squareSideLength);
            graphics.DrawRectangle(pen, squareRect);

            // Малюємо трикутник
            Point[] originalTrianglePoints = new Point[]
            {
        new Point(X + 2 * Radius, Y - squareSideLength / 2),
        new Point(X + 2 * Radius + squareSideLength / 2, Y + squareSideLength / 2),
        new Point(X + 2 * Radius - squareSideLength / 2, Y + squareSideLength / 2)
            };

            // Створюємо матрицю обертання на 90 градусів
            float angle = 90; // Кут обертання в градусах
            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(angle, new Point(X + 2 * Radius, Y)); // Вказуємо точку обертання

            // Копіюємо вершини трикутника
            Point[] rotatedTrianglePoints = (Point[])originalTrianglePoints.Clone();

            // Застосовуємо обертання до вершин трикутника
            rotationMatrix.TransformPoints(rotatedTrianglePoints);

            // Малюємо обернутий трикутник
            graphics.DrawPolygon(pen, rotatedTrianglePoints);
        }

        // Показує коло (малює на поверхні малювання GDI+ кольором
        // переднього плану)
        public void Show()
        {
            Draw(Pens.Red);
        }
        // Приховує коло (малює на поверхні малювання GDI+ кольором фону)
        public void Hide()
        {
            Draw(Pens.White);
        }
        // Розширює коло: збільшує радіус на один піксель
        public void Expand()
        {
            Hide();
            Radius++;
            Show();
        }
        // Розширює коло: збільшує радіус на dR пікселів
        public void Expand(int dR)
        {
            Hide();
            Radius = Radius + dR;
            Show();
        }
        // Стискає коло: зменшує радіус на один піксель
        public void Collapse()
        {
            Hide();
            Radius--;
            Show();
        }
        // Стискає коло: зменшує радіус на dR пікселів
        public void Collapse(int dR)
        {
            Hide();
            Radius = Radius - dR;
            Show();
        }
        // Переміщує коло
        public void Move(int dX, int dY)
        {
            Hide();
            X = X + dX;
            Y = Y + dY;
            Show();
        }
    } // Кінець оголошення класу
}