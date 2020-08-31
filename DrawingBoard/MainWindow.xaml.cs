﻿using System;
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
        Point mousePoint1, mousePoint2;
        public MainWindow()
        {
            InitializeComponent();
            Rectangle background = new Rectangle();
            background.Width = 800;
            background.Height = 450;
            background.Fill = Brushes.White;
            MainCanvas.Children.Add(background);
        }
        public Rectangle DrawRectangle(int x1, int y1, int x2, int y2)
        {
            Rectangle drawRectangle = new Rectangle();
            drawRectangle.Width = x2 - x1;
            drawRectangle.Height = y2 - y1;
            drawRectangle.Fill = Brushes.Black;
            Canvas.SetLeft(drawRectangle, x1);
            Canvas.SetTop(drawRectangle, y1);
            return drawRectangle;
        }
        public Line DrawLine(double x1, double y1, double x2, double y2)
        {
            Line drawLine = new Line();
            drawLine.X1 = x1;
            drawLine.Y1 = y1;
            drawLine.X2 = x2;
            drawLine.Y2 = y2;
            drawLine.Stroke = Brushes.Red;
            drawLine.StrokeThickness = 2;
            return drawLine;
        }
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePoint1 = GetMousePosition();
            PositionX1.Text = mousePoint1.X.ToString();
            PositionY1.Text = mousePoint1.Y.ToString();
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mousePoint2 = GetMousePosition();
            PositionX2.Text = mousePoint2.X.ToString();
            PositionY2.Text = mousePoint2.Y.ToString();
            MainCanvas.Children.Add(DrawLine(mousePoint1.X, mousePoint1.Y, mousePoint2.X, mousePoint2.Y));
        }
        public Point GetMousePosition()
        {
            return Mouse.GetPosition(MainCanvas);
        }
    }
}
