namespace Population
{
    partial class MainForm
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
            this.popDataGridView = new System.Windows.Forms.DataGridView();
            this.cityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityDBDataSet = new Population.CityDBDataSet();
            this.cityTableAdapter = new Population.CityDBDataSetTableAdapters.CityTableAdapter();
            this.cmbSortBox = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Label();
            this.btnTotPop = new System.Windows.Forms.Button();
            this.btnAvgPop = new System.Windows.Forms.Button();
            this.btnHighPop = new System.Windows.Forms.Button();
            this.btnLowPop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popDataGridView
            // 
            this.popDataGridView.AutoGenerateColumns = false;
            this.popDataGridView.BackgroundColor = System.Drawing.Color.Gray;
            this.popDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.popDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cityIDDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.populationDataGridViewTextBoxColumn});
            this.popDataGridView.DataSource = this.cityBindingSource;
            this.popDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.popDataGridView.Location = new System.Drawing.Point(223, 49);
            this.popDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.popDataGridView.Name = "popDataGridView";
            this.popDataGridView.RowHeadersWidth = 51;
            this.popDataGridView.RowTemplate.Height = 24;
            this.popDataGridView.Size = new System.Drawing.Size(512, 364);
            this.popDataGridView.TabIndex = 0;
            // 
            // cityIDDataGridViewTextBoxColumn
            // 
            this.cityIDDataGridViewTextBoxColumn.DataPropertyName = "CityID";
            this.cityIDDataGridViewTextBoxColumn.HeaderText = "CityID";
            this.cityIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cityIDDataGridViewTextBoxColumn.Name = "cityIDDataGridViewTextBoxColumn";
            this.cityIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.Width = 125;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.Width = 125;
            // 
            // populationDataGridViewTextBoxColumn
            // 
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            this.populationDataGridViewTextBoxColumn.HeaderText = "Population";
            this.populationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            this.populationDataGridViewTextBoxColumn.Width = 125;
            // 
            // cityBindingSource
            // 
            this.cityBindingSource.DataMember = "City";
            this.cityBindingSource.DataSource = this.cityDBDataSet;
            // 
            // cityDBDataSet
            // 
            this.cityDBDataSet.DataSetName = "CityDBDataSet";
            this.cityDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
            // 
            // cmbSortBox
            // 
            this.cmbSortBox.BackColor = System.Drawing.Color.DimGray;
            this.cmbSortBox.FormattingEnabled = true;
            this.cmbSortBox.Location = new System.Drawing.Point(11, 66);
            this.cmbSortBox.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSortBox.Name = "cmbSortBox";
            this.cmbSortBox.Size = new System.Drawing.Size(138, 21);
            this.cmbSortBox.TabIndex = 1;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(153, 66);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(55, 21);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdd.Location = new System.Drawing.Point(134, 365);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add City";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.Location = new System.Drawing.Point(694, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(31, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "🗂️";
            // 
            // btnTotPop
            // 
            this.btnTotPop.Location = new System.Drawing.Point(113, 195);
            this.btnTotPop.Margin = new System.Windows.Forms.Padding(2);
            this.btnTotPop.Name = "btnTotPop";
            this.btnTotPop.Size = new System.Drawing.Size(98, 35);
            this.btnTotPop.TabIndex = 7;
            this.btnTotPop.Text = "TotalPop";
            this.btnTotPop.UseVisualStyleBackColor = true;
            this.btnTotPop.Click += new System.EventHandler(this.btnTotPop_Click);
            // 
            // btnAvgPop
            // 
            this.btnAvgPop.Location = new System.Drawing.Point(11, 195);
            this.btnAvgPop.Margin = new System.Windows.Forms.Padding(2);
            this.btnAvgPop.Name = "btnAvgPop";
            this.btnAvgPop.Size = new System.Drawing.Size(98, 35);
            this.btnAvgPop.TabIndex = 8;
            this.btnAvgPop.Text = "AvgPop";
            this.btnAvgPop.UseVisualStyleBackColor = true;
            this.btnAvgPop.Click += new System.EventHandler(this.btnAvgPop_Click);
            // 
            // btnHighPop
            // 
            this.btnHighPop.Location = new System.Drawing.Point(113, 156);
            this.btnHighPop.Margin = new System.Windows.Forms.Padding(2);
            this.btnHighPop.Name = "btnHighPop";
            this.btnHighPop.Size = new System.Drawing.Size(98, 35);
            this.btnHighPop.TabIndex = 9;
            this.btnHighPop.Text = "HighPop";
            this.btnHighPop.UseVisualStyleBackColor = true;
            this.btnHighPop.Click += new System.EventHandler(this.btnHighPop_Click);
            // 
            // btnLowPop
            // 
            this.btnLowPop.Location = new System.Drawing.Point(11, 156);
            this.btnLowPop.Margin = new System.Windows.Forms.Padding(2);
            this.btnLowPop.Name = "btnLowPop";
            this.btnLowPop.Size = new System.Drawing.Size(98, 35);
            this.btnLowPop.TabIndex = 10;
            this.btnLowPop.Text = "LowPop";
            this.btnLowPop.UseVisualStyleBackColor = true;
            this.btnLowPop.Click += new System.EventHandler(this.btnLowPop_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 50);
            this.panel1.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(658, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 24);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "🗑️";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "🫂 Population Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Methods";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(735, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLowPop);
            this.Controls.Add(this.btnHighPop);
            this.Controls.Add(this.btnAvgPop);
            this.Controls.Add(this.btnTotPop);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbSortBox);
            this.Controls.Add(this.popDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Population";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView popDataGridView;
        private CityDBDataSet cityDBDataSet;
        private System.Windows.Forms.BindingSource cityBindingSource;
        private CityDBDataSetTableAdapters.CityTableAdapter cityTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbSortBox;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label btnSave;
        private System.Windows.Forms.Button btnTotPop;
        private System.Windows.Forms.Button btnAvgPop;
        private System.Windows.Forms.Button btnHighPop;
        private System.Windows.Forms.Button btnLowPop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnDelete;
        private System.Windows.Forms.Label label2;
    }
}

