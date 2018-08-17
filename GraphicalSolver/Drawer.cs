using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GraphicalSolver
{
    //Class used to draw on the canvas/panel
    static class Drawer
    {
        private static int maxX;
        private static int maxY;
        public static int ConstraintCounter = 1;


        //Draw the cartisian plane
        static public void DrawCanvas(Panel pnl, int highestX, int highestY)
        {
            maxX = highestX;
            maxY = highestY;
            DrawLabel(pnl, "0", new Point(15, 530), 10);

            Point x = new Point(30, 30);
            Point y = new Point(30, 530);

            pnl.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2),x , y);
            x.X = x.X - 26;
            x.Y = x.Y - 7;
            DrawLabel(pnl, highestY.ToString(), x, 25);

            x = new Point(30, 530);
            y = new Point(530, 530);

            pnl.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), x, y);
            y.X = y.X - 10;
            y.Y = y.Y + 2;
            DrawLabel(pnl, highestX.ToString(), y, 25);


            
        }

        //Create a label using specified parameters.
        static private void DrawLabel(Panel pnl, string text, Point location, int width)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = location;
            lbl.Width = width;
            lbl.Height = 12;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            pnl.Controls.Add(lbl);
        }

        //Draw the area of feasibily for a singular constraint.
        public static void DrawFeasibleArea(Panel pnl, Point x, Point y, string oper)
        {
            Color feasibleColor = Color.FromArgb(40, Color.Blue);
            Color feasibleColorB = Color.FromArgb(40, Color.Black);
            List<Point> points = new List<Point>();

            if (oper == "<=")
            {
                if (y.X == x.X && y.Y == 30)
                {
                    points.AddRange(new Point[] { x, y, new Point(30, 30), new Point(30, 530) } );
                }
                else if (y.Y == x.Y && y.X == 30)
                {
                    points.AddRange(new Point[] { x, y, new Point(30, 530), new Point(530, 530) });
                }
                else
                {
                    points.AddRange(new Point[]{ x, y, new Point(30, 530) });
                }
                
                pnl.CreateGraphics().FillPolygon(new SolidBrush(feasibleColor), points.ToArray());
            }
            else if (oper == ">=")
            {
                points.AddRange(new Point[] { x, y, new Point(30 , 30), new Point(530, 30), new Point(530, 530) });
                pnl.CreateGraphics().FillPolygon(new SolidBrush(feasibleColorB), points.ToArray());
            }
            else
            {
                // do noting if operator is =
            }
        }

         //Draw the objective function as close to 0,0 as possible and then takes input from slider to move it along the x and y axis.
         public static void DrawObjectiveFunction(Panel pnl, string objectivefuntion, decimal rhs)
        {
            List<string> function = FileHandler.SplitLine(objectivefuntion);

            if (Convert.ToInt32(function[0] + function[1]) >= 10 || Convert.ToInt32(function[2] + function[3]) >= 10)
            {
                function[1] = (Convert.ToDecimal(function[1]) / (decimal)100).ToString();
                function[3] = (Convert.ToDecimal(function[3]) / (decimal)100).ToString();
            }
            else if (Convert.ToInt32(function[0] + function[1]) >= 100 || Convert.ToInt32(function[2] + function[3]) >= 100)
            {
                function[1] = (Convert.ToDecimal(function[1]) / (decimal)1000).ToString();
                function[3] = (Convert.ToDecimal(function[3]) / (decimal)1000).ToString();
            }

            Point x = new Point(Convert.ToInt32(((Convert.ToDecimal(function[2] + function [3]) / (maxX)) * (500 + rhs)) + 30), 530);
            Point y = new Point(30, 530 - (Convert.ToInt32(((Convert.ToDecimal(function[0] + function[1]) / (maxY)) * (500 + rhs)))));


            pnl.CreateGraphics().DrawLine(new Pen(Color.Black, 2) {DashPattern = new float[] {5, 1.5f } }, x,y);
        }


        //Draw the constraints. This includes the direction in which it is going, feasible area & intercept labels
        static public void DrawConstraint(Panel pnl, Point x, Point y, string oper, decimal xOperand, decimal yOperand, decimal rhs)
        {
            int xDifference = 18;
            int yDifference = 1;

            if (xOperand != 0)
            {
                decimal text = rhs / xOperand;

                x.X = x.X - xDifference;
                x.Y = x.Y + yDifference;

                DrawLabel(pnl, Math.Floor(text).ToString(), x, 30);

                x.X = x.X + xDifference;
                x.Y = x.Y - yDifference;
            }

            pnl.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), x, y);
            DrawFeasibleArea(pnl, x, y, oper);

            if (yOperand != 0)
            {
                xDifference = 31;
                yDifference = 6;

                decimal text = rhs / yOperand;

                y.X = y.X - xDifference;
                y.Y = y.Y - yDifference;

                DrawLabel(pnl, Math.Floor(text).ToString(), y, 30);

                y.X = y.X + xDifference;
                y.Y = y.Y + yDifference;
            }
            

            Point middle = new Point((x.X + y.X) / 2, (x.Y + y.Y) / 2);
            Point middleUp = new Point(middle.X,middle.Y - 10);
            Point middleDown = new Point(middle.X, middle.Y + 10);
            Point middleLeft = new Point(middle.X - 10, middle.Y);
            Point middleRight = new Point(middle.X + 10, middle.Y);



            Point topMiddle = new Point((middle.X + y.X) / 2, (middle.Y + y.Y) / 2);
            topMiddle.X = topMiddle.X -10;
            topMiddle.Y = topMiddle.Y - 10;

            DrawLabel(pnl, "C" + ConstraintCounter, topMiddle, 20);
            ConstraintCounter++;

            if (oper == "<=")
            {
                pnl.CreateGraphics().DrawLine(new Pen(Brushes.Crimson, 4), middle, middleDown);
                pnl.CreateGraphics().DrawLine(new Pen(Brushes.Crimson, 4), middle, middleLeft);
            }
            else if (oper == ">=")
            {
                pnl.CreateGraphics().DrawLine(new Pen(Brushes.Crimson, 4), middle, middleUp);
                pnl.CreateGraphics().DrawLine(new Pen(Brushes.Crimson, 4), middle, middleRight);
            }

                     
        }
    }
}
