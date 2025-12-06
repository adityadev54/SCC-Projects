namespace _3Sports.UI
{
    partial class RacingSeasons
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
            this.btnBack = new System.Windows.Forms.Button();
            this.f1DB = new _3Sports.F1DB();
            this.racesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.racesTableAdapter = new _3Sports.F1DBTableAdapters.RacesTableAdapter();
            this.tableAdapterManager = new _3Sports.F1DBTableAdapters.TableAdapterManager();
            this.racesComboBox = new System.Windows.Forms.ComboBox();
            this.racesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.seasonsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(24, 27);
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
            // racesBindingSource
            // 
            this.racesBindingSource.DataMember = "Races";
            this.racesBindingSource.DataSource = this.f1DB;
            // 
            // racesTableAdapter
            // 
            this.racesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CircuitsTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ConstructorsTableAdapter = null;
            this.tableAdapterManager.CurrentConstructorsTableAdapter = null;
            this.tableAdapterManager.DriversTableAdapter = null;
            this.tableAdapterManager.ResultsTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = _3Sports.F1DBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // racesComboBox
            // 
            this.racesComboBox.DataSource = this.racesBindingSource;
            this.racesComboBox.DisplayMember = "Name";
            this.racesComboBox.FormattingEnabled = true;
            this.racesComboBox.Location = new System.Drawing.Point(413, 137);
            this.racesComboBox.Name = "racesComboBox";
            this.racesComboBox.Size = new System.Drawing.Size(120, 24);
            this.racesComboBox.TabIndex = 10;
            this.racesComboBox.ValueMember = "Year";
            // 
            // racesDataGridView
            // 
            this.racesDataGridView.AutoGenerateColumns = false;
            this.racesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.racesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.racesDataGridView.DataSource = this.racesBindingSource;
            this.racesDataGridView.Location = new System.Drawing.Point(48, 192);
            this.racesDataGridView.Name = "racesDataGridView";
            this.racesDataGridView.Size = new System.Drawing.Size(843, 319);
            this.racesDataGridView.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RaceID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RaceID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Year";
            this.dataGridViewTextBoxColumn2.HeaderText = "Year";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Round";
            this.dataGridViewTextBoxColumn3.HeaderText = "Round";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CircuitID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CircuitID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn6.HeaderText = "Date";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn7.HeaderText = "Time";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn8.HeaderText = "Url";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // lblInstructions
            // 
            this.lblInstructions.ForeColor = System.Drawing.Color.Transparent;
            this.lblInstructions.Location = new System.Drawing.Point(122, 86);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(690, 21);
            this.lblInstructions.TabIndex = 57;
            this.lblInstructions.Text = "Instruction: Select a season from the dropdown and view the details for each race" +
    " from that season.";
            // 
            // seasonsLabel
            // 
            this.seasonsLabel.ForeColor = System.Drawing.Color.Transparent;
            this.seasonsLabel.Location = new System.Drawing.Point(328, 140);
            this.seasonsLabel.Name = "seasonsLabel";
            this.seasonsLabel.Size = new System.Drawing.Size(79, 21);
            this.seasonsLabel.TabIndex = 58;
            this.seasonsLabel.Text = "Seasons:";
            // 
            // RacingSeasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(935, 551);
            this.Controls.Add(this.seasonsLabel);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.racesDataGridView);
            this.Controls.Add(this.racesComboBox);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RacingSeasons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RacingSeasons";
            this.Load += new System.EventHandler(this.RacingSeasons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private F1DB f1DB;
        private System.Windows.Forms.BindingSource racesBindingSource;
        private F1DBTableAdapters.RacesTableAdapter racesTableAdapter;
        private F1DBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox racesComboBox;
        private System.Windows.Forms.DataGridView racesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label seasonsLabel;
    }
}