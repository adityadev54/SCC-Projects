namespace _3Sports.UI
{
    partial class RacingMoreData
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label raceIDLabel;
            System.Windows.Forms.Label driverIDLabel;
            System.Windows.Forms.Label constructorLabel;
            System.Windows.Forms.Label numberLabel;
            System.Windows.Forms.Label gridLabel;
            System.Windows.Forms.Label pointsLabel;
            System.Windows.Forms.Label lapsLabel;
            System.Windows.Forms.Label winnerLabel;
            System.Windows.Forms.Label grandPrixLabel;
            System.Windows.Forms.Label raceRoundLabel;
            this.btnBack = new System.Windows.Forms.Button();
            this.f1DB = new _3Sports.F1DB();
            this.currentConstructorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currentConstructorsTableAdapter = new _3Sports.F1DBTableAdapters.CurrentConstructorsTableAdapter();
            this.tableAdapterManager = new _3Sports.F1DBTableAdapters.TableAdapterManager();
            this.circuitsTableAdapter = new _3Sports.F1DBTableAdapters.CircuitsTableAdapter();
            this.constructorsTableAdapter = new _3Sports.F1DBTableAdapters.ConstructorsTableAdapter();
            this.circuitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.constructorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resultsTableAdapter = new _3Sports.F1DBTableAdapters.ResultsTableAdapter();
            this.constructorsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.circuitsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.resultsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cboxYear = new System.Windows.Forms.ComboBox();
            this.raceIDTextBox = new System.Windows.Forms.TextBox();
            this.driverIDTextBox = new System.Windows.Forms.TextBox();
            this.constructorTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.gridTextBox = new System.Windows.Forms.TextBox();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.lapsTextBox = new System.Windows.Forms.TextBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.resultsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.winnerTextBox = new System.Windows.Forms.TextBox();
            this.raceNameTextBox = new System.Windows.Forms.TextBox();
            this.raceRoundTextBox = new System.Windows.Forms.TextBox();
            raceIDLabel = new System.Windows.Forms.Label();
            driverIDLabel = new System.Windows.Forms.Label();
            constructorLabel = new System.Windows.Forms.Label();
            numberLabel = new System.Windows.Forms.Label();
            gridLabel = new System.Windows.Forms.Label();
            pointsLabel = new System.Windows.Forms.Label();
            lapsLabel = new System.Windows.Forms.Label();
            winnerLabel = new System.Windows.Forms.Label();
            grandPrixLabel = new System.Windows.Forms.Label();
            raceRoundLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circuitsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constructorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constructorsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circuitsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // raceIDLabel
            // 
            raceIDLabel.AutoSize = true;
            raceIDLabel.ForeColor = System.Drawing.Color.Transparent;
            raceIDLabel.Location = new System.Drawing.Point(405, 249);
            raceIDLabel.Name = "raceIDLabel";
            raceIDLabel.Size = new System.Drawing.Size(67, 16);
            raceIDLabel.TabIndex = 34;
            raceIDLabel.Text = "Race ID:";
            // 
            // driverIDLabel
            // 
            driverIDLabel.AutoSize = true;
            driverIDLabel.ForeColor = System.Drawing.Color.Transparent;
            driverIDLabel.Location = new System.Drawing.Point(405, 334);
            driverIDLabel.Name = "driverIDLabel";
            driverIDLabel.Size = new System.Drawing.Size(72, 16);
            driverIDLabel.TabIndex = 36;
            driverIDLabel.Text = "Driver ID:";
            // 
            // constructorLabel
            // 
            constructorLabel.ForeColor = System.Drawing.Color.Transparent;
            constructorLabel.Location = new System.Drawing.Point(405, 362);
            constructorLabel.Name = "constructorLabel";
            constructorLabel.Size = new System.Drawing.Size(101, 28);
            constructorLabel.TabIndex = 38;
            constructorLabel.Text = "Constructor:";
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.ForeColor = System.Drawing.Color.Transparent;
            numberLabel.Location = new System.Drawing.Point(405, 306);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(65, 16);
            numberLabel.TabIndex = 40;
            numberLabel.Text = "Number:";
            // 
            // gridLabel
            // 
            gridLabel.ForeColor = System.Drawing.Color.Transparent;
            gridLabel.Location = new System.Drawing.Point(406, 390);
            gridLabel.Name = "gridLabel";
            gridLabel.Size = new System.Drawing.Size(54, 19);
            gridLabel.TabIndex = 42;
            gridLabel.Text = "Grid:";
            // 
            // pointsLabel
            // 
            pointsLabel.AutoSize = true;
            pointsLabel.ForeColor = System.Drawing.Color.Transparent;
            pointsLabel.Location = new System.Drawing.Point(405, 418);
            pointsLabel.Name = "pointsLabel";
            pointsLabel.Size = new System.Drawing.Size(54, 16);
            pointsLabel.TabIndex = 50;
            pointsLabel.Text = "Points:";
            // 
            // lapsLabel
            // 
            lapsLabel.AutoSize = true;
            lapsLabel.ForeColor = System.Drawing.Color.Transparent;
            lapsLabel.Location = new System.Drawing.Point(405, 446);
            lapsLabel.Name = "lapsLabel";
            lapsLabel.Size = new System.Drawing.Size(45, 16);
            lapsLabel.TabIndex = 52;
            lapsLabel.Text = "Laps:";
            // 
            // winnerLabel
            // 
            winnerLabel.ForeColor = System.Drawing.Color.Transparent;
            winnerLabel.Location = new System.Drawing.Point(406, 278);
            winnerLabel.Name = "winnerLabel";
            winnerLabel.Size = new System.Drawing.Size(67, 21);
            winnerLabel.TabIndex = 60;
            winnerLabel.Text = "Winner:";
            // 
            // grandPrixLabel
            // 
            grandPrixLabel.ForeColor = System.Drawing.Color.Transparent;
            grandPrixLabel.Location = new System.Drawing.Point(405, 193);
            grandPrixLabel.Name = "grandPrixLabel";
            grandPrixLabel.Size = new System.Drawing.Size(101, 19);
            grandPrixLabel.TabIndex = 61;
            grandPrixLabel.Text = "Grand Prix:";
            // 
            // raceRoundLabel
            // 
            raceRoundLabel.ForeColor = System.Drawing.Color.Transparent;
            raceRoundLabel.Location = new System.Drawing.Point(405, 222);
            raceRoundLabel.Name = "raceRoundLabel";
            raceRoundLabel.Size = new System.Drawing.Size(83, 26);
            raceRoundLabel.TabIndex = 63;
            raceRoundLabel.Text = "Round:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(29, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 36);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // f1DB
            // 
            this.f1DB.DataSetName = "F1DB";
            this.f1DB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // currentConstructorsBindingSource
            // 
            this.currentConstructorsBindingSource.DataMember = "CurrentConstructors";
            this.currentConstructorsBindingSource.DataSource = this.f1DB;
            // 
            // currentConstructorsTableAdapter
            // 
            this.currentConstructorsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CircuitsTableAdapter = this.circuitsTableAdapter;
            this.tableAdapterManager.ConstructorsTableAdapter = this.constructorsTableAdapter;
            this.tableAdapterManager.CurrentConstructorsTableAdapter = this.currentConstructorsTableAdapter;
            this.tableAdapterManager.DriversTableAdapter = null;
            this.tableAdapterManager.ResultsTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = _3Sports.F1DBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // circuitsTableAdapter
            // 
            this.circuitsTableAdapter.ClearBeforeFill = true;
            // 
            // constructorsTableAdapter
            // 
            this.constructorsTableAdapter.ClearBeforeFill = true;
            // 
            // circuitsBindingSource
            // 
            this.circuitsBindingSource.DataMember = "Circuits";
            this.circuitsBindingSource.DataSource = this.f1DB;
            // 
            // constructorsBindingSource
            // 
            this.constructorsBindingSource.DataMember = "Constructors";
            this.constructorsBindingSource.DataSource = this.f1DB;
            // 
            // resultsBindingSource
            // 
            this.resultsBindingSource.DataMember = "Results";
            this.resultsBindingSource.DataSource = this.f1DB;
            // 
            // resultsTableAdapter
            // 
            this.resultsTableAdapter.ClearBeforeFill = true;
            // 
            // constructorsBindingSource1
            // 
            this.constructorsBindingSource1.DataMember = "Constructors";
            this.constructorsBindingSource1.DataSource = this.f1DB;
            // 
            // circuitsBindingSource1
            // 
            this.circuitsBindingSource1.DataMember = "Circuits";
            this.circuitsBindingSource1.DataSource = this.f1DB;
            // 
            // resultsBindingSource1
            // 
            this.resultsBindingSource1.DataMember = "Results";
            this.resultsBindingSource1.DataSource = this.f1DB;
            // 
            // cboxYear
            // 
            this.cboxYear.DataSource = this.resultsBindingSource1;
            this.cboxYear.DisplayMember = "PositionText";
            this.cboxYear.FormattingEnabled = true;
            this.cboxYear.Location = new System.Drawing.Point(144, 178);
            this.cboxYear.Name = "cboxYear";
            this.cboxYear.Size = new System.Drawing.Size(138, 24);
            this.cboxYear.TabIndex = 32;
            this.cboxYear.ValueMember = "ResultID";
            // 
            // raceIDTextBox
            // 
            this.raceIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "RaceID", true));
            this.raceIDTextBox.Location = new System.Drawing.Point(521, 246);
            this.raceIDTextBox.Name = "raceIDTextBox";
            this.raceIDTextBox.Size = new System.Drawing.Size(134, 22);
            this.raceIDTextBox.TabIndex = 35;
            // 
            // driverIDTextBox
            // 
            this.driverIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "DriverID", true));
            this.driverIDTextBox.Location = new System.Drawing.Point(521, 331);
            this.driverIDTextBox.Name = "driverIDTextBox";
            this.driverIDTextBox.Size = new System.Drawing.Size(134, 22);
            this.driverIDTextBox.TabIndex = 37;
            // 
            // constructorTextBox
            // 
            this.constructorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "ConstructorID", true));
            this.constructorTextBox.Location = new System.Drawing.Point(521, 359);
            this.constructorTextBox.Name = "constructorTextBox";
            this.constructorTextBox.Size = new System.Drawing.Size(134, 22);
            this.constructorTextBox.TabIndex = 39;
            // 
            // numberTextBox
            // 
            this.numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "Number", true));
            this.numberTextBox.Location = new System.Drawing.Point(521, 303);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(134, 22);
            this.numberTextBox.TabIndex = 41;
            // 
            // gridTextBox
            // 
            this.gridTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "Grid", true));
            this.gridTextBox.Location = new System.Drawing.Point(521, 387);
            this.gridTextBox.Name = "gridTextBox";
            this.gridTextBox.Size = new System.Drawing.Size(134, 22);
            this.gridTextBox.TabIndex = 43;
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "Points", true));
            this.pointsTextBox.Location = new System.Drawing.Point(521, 415);
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.Size = new System.Drawing.Size(134, 22);
            this.pointsTextBox.TabIndex = 51;
            // 
            // lapsTextBox
            // 
            this.lapsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "Laps", true));
            this.lapsTextBox.Location = new System.Drawing.Point(521, 443);
            this.lapsTextBox.Name = "lapsTextBox";
            this.lapsTextBox.Size = new System.Drawing.Size(134, 22);
            this.lapsTextBox.TabIndex = 53;
            // 
            // lblInstructions
            // 
            this.lblInstructions.ForeColor = System.Drawing.Color.Transparent;
            this.lblInstructions.Location = new System.Drawing.Point(109, 92);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(599, 21);
            this.lblInstructions.TabIndex = 56;
            this.lblInstructions.Text = "Instruction: First select a season and then a round to see more details about the" +
    " race.";
            // 
            // resultsBindingSource2
            // 
            this.resultsBindingSource2.DataMember = "Results";
            this.resultsBindingSource2.DataSource = this.f1DB;
            // 
            // resultsListBox
            // 
            this.resultsListBox.DataSource = this.resultsBindingSource2;
            this.resultsListBox.DisplayMember = "PositionText";
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(122, 288);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(188, 212);
            this.resultsListBox.TabIndex = 56;
            this.resultsListBox.ValueMember = "ResultID";
            // 
            // lblSeasons
            // 
            this.lblSeasons.ForeColor = System.Drawing.Color.Transparent;
            this.lblSeasons.Location = new System.Drawing.Point(179, 153);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(70, 22);
            this.lblSeasons.TabIndex = 57;
            this.lblSeasons.Text = "Seasons";
            // 
            // lblRound
            // 
            this.lblRound.ForeColor = System.Drawing.Color.Transparent;
            this.lblRound.Location = new System.Drawing.Point(174, 263);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(79, 22);
            this.lblRound.TabIndex = 58;
            this.lblRound.Text = "Grand Prix";
            // 
            // winnerTextBox
            // 
            this.winnerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "StatusID", true));
            this.winnerTextBox.Location = new System.Drawing.Point(521, 275);
            this.winnerTextBox.Name = "winnerTextBox";
            this.winnerTextBox.Size = new System.Drawing.Size(134, 22);
            this.winnerTextBox.TabIndex = 59;
            // 
            // raceNameTextBox
            // 
            this.raceNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "RaceID", true));
            this.raceNameTextBox.Location = new System.Drawing.Point(521, 190);
            this.raceNameTextBox.Name = "raceNameTextBox";
            this.raceNameTextBox.Size = new System.Drawing.Size(134, 22);
            this.raceNameTextBox.TabIndex = 62;
            // 
            // raceRoundTextBox
            // 
            this.raceRoundTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "DriverID", true));
            this.raceRoundTextBox.Location = new System.Drawing.Point(521, 218);
            this.raceRoundTextBox.Name = "raceRoundTextBox";
            this.raceRoundTextBox.Size = new System.Drawing.Size(134, 22);
            this.raceRoundTextBox.TabIndex = 64;
            // 
            // RacingMoreData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(808, 590);
            this.Controls.Add(grandPrixLabel);
            this.Controls.Add(this.raceNameTextBox);
            this.Controls.Add(raceRoundLabel);
            this.Controls.Add(this.raceRoundTextBox);
            this.Controls.Add(winnerLabel);
            this.Controls.Add(this.winnerTextBox);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblSeasons);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(raceIDLabel);
            this.Controls.Add(this.raceIDTextBox);
            this.Controls.Add(driverIDLabel);
            this.Controls.Add(this.driverIDTextBox);
            this.Controls.Add(constructorLabel);
            this.Controls.Add(this.constructorTextBox);
            this.Controls.Add(numberLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(gridLabel);
            this.Controls.Add(this.gridTextBox);
            this.Controls.Add(pointsLabel);
            this.Controls.Add(this.pointsTextBox);
            this.Controls.Add(lapsLabel);
            this.Controls.Add(this.lapsTextBox);
            this.Controls.Add(this.cboxYear);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RacingMoreData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Racing More Data";
            this.Load += new System.EventHandler(this.RacingMoreData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circuitsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constructorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constructorsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circuitsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private F1DB f1DB;
        private System.Windows.Forms.BindingSource currentConstructorsBindingSource;
        private F1DBTableAdapters.CurrentConstructorsTableAdapter currentConstructorsTableAdapter;
        private F1DBTableAdapters.TableAdapterManager tableAdapterManager;
        private F1DBTableAdapters.CircuitsTableAdapter circuitsTableAdapter;
        private System.Windows.Forms.BindingSource circuitsBindingSource;
        private F1DBTableAdapters.ConstructorsTableAdapter constructorsTableAdapter;
        private System.Windows.Forms.BindingSource constructorsBindingSource;
        private System.Windows.Forms.BindingSource resultsBindingSource;
        private F1DBTableAdapters.ResultsTableAdapter resultsTableAdapter;
        private System.Windows.Forms.BindingSource constructorsBindingSource1;
        private System.Windows.Forms.BindingSource circuitsBindingSource1;
        private System.Windows.Forms.BindingSource resultsBindingSource1;
        private System.Windows.Forms.ComboBox cboxYear;
        private System.Windows.Forms.TextBox raceIDTextBox;
        private System.Windows.Forms.TextBox driverIDTextBox;
        private System.Windows.Forms.TextBox constructorTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox gridTextBox;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.TextBox lapsTextBox;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.BindingSource resultsBindingSource2;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.TextBox winnerTextBox;
        private System.Windows.Forms.TextBox raceNameTextBox;
        private System.Windows.Forms.TextBox raceRoundTextBox;
    }
}