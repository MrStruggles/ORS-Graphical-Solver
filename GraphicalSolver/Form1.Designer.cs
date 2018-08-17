namespace GraphicalSolver
{
    partial class frmGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlGraphArea = new System.Windows.Forms.Panel();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbObjectiveMove = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbObjectiveFunction = new System.Windows.Forms.TextBox();
            this.tbRestrictions = new System.Windows.Forms.TextBox();
            this.lbConstraints = new System.Windows.Forms.ListBox();
            this.lblProblemType = new System.Windows.Forms.Label();
            this.lbBindingC = new System.Windows.Forms.ListBox();
            this.btnAddConstraint = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnRemoveConstraint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAnswers = new System.Windows.Forms.Panel();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblYAxis = new System.Windows.Forms.Label();
            this.lblXAxis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectiveMove)).BeginInit();
            this.pnlAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(26, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(133, 38);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pnlGraphArea
            // 
            this.pnlGraphArea.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlGraphArea.Location = new System.Drawing.Point(529, 50);
            this.pnlGraphArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGraphArea.Name = "pnlGraphArea";
            this.pnlGraphArea.Size = new System.Drawing.Size(763, 686);
            this.pnlGraphArea.TabIndex = 2;
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoEllipsis = true;
            this.lblFileLocation.Location = new System.Drawing.Point(165, 50);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(200, 17);
            this.lblFileLocation.TabIndex = 3;
            this.lblFileLocation.Text = "File/Locations";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tbObjectiveMove
            // 
            this.tbObjectiveMove.Enabled = false;
            this.tbObjectiveMove.Location = new System.Drawing.Point(12, 677);
            this.tbObjectiveMove.Maximum = 50000;
            this.tbObjectiveMove.Name = "tbObjectiveMove";
            this.tbObjectiveMove.Size = new System.Drawing.Size(353, 56);
            this.tbObjectiveMove.TabIndex = 4;
            this.tbObjectiveMove.TickFrequency = 1000;
            this.tbObjectiveMove.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbObjectiveMove.Scroll += new System.EventHandler(this.tbObjectiveMove_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Move Objective Function";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Linear Programming Model";
            // 
            // tbObjectiveFunction
            // 
            this.tbObjectiveFunction.Enabled = false;
            this.tbObjectiveFunction.Location = new System.Drawing.Point(26, 113);
            this.tbObjectiveFunction.Name = "tbObjectiveFunction";
            this.tbObjectiveFunction.Size = new System.Drawing.Size(339, 22);
            this.tbObjectiveFunction.TabIndex = 7;
            // 
            // tbRestrictions
            // 
            this.tbRestrictions.Enabled = false;
            this.tbRestrictions.Location = new System.Drawing.Point(26, 422);
            this.tbRestrictions.Name = "tbRestrictions";
            this.tbRestrictions.Size = new System.Drawing.Size(339, 22);
            this.tbRestrictions.TabIndex = 8;
            // 
            // lbConstraints
            // 
            this.lbConstraints.Enabled = false;
            this.lbConstraints.FormattingEnabled = true;
            this.lbConstraints.ItemHeight = 16;
            this.lbConstraints.Location = new System.Drawing.Point(26, 141);
            this.lbConstraints.Name = "lbConstraints";
            this.lbConstraints.Size = new System.Drawing.Size(232, 276);
            this.lbConstraints.TabIndex = 9;
            // 
            // lblProblemType
            // 
            this.lblProblemType.AutoSize = true;
            this.lblProblemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblemType.Location = new System.Drawing.Point(806, 9);
            this.lblProblemType.Name = "lblProblemType";
            this.lblProblemType.Size = new System.Drawing.Size(0, 29);
            this.lblProblemType.TabIndex = 10;
            // 
            // lbBindingC
            // 
            this.lbBindingC.Enabled = false;
            this.lbBindingC.FormattingEnabled = true;
            this.lbBindingC.ItemHeight = 16;
            this.lbBindingC.Location = new System.Drawing.Point(26, 513);
            this.lbBindingC.Name = "lbBindingC";
            this.lbBindingC.Size = new System.Drawing.Size(232, 84);
            this.lbBindingC.TabIndex = 11;
            this.lbBindingC.Validating += new System.ComponentModel.CancelEventHandler(this.lbBindingC_Validating);
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.Enabled = false;
            this.btnAddConstraint.Location = new System.Drawing.Point(264, 359);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(101, 57);
            this.btnAddConstraint.TabIndex = 12;
            this.btnAddConstraint.Text = "Add Binding Constraint";
            this.btnAddConstraint.UseVisualStyleBackColor = true;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Enabled = false;
            this.btnSolve.Location = new System.Drawing.Point(26, 603);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(339, 51);
            this.btnSolve.TabIndex = 13;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnRemoveConstraint
            // 
            this.btnRemoveConstraint.Enabled = false;
            this.btnRemoveConstraint.Location = new System.Drawing.Point(264, 513);
            this.btnRemoveConstraint.Name = "btnRemoveConstraint";
            this.btnRemoveConstraint.Size = new System.Drawing.Size(101, 84);
            this.btnRemoveConstraint.TabIndex = 14;
            this.btnRemoveConstraint.Text = "Remove Binding Constraint";
            this.btnRemoveConstraint.UseVisualStyleBackColor = true;
            this.btnRemoveConstraint.Click += new System.EventHandler(this.btnRemoveConstraint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Binding Constraints";
            // 
            // pnlAnswers
            // 
            this.pnlAnswers.Controls.Add(this.lblZ);
            this.pnlAnswers.Controls.Add(this.lblX2);
            this.pnlAnswers.Controls.Add(this.lblX1);
            this.pnlAnswers.Location = new System.Drawing.Point(280, 141);
            this.pnlAnswers.Name = "pnlAnswers";
            this.pnlAnswers.Size = new System.Drawing.Size(224, 212);
            this.pnlAnswers.TabIndex = 16;
            this.pnlAnswers.Visible = false;
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX1.Location = new System.Drawing.Point(81, 0);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(54, 25);
            this.lblX1.TabIndex = 17;
            this.lblX1.Text = "x1 =";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX2.Location = new System.Drawing.Point(81, 25);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(60, 25);
            this.lblX2.TabIndex = 18;
            this.lblX2.Text = "x2 = ";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.Location = new System.Drawing.Point(81, 77);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(50, 25);
            this.lblZ.TabIndex = 19;
            this.lblZ.Text = "Z = ";
            // 
            // lblYAxis
            // 
            this.lblYAxis.AutoSize = true;
            this.lblYAxis.Location = new System.Drawing.Point(504, 379);
            this.lblYAxis.Name = "lblYAxis";
            this.lblYAxis.Size = new System.Drawing.Size(22, 17);
            this.lblYAxis.TabIndex = 17;
            this.lblYAxis.Text = "x2";
            this.lblYAxis.Visible = false;
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(929, 737);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(22, 17);
            this.lblXAxis.TabIndex = 18;
            this.lblXAxis.Text = "x1";
            this.lblXAxis.Visible = false;
            // 
            // frmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 769);
            this.Controls.Add(this.lblXAxis);
            this.Controls.Add(this.lblYAxis);
            this.Controls.Add(this.pnlAnswers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveConstraint);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnAddConstraint);
            this.Controls.Add(this.lbBindingC);
            this.Controls.Add(this.lblProblemType);
            this.Controls.Add(this.lbConstraints);
            this.Controls.Add(this.tbRestrictions);
            this.Controls.Add(this.tbObjectiveFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbObjectiveMove);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.pnlGraphArea);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphical Solver";
            this.Load += new System.EventHandler(this.frmGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectiveMove)).EndInit();
            this.pnlAnswers.ResumeLayout(false);
            this.pnlAnswers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlGraphArea;
        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TrackBar tbObjectiveMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbObjectiveFunction;
        private System.Windows.Forms.TextBox tbRestrictions;
        private System.Windows.Forms.ListBox lbConstraints;
        private System.Windows.Forms.Label lblProblemType;
        private System.Windows.Forms.ListBox lbBindingC;
        private System.Windows.Forms.Button btnAddConstraint;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnRemoveConstraint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlAnswers;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblYAxis;
        private System.Windows.Forms.Label lblXAxis;
    }
}

