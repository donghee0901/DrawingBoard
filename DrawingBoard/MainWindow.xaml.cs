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
        Ellipse[] ShapeControlDot = new Ellipse[8];
        Rectangle background = new Rectangle();
        Brush fillColor = Brushes.White, lineColor = Brushes.Black;
        Line drawLine;
        Rectangle drawRectangle;
        Polygon drawTriangle;
        PointCollection TrianglePoint;
        Ellipse drawCircle;
        Point mousePoint1, mousePoint2;
        Point controlDotMousePoint1, controlDotMousePoint2;
        bool onClickDrawShape = false;
        bool onClickContorlDot = false;
        int shape = 1;
        public MainWindow()
        {
            InitializeComponent();
            background.Width = 1000 - 15;
            background.Height = 500 - 88;
            background.Fill = Brushes.White;
            MainCanvas.Children.Add(background);
            SettingShapeControlDot();
            ShowShapeControlDot(10, 10, 100, 100);
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
                case 4:
                    return DrawCircle(x1, y1, x2, y2);
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
        public Ellipse DrawCircle(double x1, double y1, double x2, double y2)
        {
            drawCircle = new Ellipse();
            drawCircle.Width = (x1 > x2 ? x1 : x2) - (x1 < x2 ? x1 : x2);
            drawCircle.Height = (y1 > y2 ? y1 : y2) - (y1 < y2 ? y1 : y2);
            drawCircle.Fill = fillColor;
            drawCircle.Stroke = lineColor;
            drawCircle.StrokeThickness = 1;
            Canvas.SetLeft(drawCircle, (x1 < x2 ? x1 : x2));
            Canvas.SetTop(drawCircle, (y1 < y2 ? y1 : y2));
            return drawCircle;
        }

        void SettingShapeControlDot()
        {
            for(int i = 0; i < 8; i++)
            {
                ShapeControlDot[i] = new Ellipse();
                ShapeControlDot[i].Width = 5;
                ShapeControlDot[i].Height = 5;
                ShapeControlDot[i].Fill = Brushes.White;
                ShapeControlDot[i].Stroke = Brushes.Black;
                ShapeControlDot[i].StrokeThickness = 2;
                ShapeControlDot[i].Visibility = Visibility.Collapsed;
                ShapeControlDot[i].MouseDown += ShapeControlDot_MouseDown;
                ShapeControlDot[i].MouseDown += ShapeControlDot_MouseDown;
                ShapeControlDot[i].Name = ("ID_" + (i + 1).ToString());
                Panel.SetZIndex(ShapeControlDot[i], 10);
                MainCanvas.Children.Add(ShapeControlDot[i]);
            }
        }
        void ShowShapeControlDot(double x1, double y1, double x2, double y2)
        {
            Canvas.SetLeft(ShapeControlDot[0], (x1 < x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[0], (y1 < y2 ? y1 : y2) - 2);

            Canvas.SetLeft(ShapeControlDot[1], ((x1 < x2 ? x1 : x2) + (((x1 > x2 ? x1 : x2) - (x1 < x2 ? x1 : x2)) / 2)) - 2);
            Canvas.SetTop(ShapeControlDot[1], (y1 < y2 ? y1 : y2) - 2);

            Canvas.SetLeft(ShapeControlDot[2], (x1 > x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[2], (y1 < y2 ? y1 : y2) - 2);

            Canvas.SetLeft(ShapeControlDot[3], (x1 < x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[3], ((y1 < y2 ? y1 : y2) + (((y1 > y2 ? y1 : y2) - (y1 < y2 ? y1 : y2)) / 2)) - 2);

            Canvas.SetLeft(ShapeControlDot[4], (x1 > x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[4], ((y1 < y2 ? y1 : y2) + (((y1 > y2 ? y1 : y2) - (y1 < y2 ? y1 : y2)) / 2)) - 2);

            Canvas.SetLeft(ShapeControlDot[5], (x1 < x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[5], (y1 > y2 ? y1 : y2) - 2);

            Canvas.SetLeft(ShapeControlDot[6], ((x1 < x2 ? x1 : x2) + (((x1 > x2 ? x1 : x2) - (x1 < x2 ? x1 : x2)) / 2)) - 2);
            Canvas.SetTop(ShapeControlDot[6], (y1 > y2 ? y1 : y2) - 2);

            Canvas.SetLeft(ShapeControlDot[7], (x1 > x2 ? x1 : x2) - 2);
            Canvas.SetTop(ShapeControlDot[7], (y1 > y2 ? y1 : y2) - 2);

            for(int i = 0; i < 8; i++)
            {
                ShapeControlDot[i].Visibility = Visibility.Visible;
            }
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
        private void CircleButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            shape = 4;
        }

        string selectID;
        private void ShapeControlDot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectID = (sender as DependencyObject).GetValue(Ellipse.NameProperty) as string;

            onClickContorlDot = true;
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            onClickDrawShape = true;
            mousePoint1 = GetMousePosition();
            //PositionX1.Text = mousePoint1.X.ToString();
            //PositionY1.Text = mousePoint1.Y.ToString();
            MainCanvas.Children.Add(DrawShape(mousePoint1.X, mousePoint1.Y, mousePoint1.X, mousePoint1.Y));
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(onClickContorlDot)
            {
                switch (selectID)
                {
                    case "ID_1":
                        controlDotMousePoint1 = GetMousePosition();
                        break;
                    case "ID_2":
                        controlDotMousePoint1.Y = GetMousePosition().Y;
                        break;
                    case "ID_3":
                        controlDotMousePoint1 = GetMousePosition();
                        break;
                    case "ID_4":
                        controlDotMousePoint1.X = GetMousePosition().X;
                        break;
                    case "ID_5":
                        controlDotMousePoint2.X = GetMousePosition().X;
                        break;
                    case "ID_6":
                        controlDotMousePoint1 = GetMousePosition();
                        break;
                    case "ID_7":
                        controlDotMousePoint2.Y = GetMousePosition().Y;
                        break;
                    case "ID_8":
                        controlDotMousePoint2 = GetMousePosition();
                        break;
                }
                ShowShapeControlDot(controlDotMousePoint1.X, controlDotMousePoint1.Y, controlDotMousePoint2.X, controlDotMousePoint2.Y);
            }
            else if (onClickDrawShape)
            {
                mousePoint2 = GetMousePosition();

                switch (shape)
                {
                    case 1:
                        drawLine.X1 = mousePoint1.X;
                        drawLine.Y1 = mousePoint1.Y;
                        drawLine.X2 = mousePoint2.X;
                        drawLine.Y2 = mousePoint2.Y;
                        break;
                    case 2:
                        drawRectangle.Width = (mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X) - (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X);
                        drawRectangle.Height = (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y) - (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        Canvas.SetLeft(drawRectangle, (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X));
                        Canvas.SetTop(drawRectangle, (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y));
                        break;
                    case 3:
                        TrianglePoint.Clear();
                        TrianglePoint.Add(new Point((mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X), (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        TrianglePoint.Add(new Point((mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X) + (((mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X) - (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X)) / 2), (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        TrianglePoint.Add(new Point((mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X), (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y)));
                        break;
                    case 4:
                        drawCircle.Width = (mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X) - (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X);
                        drawCircle.Height = (mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y) - (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        Canvas.SetLeft(drawCircle, (mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X));
                        Canvas.SetTop(drawCircle, (mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y));
                        break;
                }
            }
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mousePoint2 = GetMousePosition();

            if (onClickContorlDot == false)
            {
                controlDotMousePoint1 = new Point(mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                controlDotMousePoint2 = new Point(mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                ShowShapeControlDot(controlDotMousePoint1.X, controlDotMousePoint1.Y, controlDotMousePoint2.X, controlDotMousePoint2.Y);
            }
            else
            {
                switch (selectID)
                {
                    case "ID_1":
                        controlDotMousePoint1 = new Point(controlDotMousePoint2.X < mousePoint2.X ? controlDotMousePoint2.X : mousePoint2.X, controlDotMousePoint2.Y < mousePoint2.Y ? controlDotMousePoint2.Y : mousePoint2.Y);
                        controlDotMousePoint2 = new Point(controlDotMousePoint2.X > mousePoint2.X ? controlDotMousePoint2.X : mousePoint2.X, controlDotMousePoint2.Y > mousePoint2.Y ? controlDotMousePoint2.Y : mousePoint2.Y);
                        break;
                    case "ID_2":
                        controlDotMousePoint1 = new Point(controlDotMousePoint1.X, controlDotMousePoint2.Y < mousePoint2.Y ? controlDotMousePoint2.Y : mousePoint2.Y);
                        controlDotMousePoint2 = new Point(controlDotMousePoint2.X, controlDotMousePoint2.Y > mousePoint2.Y ? controlDotMousePoint2.Y : mousePoint2.Y);
                        break;
                    case "ID_3":
                        controlDotMousePoint1 = new Point(mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        controlDotMousePoint2 = new Point(mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        break;
                    case "ID_4":
                        controlDotMousePoint1 = new Point(controlDotMousePoint2.X < mousePoint2.X ? controlDotMousePoint2.X : mousePoint2.X, controlDotMousePoint1.Y);
                        controlDotMousePoint2 = new Point(controlDotMousePoint2.X > mousePoint2.X ? controlDotMousePoint2.X : mousePoint2.X, controlDotMousePoint2.Y);
                        break;
                    case "ID_5":
                        controlDotMousePoint2 = new Point(controlDotMousePoint1.X > mousePoint2.X ? controlDotMousePoint1.X : mousePoint2.X, controlDotMousePoint2.Y);
                        controlDotMousePoint1 = new Point(controlDotMousePoint1.X < mousePoint2.X ? controlDotMousePoint1.X : mousePoint2.X, controlDotMousePoint1.Y);
                        break;
                    case "ID_6":
                        controlDotMousePoint1 = new Point(mousePoint1.X < mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y < mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        controlDotMousePoint2 = new Point(mousePoint1.X > mousePoint2.X ? mousePoint1.X : mousePoint2.X, mousePoint1.Y > mousePoint2.Y ? mousePoint1.Y : mousePoint2.Y);
                        break;
                    case "ID_7":
                        controlDotMousePoint2 = new Point(controlDotMousePoint2.X, controlDotMousePoint1.Y > mousePoint2.Y ? controlDotMousePoint1.Y : mousePoint2.Y);
                        controlDotMousePoint1 = new Point(controlDotMousePoint1.X, controlDotMousePoint1.Y < mousePoint2.Y ? controlDotMousePoint1.Y : mousePoint2.Y);
                        break;
                    case "ID_8":
                        controlDotMousePoint2 = new Point(controlDotMousePoint1.X > mousePoint2.X ? controlDotMousePoint1.X : mousePoint2.X, controlDotMousePoint1.Y > mousePoint2.Y ? controlDotMousePoint1.Y : mousePoint2.Y);
                        controlDotMousePoint1 = new Point(controlDotMousePoint1.X < mousePoint2.X ? controlDotMousePoint1.X : mousePoint2.X, controlDotMousePoint1.Y < mousePoint2.Y ? controlDotMousePoint1.Y : mousePoint2.Y);
                        break;
                }
            }
            onClickDrawShape = false;
            onClickContorlDot = false;
            //PositionX2.Text = mousePoint2.X.ToString();
            //PositionY2.Text = mousePoint2.Y.ToString();
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
