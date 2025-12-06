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
            this.cityDBDataSet = new Population.CityDBDataSet();
            this.cityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityTableAdapter = new Population.CityDBDataSetTableAdapters.CityTableAdapter();
            this.cityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSortBox = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Label();
            this.btnTotPop = new System.Windows.Forms.Button();
            this.btnAvgPop = new System.Windows.Forms.Button();
            this.btnHighPop = new System.Windows.Forms.Button();
            this.btnLowPop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // popDataGridView
            // 
            this.popDataGridView.AutoGenerateColumns = false;
            this.popDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.popDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cityIDDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.populationDataGridViewTextBoxColumn});
            this.popDataGridView.DataSource = this.cityBindingSource;
            this.popDataGridView.Location = new System.Drawing.Point(232, 75);
            this.popDataGridView.Name = "popDataGridView";
            this.popDataGridView.RowHeadersWidth = 51;
            this.popDataGridView.RowTemplate.Height = 24;
            this.popDataGridView.Size = new System.Drawing.Size(556, 363);
            this.popDataGridView.TabIndex = 0;
            // 
            // cityDBDataSet
            // 
            this.cityDBDataSet.DataSetName = "CityDBDataSet";
            this.cityDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityBindingSource
            // 
            this.cityBindingSource.DataMember = "City";
            this.cityBindingSource.DataSource = this.cityDBDataSet;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
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
            // cmbSortBox
            // 
            this.cmbSortBox.FormattingEnabled = true;
            this.cmbSortBox.Location = new System.Drawing.Point(12, 23);
            this.cmbSortBox.Name = "cmbSortBox";
            this.cmbSortBox.Size = new System.Drawing.Size(121, 24);
            this.cmbSortBox.TabIndex = 1;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(139, 24);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 387);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add City";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 417);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(749, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(39, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "🗃️";
            // 
            // btnTotPop
            // 
            this.btnTotPop.Location = new System.Drawing.Point(94, 414);
            this.btnTotPop.Name = "btnTotPop";
            this.btnTotPop.Size = new System.Drawing.Size(75, 23);
            this.btnTotPop.TabIndex = 7;
            this.btnTotPop.Text = "TotalPop";
            this.btnTotPop.UseVisualStyleBackColor = true;
            this.btnTotPop.Click += new System.EventHandler(this.btnTotPop_Click);
            // 
            // btnAvgPop
            // 
            this.btnAvgPop.Location = new System.Drawing.Point(94, 387);
            this.btnAvgPop.Name = "btnAvgPop";
            this.btnAvgPop.Size = new System.Drawing.Size(75, 23);
            this.btnAvgPop.TabIndex = 8;
            this.btnAvgPop.Text = "AvgPop";
            this.btnAvgPop.UseVisualStyleBackColor = true;
            this.btnAvgPop.Click += new System.EventHandler(this.btnAvgPop_Click);
            // 
            // btnHighPop
            // 
            this.btnHighPop.Location = new System.Drawing.Point(13, 358);
            this.btnHighPop.Name = "btnHighPop";
            this.btnHighPop.Size = new System.Drawing.Size(156, 23);
            this.btnHighPop.TabIndex = 9;
            this.btnHighPop.Text = "HighPop";
            this.btnHighPop.UseVisualStyleBackColor = true;
            this.btnHighPop.Click += new System.EventHandler(this.btnHighPop_Click);
            // 
            // btnLowPop
            // 
            this.btnLowPop.Location = new System.Drawing.Point(13, 329);
            this.btnLowPop.Name = "btnLowPop";
            this.btnLowPop.Size = new System.Drawing.Size(156, 23);
            this.btnLowPop.TabIndex = 10;
            this.btnLowPop.Text = "LowPop";
            this.btnLowPop.UseVisualStyleBackColor = true;
            this.btnLowPop.Click += new System.EventHandler(this.btnLowPop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLowPop);
            this.Controls.Add(this.btnHighPop);
            this.Controls.Add(this.btnAvgPop);
            this.Controls.Add(this.btnTotPop);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbSortBox);
            this.Controls.Add(this.popDataGridView);
            this.Name = "MainForm";
            this.Text = "Population";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label btnSave;
        private System.Windows.Forms.Button btnTotPop;
        private System.Windows.Forms.Button btnAvgPop;
        private System.Windows.Forms.Button btnHighPop;
        private System.Windows.Forms.Button btnLowPop;
    }
}

