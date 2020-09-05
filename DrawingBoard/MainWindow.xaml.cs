using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawingBoard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle background = new Rectangle();
        Brush fillColor = Brushes.White, lineColor = Brushes.Black;
        Line drawLine;
        Rectangle drawRectangle;
        Polygon drawTriangle;
        PointCollection TrianglePoint;
        Point mousePoint1, mousePoint2;
        bool onClickingMouse = false;
        int shape = 3;
        public MainWindow()
        {
            InitializeComponent();
            background.Width = 1000 - 15;
            background.Height = 500 - 88;
            background.Fill = Brushes.White;
            MainCanvas.Children.Add(background);

            MainCanvas.Children.Add(DrawTriangle(100, 100, 200, 200));
        }
        public Shape DrawShape(double x1, double y1, double x2, double y2)
        {
            switch (shape)
            {
                case 1:
                    return DrawLine(x1, y1, x2, y2);
                case 2:
                    return DrawRectangle(x1, y1, x2, y2);
                case 3:
                    return DrawTriangle(x1, y1, x2, y2);
                default:
                    return DrawLine(0, 0, 0, 0);
            }
        }
        public Rectangle DrawRectangle(double x1, double y1, double x2, double y2)
        {
            drawRectangle = new Rectangle();
            drawRectangle.Width = (x1 > x2 ? x1 : x2) - (x1 < x2 ? x1 : x2);
            drawRectangle.Height = (y1 > y2 ? y1 : y2) - (y1 < y2 ? y1 : y2);
            drawRectangle.Fill = fillColor;
            drawRectangle.Stroke = lineColor;
            drawRectangle.StrokeThickness = 1;
            Canvas.SetLeft(drawRectangle, (x1 < x2 ? x1 : x2));
            Canvas.SetTop(drawRectangle, (y1 < y2 ? y1 : y2));
            return drawRectangle;
        }
        public Line DrawLine(double x1, double y1, double x2, double y2)
        {
            drawLine = new Line();
            drawLine.X1 = x1;
            drawLine.Y1 = y1;
            drawLine.X2 = x2;
            drawLine.Y2 = y2;
            drawLine.Stroke = lineColor;
            drawLine.StrokeThickness = 1;
            return drawLine;
        }
        public Polygon DrawTriangle(double x1, double y1, double x2, double y2)
        {
            drawTriangle = new Polygon();
            TrianglePoint = new PointCollection();

            TrianglePoint.Add(new Point((x1 < x2 ? x1 : x2), (y1 > y2 ? y1 : y2)));
            TrianglePoint.Add(new Point((x1 < x2 ? x1 : x2) + (((x1 > x2 ? x1 : x2) - (x1 < x2 ? x1 : x2)) / 2), (y1 < y2 ? y1 : y2)));
            TrianglePoint.Add(new Point((x1 > x2 ? x1 : x2), (y1 > y2 ? y1 : y2)));

            drawTriangle.Points = TrianglePoint;
            drawTriangle.Fill = fillColor;
            drawTriangle.Stroke = lineColor;
            drawTriangle.StrokeThickness = 1;

            return drawTriangle;
        }
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            onClickingMouse = true;
            mousePoint1 = GetMousePosition();
            //PositionX1.Text = mousePoint1.X.ToString();
            //PositionY1.Text = mousePoint1.Y.ToString();
            MainCanvas.Children.Add(DrawShape(mousePoint1.X, mousePoint1.Y, mousePoint1.X, mousePoint1.Y));
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            onClickingMouse = false;
            mousePoint2 = GetMousePosition();
            //PositionX2.Text = mousePoint2.X.ToString();
            //PositionY2.Text = mousePoint2.Y.ToString();
        }

        private void LineButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            shape = 1;
        }
        private void RectangleButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            shape = 2;
        }
        private void TriangleButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            shape = 3;
        }


        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClickingMouse)
            {
                switch (shape)
                {
                    case 1:
                        mousePoint2 = GetMousePosition();
                        drawLine.X2 = mousePoint2.X;
                        drawLine.Y2 = mousePoint2.Y;
                        break;
                    case 2:
                        mousePoint2 = GetMousePosition();
                        drawRectangle.Width = (mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X) - (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X);
                        drawRectangle.Height = (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y) - (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        Canvas.SetLeft(drawRectangle, (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X));
                        Canvas.SetTop(drawRectangle, (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y));
                        break;
                    case 3:
                        mousePoint2 = GetMousePosition();
                        TrianglePoint.Clear();
                        TrianglePoint.Add(new Point((mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X), (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        TrianglePoint.Add(new Point((mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X) + (((mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X) - (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X)) / 2), (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        TrianglePoint.Add(new Point((mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X), (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        break;
                }
            }
        }

        private void LineColorPicker_Changed(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            lineColor = new SolidColorBrush(e.NewValue.Value);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            background.Height = e.NewSize.Height - 88;
            background.Width = e.NewSize.Width - 15;
        }

        private void FillColorPicker_Changed(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fillColor = new SolidColorBrush(e.NewValue.Value);
        }

        public Point GetMousePosition()
        {
            return Mouse.GetPosition(MainCanvas);
        }
    }
}
