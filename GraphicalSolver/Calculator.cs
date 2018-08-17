using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace GraphicalSolver
{
    //Class used to store all calculation methods
    static class Calculator
    {
        public static int highX;
        public static int highY;

        //Calculate the x intercept
        public static int CalcHighestX(List<string> model)
        {
            int highest = 0;
            foreach (string line in model)
            {
                List<string> values = FileHandler.SplitLine(line);

                int value = Convert.ToInt32(values[0] + values[1]);
                int finalValue = 0;
                try
                {
                    finalValue = Convert.ToInt32(values[values.Count - 1]) / value;
                }
                catch (DivideByZeroException)
                {
                    //Exclude when deviding by zero
                }
                if (finalValue > highest)
                {
                    highest = finalValue;
                }
            }

            highX = highest;
            return highest;

        }


        //Calculate highest y intercept
        public static int CalcHighestY(List<string> model)
        {
            model.RemoveAt(model.Count - 1);
            model.RemoveAt(0);

            int highest = 0;
            foreach (string line in model)
            {
                List<string> values = FileHandler.SplitLine(line);

                int value = Convert.ToInt32(values[2] + values[3]);
                int finalValue = 0;
                try
                {
                    finalValue = Convert.ToInt32(values[values.Count - 1]) / value;
                }
                catch (DivideByZeroException)
                {
                    //Exclude when deviding by zero
                }


                if (finalValue > highest)
                {
                    highest = finalValue;
                }
            }

            highY = highest;
            return highest;
        }

        private static int xIntercept;
        private static int yIntercept;

        //Calculate intercept for X constraints.
        public static Point CalcXIntercept(int operand, int rhs, decimal maxX)
        {
            decimal answer = 0;
            try
            {
                answer = rhs / operand;
            }
            catch (DivideByZeroException)
            {
                //Disregard division by 0
            }

            decimal percentage = answer / maxX;
            decimal intercept = 500 * percentage;

            if (operand == 0)
            {
                return new Point(530, yIntercept);
            }
            else
            {
                xIntercept = Convert.ToInt32(intercept) + 30;
                return new Point(xIntercept, 530);
            }
            
        }

        //Calculate intercept for Y constraints.
        public static Point CalcYIntercept(int operand, int rhs, decimal maxY)
        {
           
            decimal answer = 0;
            try
            {
                answer = rhs / operand;
            }
            catch (DivideByZeroException)
            {
                //Disregard division by 0
            }

            decimal percentage = answer / maxY;
            percentage = (decimal)1 - percentage;
            decimal intercept = 500 * percentage;

            if (operand == 0)
            {
                return new Point(xIntercept, 30);
            }
            else
            {
                yIntercept = Convert.ToInt32(intercept) + 30;
                return new Point(30, yIntercept);
            }
            
        }


        //Solve simultanious equastion for binding constraints.
        public static double[] SolveEquations(string[] equations)
        {
            List<string> values = FileHandler.SplitLine(equations[0]);
            values.RemoveAt(0);
            double xOperandOne = double.Parse(values[0] + values[1]);
            double xOperandTwo = double.Parse(values[2] + values[3]);
            string xOperator = values[2];
            double xRhs = double.Parse(values[values.Count - 1]);

            values = FileHandler.SplitLine(equations[1]);
            values.RemoveAt(0);
            double yOperandOne = double.Parse(values[0] + values[1]);
            double yOperandTwo = double.Parse(values[2] + values[3]);
            string yOperator = values[2];
            double yRhs =double.Parse(values[values.Count-1]);

            if (xOperator == "+" && yOperator == "+")
            {
                double y = (xOperandOne * yRhs - yOperandOne * xRhs )/(xOperandOne * yOperandTwo - yOperandOne * xOperandTwo);
                double x = (xRhs - (xOperandTwo * y))/ xOperandOne;

                return new double[] { x, y };
            }
            else if (xOperator == "+" && yOperator == "-")
            {
                double y = (yOperandOne * xRhs - yRhs * xOperandOne ) / (xOperandOne * yOperandTwo + yOperandOne * xOperandTwo);
                double x = (xRhs - (xOperandTwo * y)) / xOperandOne;

                return new double[] { x, y };
            }
            else if (xOperator == "-" && yOperator == "-")
            {
                double y = (xOperandOne * yRhs - yOperandOne * xRhs) / (yOperandOne * xOperandTwo - xOperandOne * yOperandTwo);
                double x = (xRhs + (xOperandTwo * y)) / xOperandOne;

                return new double[] { x, y };
            }
            else if (xOperator == "-" && yOperator == "+")
            {
                double y = (xOperandOne * yRhs - yOperandOne * xRhs) / (xOperandOne * yOperandTwo + yOperandOne * xOperandTwo);
                double x = (xRhs + (xOperandTwo * y)) / xOperandOne;

                return new double[] { x, y };
            }

            return new double[3];
        }


        //Calculate the Z value by making use of the x1 and 2 values.
        public static double CalcZValue(double[] answers, string objFunction)
        {
            List<string> values = FileHandler.SplitLine(objFunction);

            if (values[2] == "+")
            {
                return (Convert.ToDouble(values[0] + values[1]) * answers[0] ) + (Convert.ToDouble(values[2] + values[3]) * answers[1]);
            }
            else if (values[2] == "-")
            {
                return (Convert.ToDouble(values[0] + values[1]) * answers[0]) - (Convert.ToDouble(values[2] + values[3]) * answers[1]);
            }
            else
            {
                double invalid = 0;
                return invalid;
            }
            
        }



        //SCRAPPED CODE FROM FINDING FEASIBLE AREA POINTS PROGRAMABLY


        //public static Point SolveLP(List<string> model, string objective)
        //{
        //    Point optimalPoint = new Point();
        //    string problemType = objective.Substring(0, 3);
        //    List<string> objectiveValues = FileHandler.SplitLine(objective);
           

        //    foreach (string line in model)
        //    {
        //        List<string> values = FileHandler.SplitLine(line);
        //        int operandOne =Convert.ToInt32(values[0]+ values[1]);
        //        int operandTwo = Convert.ToInt32(values[2] + values[3]);
        //        string oper = values[4] + values[5];
        //        int rhs = Convert.ToInt32(values[values.Count - 1]);

                
        //    }
            
        //    return optimalPoint;
        //}



        //public static List<Point> GetFeasiblePoints(List<string> model)
        //{
        //    List<Point> points = new List<Point>();

        //    List<Intercepts> xIntercepts = new List<Intercepts>();
        //    xIntercepts.Add(new Intercepts(0, ">="));

        //    List<Intercepts> yIntercepts = new List<Intercepts>();
        //    yIntercepts.Add(new Intercepts(0, ">="));

        //    foreach (string line in model)
        //    {
        //        List<string> values = FileHandler.SplitLine(line);

        //        if (values[1] != "0")
        //        {
        //            xIntercepts.Add(new Intercepts(Convert.ToDecimal(values[values.Count - 1]) / Convert.ToDecimal(values[0] + values[1]), values[values.Count - 3] + values[values.Count - 2]));
        //        }

        //    }

        //    foreach (string line in model)
        //    {
        //        List<string> values = FileHandler.SplitLine(line);

        //        if (values[3] != "0")
        //        {
        //            yIntercepts.Add(new Intercepts(Convert.ToDecimal(values[values.Count - 1]) / Convert.ToDecimal(values[2] + values[3]), values[values.Count - 3] + values[values.Count - 2]));
        //        }

        //    }

        //    xIntercepts.Sort();
        //    yIntercepts.Sort();

        //    List<Constraint> xCheckPoints = new List<Constraint>();

        //    for (int i = 1; i < xIntercepts.Count; i++)
        //    {
        //        if (xIntercepts[i - 1].Oper == ">=" && xIntercepts[i].Oper == "<=")
        //        {
        //            xCheckPoints.Add(new Constraint(new Point(Convert.ToInt32(xIntercepts[i - 1].Value), 0), xIntercepts[i - 1].Oper));
        //            xCheckPoints.Add(new Constraint(new Point(Convert.ToInt32(xIntercepts[i].Value), 0), xIntercepts[i].Oper));
        //        }
        //    }

        //    List<Constraint> yCheckPoints = new List<Constraint>();

        //    for (int i = 1; i < yIntercepts.Count; i++)
        //    {
        //        if (yIntercepts[i - 1].Oper == ">=" && yIntercepts[i].Oper == "<=")
        //        {
        //            yCheckPoints.Add(new Constraint(new Point(0, Convert.ToInt32(yIntercepts[i - 1].Value)), xIntercepts[i - 1].Oper));
        //            yCheckPoints.Add(new Constraint(new Point(0, Convert.ToInt32(yIntercepts[i].Value)), xIntercepts[i].Oper));
        //        }
        //    }

        //    if (yCheckPoints.Contains(new Constraint(new Point(0, 0), ">=")) && xCheckPoints.Contains(new Constraint(new Point(0, 0), ">=")))
        //    {
        //        //points.AddRange(xCheckPoints);
        //        //points.AddRange(yCheckPoints);
        //    }
        //    else if (!xCheckPoints.Contains(new Constraint(new Point(0,0),">=")) && yCheckPoints.Contains(new Constraint(new Point(0, 0), ">=")))
        //    {
        //        foreach (Constraint con in yCheckPoints)
        //        {
        //            points.Add(con.Point);
        //        }
        //    }
        //    else if (!yCheckPoints.Contains(new Constraint(new Point(0, 0), ">=")) && xCheckPoints.Contains(new Constraint(new Point(0, 0), ">=")))
        //    {
        //        foreach (Constraint con in xCheckPoints)
        //        {
        //            points.Add(con.Point);
        //        }
        //    }
        //    else
        //    {
        //        foreach (Constraint con in xCheckPoints)
        //        {
        //            points.Add(con.Point);
        //        }
        //        foreach (Constraint con in yCheckPoints)
        //        {
        //            points.Add(con.Point);
        //        }

        //    }
            

        //    for (int i = 0; i < points.Count; i++)
        //    {
        //        if (points[i].Y == 0 && points[i].X == 0)
        //        {
        //            points[i] = new Point(30, 530);
        //        }
        //        else if (points[i].Y == 0)
        //        {
        //            points[i] = new Point((Convert.ToInt32(((decimal)points[i].X / (decimal)highX) * (decimal)500)) + 30 , 530);
        //        }
        //        else if (points[i].X == 0)
        //        {
        //            points[i] = new Point(30, 530 - ((Convert.ToInt32(((decimal)points[i].Y / (decimal)highY) * (decimal)500))));
        //        }

        //    }

        //    points = points.Distinct().ToList();
        //    points = points.OrderBy(o => o.X + o.Y).ToList();
        //    return points;

        //}
    }
}
