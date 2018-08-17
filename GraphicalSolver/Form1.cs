using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace GraphicalSolver
{

    public partial class frmGraph : Form
    {
        List<string> model = new List<string>();
        string objectiveFunction;
        int yLimit;
        int xLimit;
        decimal oRhs;
        public frmGraph()
        {
            InitializeComponent();
        }

        //When the browse button is clicked and the file has been chosen the program will imdiatly try to draw the graph. this includes, constraint, labels, feasible area and objective function.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string destination;
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblXAxis.Visible = true;
                lblYAxis.Visible = true;
                oRhs = 0;
                tbObjectiveMove.Value = 0;
                Drawer.ConstraintCounter = 1;

                destination = openFileDialog.InitialDirectory + openFileDialog.FileName;
                model = FileHandler.Read(destination);
                lblFileLocation.Text = openFileDialog.FileName;
                objectiveFunction = model[0];
                tbObjectiveFunction.Text = model[0];
                tbRestrictions.Text = model[model.Count - 1];
                lblProblemType.Text = (model[0].Substring(0, 3)).ToUpper() + " PROBLEM";

                pnlGraphArea.Refresh();
                pnlGraphArea.Controls.Clear();

                yLimit = Calculator.CalcHighestY(model);
                xLimit = Calculator.CalcHighestX(model);

                Drawer.DrawCanvas(pnlGraphArea, xLimit, yLimit);

                //Draw all existing constraints.
                foreach (string line in model)
                {
                    List<string> values = FileHandler.SplitLine(line);

                    decimal xOperand = Convert.ToDecimal(values[0] + values[1]); ;
                    decimal yOperand = Convert.ToDecimal(values[2] + values[3]);
                    decimal rhs = Convert.ToDecimal(values[values.Count - 1] );
                    if (values[1] == "0")
                    {
                        
                        Point yIntercept = Calculator.CalcYIntercept(Convert.ToInt32(yOperand), Convert.ToInt32(rhs), yLimit);
                        Drawer.DrawConstraint(pnlGraphArea, Calculator.CalcXIntercept(Convert.ToInt32(xOperand), Convert.ToInt32(rhs), xLimit), yIntercept, values[values.Count - 3] + values[values.Count - 2], xOperand, yOperand, rhs);
                    }
                    else
                    {
                        Drawer.DrawConstraint(pnlGraphArea, Calculator.CalcXIntercept(Convert.ToInt32(xOperand), Convert.ToInt32(rhs), xLimit), Calculator.CalcYIntercept(Convert.ToInt32(yOperand), Convert.ToInt32(rhs), yLimit), values[values.Count - 3] + values[values.Count - 2], xOperand, yOperand, rhs);
                    }
                }

                //Draw objective function
                Drawer.DrawObjectiveFunction(pnlGraphArea,objectiveFunction, (decimal)0.0);
                tbObjectiveMove.Enabled = true;

                lbConstraints.Enabled = true;
                List<string> constraints = new List<string>();


                // Add constraint identifiers to the lisbox containing constraints.
                for (int i = 0; i < model.Count; i++)
                {
                    constraints.Add("C" + (i+1) + "   "+model[i]);
                }

                lbConstraints.DataSource = constraints;

                btnAddConstraint.Enabled = true;
                lbBindingC.Items.Clear();
                btnSolve.Enabled = false;
                btnRemoveConstraint.Enabled = false;
                pnlAnswers.Visible = false;

                //SCRAPPED CODE

                //Bitmap graph = new Bitmap(pnlGraphArea.Width, pnlGraphArea.Height);

                //Graphics gfx = Graphics.FromImage(graph);
                //graph = new Bitmap(pnlGraphArea.Width, pnlGraphArea.Height,gfx);


                //pnlGraphArea.DrawToBitmap(graph, new Rectangle(0, 0, pnlGraphArea.Width, pnlGraphArea.Height));
                
                //graph.Save("graph.bmp");
                //System.Diagnostics.Process.Start("graph.bmp");

                ////MessageBox.Show(graph.GetPixel(40, 400).ToString());
                
            }

        }
        private void frmGraph_Load(object sender, EventArgs e)
        {
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int prevValue;
        //Move the objective function as the user moves the slider as well as redrawing the entire graph. this is to prevent multiple objective function lines to be drawn.
        private void tbObjectiveMove_Scroll(object sender, EventArgs e)
        {
            pnlGraphArea.Invalidate();

            Drawer.DrawCanvas(pnlGraphArea, xLimit, yLimit);

            foreach (string line in model)
            {
                List<string> values = FileHandler.SplitLine(line);

                decimal xOperand = Convert.ToDecimal(values[0] + values[1]); ;
                decimal yOperand = Convert.ToDecimal(values[2] + values[3]);
                decimal rhs = Convert.ToDecimal(values[values.Count - 1]);
                if (values[1] == "0")
                {

                    Point yIntercept = Calculator.CalcYIntercept(Convert.ToInt32(yOperand), Convert.ToInt32(rhs), yLimit);
                    Drawer.DrawConstraint(pnlGraphArea, Calculator.CalcXIntercept(Convert.ToInt32(xOperand), Convert.ToInt32(rhs), xLimit), yIntercept, values[values.Count - 3] + values[values.Count - 2], xOperand, yOperand, rhs);
                }
                else
                {
                    Drawer.DrawConstraint(pnlGraphArea, Calculator.CalcXIntercept(Convert.ToInt32(xOperand), Convert.ToInt32(rhs), xLimit), Calculator.CalcYIntercept(Convert.ToInt32(yOperand), Convert.ToInt32(rhs), yLimit), values[values.Count - 3] + values[values.Count - 2], xOperand, yOperand, rhs);
                }
            }
            
            if (prevValue > tbObjectiveMove.Value)
            {
                oRhs = tbObjectiveMove.Value;
            }
            else
            {
                oRhs = tbObjectiveMove.Value;
            }

            prevValue = tbObjectiveMove.Value;

            Drawer.DrawObjectiveFunction(pnlGraphArea, objectiveFunction, oRhs);
        }

        //Add constraint to binding constraint list
        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            if (lbBindingC.Items.Count < 2)
            {
                if (!lbBindingC.Items.Contains(lbConstraints.SelectedItem))
                {
                    lbBindingC.Items.Add(lbConstraints.SelectedItem);
                    if (lbBindingC.Items.Count == 2)
                    {
                        btnAddConstraint.Enabled = false;
                        btnSolve.Enabled = true;
                    }
                }
                
            }
 
            lbBindingC.SelectedIndex = 0;
            btnRemoveConstraint.Enabled = true;
            lbBindingC.Enabled = true;
        }

        //Remove a constraint from the binding constraints list
        private void btnRemoveConstraint_Click(object sender, EventArgs e)
        {
            

            lbBindingC.Items.Remove(lbBindingC.SelectedItem);
            if (lbBindingC.Items.Count == 0)
            {
                btnRemoveConstraint.Enabled = false;
                btnSolve.Enabled = false;
                btnAddConstraint.Enabled = true;
            }

            if (lbBindingC.Items.Count == 1)
            {
                btnSolve.Enabled = false;
                btnAddConstraint.Enabled = true;
                lbBindingC.SelectedIndex = 0;
            }

            
        }

        private void lbBindingC_Validating(object sender, CancelEventArgs e)
        {
            if (lbBindingC.Items.Count == 2)
            {
                btnSolve.Enabled = true;
            }
        }

        //Solve simultanious equations and print out the answers for x1 and x2 as well as the Z.
        private void btnSolve_Click(object sender, EventArgs e)
        {
            string[] equations = new string[2];

            for (int i = 0; i < lbBindingC.Items.Count; i++)
            {
                equations[i] = lbBindingC.Items[i].ToString();
            }

            double[] answers = Calculator.SolveEquations(equations);
            lblX1.Text = "x1 = " + answers[0].ToString();
            lblX2.Text = "x2 = " + answers[1].ToString();

             lblZ.Text = "Z = " + Calculator.CalcZValue(answers, objectiveFunction).ToString();

            btnSolve.Enabled = false;

            pnlAnswers.Visible = true;
            lbBindingC.Items.Clear();
            btnRemoveConstraint.Enabled = false;
            btnAddConstraint.Enabled = true;
        }
    }
}
