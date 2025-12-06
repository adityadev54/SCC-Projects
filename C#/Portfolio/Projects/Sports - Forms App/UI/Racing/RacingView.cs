using System;
using System.Data;
using System.Windows.Forms;

namespace _3Sports.UI
{
    public partial class RacingSport : Form
    {
        private F1DB f1DB;
        private BindingSource currentConstructorsBindingSource;
        private System.ComponentModel.IContainer components;
        private F1DBTableAdapters.CurrentConstructorsTableAdapter currentConstructorsTableAdapter;
        private F1DBTableAdapters.TableAdapterManager tableAdapterManager;
        private ListBox listboxTeamName;
        private BindingSource currentConstructorsBindingSource1;
        private Button btnBack;
        private Button btnMoreDetails;
        private PictureBox picBoxWDC;
        private PictureBox picBoxDriver1;
        private PictureBox picBoxDriver2;
        private Label lblWcc;
        private Label lblPrincipal;
        private Label lblBase;
        private Label lblPwrUnit;
        private Button btnSeasons;
        private Label lblInstructions;
        //F1Class F1Class;
        public RacingSport()
        {
            InitializeComponent();
            this.listboxTeamName.SelectedIndexChanged += new System.EventHandler(this.listboxTeamName_SelectedIndexChanged);

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label teamNameLabel;
            System.Windows.Forms.Label principalLabel;
            System.Windows.Forms.Label driver1Label;
            System.Windows.Forms.Label d1NumLabel;
            System.Windows.Forms.Label driver2Label;
            System.Windows.Forms.Label d2NumLabel;
            System.Windows.Forms.Label championshipsLabel;
            System.Windows.Forms.Label baseLabel;
            System.Windows.Forms.Label powerUnitLabel;
            this.currentConstructorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.f1DB = new _3Sports.F1DB();
            this.currentConstructorsTableAdapter = new _3Sports.F1DBTableAdapters.CurrentConstructorsTableAdapter();
            this.tableAdapterManager = new _3Sports.F1DBTableAdapters.TableAdapterManager();
            this.listboxTeamName = new System.Windows.Forms.ListBox();
            this.currentConstructorsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMoreDetails = new System.Windows.Forms.Button();
            this.picBoxWDC = new System.Windows.Forms.PictureBox();
            this.picBoxDriver1 = new System.Windows.Forms.PictureBox();
            this.picBoxDriver2 = new System.Windows.Forms.PictureBox();
            this.lblWcc = new System.Windows.Forms.Label();
            this.lblPrincipal = new System.Windows.Forms.Label();
            this.lblBase = new System.Windows.Forms.Label();
            this.lblPwrUnit = new System.Windows.Forms.Label();
            this.btnSeasons = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            teamNameLabel = new System.Windows.Forms.Label();
            principalLabel = new System.Windows.Forms.Label();
            driver1Label = new System.Windows.Forms.Label();
            d1NumLabel = new System.Windows.Forms.Label();
            driver2Label = new System.Windows.Forms.Label();
            d2NumLabel = new System.Windows.Forms.Label();
            championshipsLabel = new System.Windows.Forms.Label();
            baseLabel = new System.Windows.Forms.Label();
            powerUnitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDriver1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDriver2)).BeginInit();
            this.SuspendLayout();
            // 
            // teamNameLabel
            // 
            teamNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "TeamName", true));
            teamNameLabel.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            teamNameLabel.ForeColor = System.Drawing.Color.Transparent;
            teamNameLabel.Location = new System.Drawing.Point(432, 43);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.Size = new System.Drawing.Size(319, 67);
            teamNameLabel.TabIndex = 11;
            teamNameLabel.Text = "Name";
            teamNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentConstructorsBindingSource
            // 
            this.currentConstructorsBindingSource.DataMember = "CurrentConstructors";
            this.currentConstructorsBindingSource.DataSource = this.f1DB;
            // 
            // f1DB
            // 
            this.f1DB.DataSetName = "F1DB";
            this.f1DB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // principalLabel
            // 
            principalLabel.BackColor = System.Drawing.Color.Transparent;
            principalLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "Principal", true));
            principalLabel.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            principalLabel.ForeColor = System.Drawing.Color.Transparent;
            principalLabel.Location = new System.Drawing.Point(591, 110);
            principalLabel.Name = "principalLabel";
            principalLabel.Size = new System.Drawing.Size(238, 50);
            principalLabel.TabIndex = 13;
            principalLabel.Text = "Principal";
            // 
            // driver1Label
            // 
            driver1Label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "Driver1", true));
            driver1Label.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            driver1Label.ForeColor = System.Drawing.Color.Transparent;
            driver1Label.Location = new System.Drawing.Point(373, 508);
            driver1Label.Name = "driver1Label";
            driver1Label.Size = new System.Drawing.Size(153, 87);
            driver1Label.TabIndex = 15;
            driver1Label.Text = "Driver1";
            // 
            // d1NumLabel
            // 
            d1NumLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "D1Num", true));
            d1NumLabel.Font = new System.Drawing.Font("Agency FB", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            d1NumLabel.ForeColor = System.Drawing.Color.Transparent;
            d1NumLabel.Location = new System.Drawing.Point(521, 508);
            d1NumLabel.Name = "d1NumLabel";
            d1NumLabel.Size = new System.Drawing.Size(62, 55);
            d1NumLabel.TabIndex = 17;
            d1NumLabel.Text = "D1Num";
            // 
            // driver2Label
            // 
            driver2Label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "Driver2", true));
            driver2Label.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            driver2Label.ForeColor = System.Drawing.Color.Transparent;
            driver2Label.Location = new System.Drawing.Point(616, 508);
            driver2Label.Name = "driver2Label";
            driver2Label.Size = new System.Drawing.Size(158, 87);
            driver2Label.TabIndex = 19;
            driver2Label.Text = "Driver2";
            // 
            // d2NumLabel
            // 
            d2NumLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "D2Num", true));
            d2NumLabel.Font = new System.Drawing.Font("Agency FB", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            d2NumLabel.ForeColor = System.Drawing.Color.Transparent;
            d2NumLabel.Location = new System.Drawing.Point(768, 508);
            d2NumLabel.Name = "d2NumLabel";
            d2NumLabel.Size = new System.Drawing.Size(66, 55);
            d2NumLabel.TabIndex = 21;
            d2NumLabel.Text = "D2Num";
            // 
            // championshipsLabel
            // 
            championshipsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "Championships", true));
            championshipsLabel.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            championshipsLabel.ForeColor = System.Drawing.Color.Transparent;
            championshipsLabel.Location = new System.Drawing.Point(176, 548);
            championshipsLabel.Name = "championshipsLabel";
            championshipsLabel.Size = new System.Drawing.Size(161, 38);
            championshipsLabel.TabIndex = 23;
            championshipsLabel.Text = "Championships";
            // 
            // baseLabel
            // 
            baseLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "Base", true));
            baseLabel.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            baseLabel.ForeColor = System.Drawing.Color.Transparent;
            baseLabel.Location = new System.Drawing.Point(591, 152);
            baseLabel.Name = "baseLabel";
            baseLabel.Size = new System.Drawing.Size(238, 46);
            baseLabel.TabIndex = 25;
            baseLabel.Text = "Base";
            // 
            // powerUnitLabel
            // 
            powerUnitLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentConstructorsBindingSource, "PowerUnit", true));
            powerUnitLabel.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            powerUnitLabel.ForeColor = System.Drawing.Color.Transparent;
            powerUnitLabel.Location = new System.Drawing.Point(591, 198);
            powerUnitLabel.Name = "powerUnitLabel";
            powerUnitLabel.Size = new System.Drawing.Size(202, 34);
            powerUnitLabel.TabIndex = 27;
            powerUnitLabel.Text = "PowerUnit";
            // 
            // currentConstructorsTableAdapter
            // 
            this.currentConstructorsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CircuitsTableAdapter = null;
            this.tableAdapterManager.ConstructorsTableAdapter = null;
            this.tableAdapterManager.CurrentConstructorsTableAdapter = this.currentConstructorsTableAdapter;
            this.tableAdapterManager.DriversTableAdapter = null;
            this.tableAdapterManager.ResultsTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = _3Sports.F1DBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // listboxTeamName
            // 
            this.listboxTeamName.DataSource = this.currentConstructorsBindingSource;
            this.listboxTeamName.DisplayMember = "TeamName";
            this.listboxTeamName.FormattingEnabled = true;
            this.listboxTeamName.ItemHeight = 16;
            this.listboxTeamName.Location = new System.Drawing.Point(82, 128);
            this.listboxTeamName.Name = "listboxTeamName";
            this.listboxTeamName.Size = new System.Drawing.Size(167, 180);
            this.listboxTeamName.TabIndex = 7;
            this.listboxTeamName.ValueMember = "ConstructorID";
            // 
            // currentConstructorsBindingSource1
            // 
            this.currentConstructorsBindingSource1.DataMember = "CurrentConstructors";
            this.currentConstructorsBindingSource1.DataSource = this.f1DB;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(32, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 36);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnMoreDetails
            // 
            this.btnMoreDetails.Location = new System.Drawing.Point(119, 26);
            this.btnMoreDetails.Name = "btnMoreDetails";
            this.btnMoreDetails.Size = new System.Drawing.Size(92, 36);
            this.btnMoreDetails.TabIndex = 9;
            this.btnMoreDetails.Text = "More Data";
            this.btnMoreDetails.UseVisualStyleBackColor = true;
            this.btnMoreDetails.Click += new System.EventHandler(this.btnMoreDetails_Click);
            // 
            // picBoxWDC
            // 
            this.picBoxWDC.BackgroundImage = global::_3Sports.Properties.Resources.wccTrophy;
            this.picBoxWDC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxWDC.InitialImage = null;
            this.picBoxWDC.Location = new System.Drawing.Point(82, 342);
            this.picBoxWDC.Name = "picBoxWDC";
            this.picBoxWDC.Size = new System.Drawing.Size(167, 194);
            this.picBoxWDC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxWDC.TabIndex = 28;
            this.picBoxWDC.TabStop = false;
            // 
            // picBoxDriver1
            // 
            this.picBoxDriver1.BackgroundImage = global::_3Sports.Properties.Resources.gasly;
            this.picBoxDriver1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxDriver1.Location = new System.Drawing.Point(377, 256);
            this.picBoxDriver1.Name = "picBoxDriver1";
            this.picBoxDriver1.Size = new System.Drawing.Size(191, 246);
            this.picBoxDriver1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDriver1.TabIndex = 29;
            this.picBoxDriver1.TabStop = false;
            // 
            // picBoxDriver2
            // 
            this.picBoxDriver2.BackgroundImage = global::_3Sports.Properties.Resources.doohan;
            this.picBoxDriver2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxDriver2.Location = new System.Drawing.Point(620, 259);
            this.picBoxDriver2.Name = "picBoxDriver2";
            this.picBoxDriver2.Size = new System.Drawing.Size(191, 246);
            this.picBoxDriver2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDriver2.TabIndex = 30;
            this.picBoxDriver2.TabStop = false;
            // 
            // lblWcc
            // 
            this.lblWcc.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWcc.ForeColor = System.Drawing.Color.Transparent;
            this.lblWcc.Location = new System.Drawing.Point(115, 548);
            this.lblWcc.Name = "lblWcc";
            this.lblWcc.Size = new System.Drawing.Size(66, 38);
            this.lblWcc.TabIndex = 34;
            this.lblWcc.Text = "WCC:";
            // 
            // lblPrincipal
            // 
            this.lblPrincipal.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrincipal.ForeColor = System.Drawing.Color.Transparent;
            this.lblPrincipal.Location = new System.Drawing.Point(441, 110);
            this.lblPrincipal.Name = "lblPrincipal";
            this.lblPrincipal.Size = new System.Drawing.Size(126, 42);
            this.lblPrincipal.TabIndex = 35;
            this.lblPrincipal.Text = "Principal:";
            // 
            // lblBase
            // 
            this.lblBase.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.Color.Transparent;
            this.lblBase.Location = new System.Drawing.Point(441, 152);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(76, 36);
            this.lblBase.TabIndex = 36;
            this.lblBase.Text = "Base:";
            // 
            // lblPwrUnit
            // 
            this.lblPwrUnit.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwrUnit.ForeColor = System.Drawing.Color.Transparent;
            this.lblPwrUnit.Location = new System.Drawing.Point(441, 198);
            this.lblPwrUnit.Name = "lblPwrUnit";
            this.lblPwrUnit.Size = new System.Drawing.Size(144, 48);
            this.lblPwrUnit.TabIndex = 37;
            this.lblPwrUnit.Text = "Power Unit:";
            // 
            // btnSeasons
            // 
            this.btnSeasons.Location = new System.Drawing.Point(220, 26);
            this.btnSeasons.Name = "btnSeasons";
            this.btnSeasons.Size = new System.Drawing.Size(92, 36);
            this.btnSeasons.TabIndex = 38;
            this.btnSeasons.Text = "Seasons";
            this.btnSeasons.UseVisualStyleBackColor = true;
            this.btnSeasons.Click += new System.EventHandler(this.btnSeasons_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.ForeColor = System.Drawing.Color.Transparent;
            this.lblInstructions.Location = new System.Drawing.Point(14, 89);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(323, 21);
            this.lblInstructions.TabIndex = 57;
            this.lblInstructions.Text = "Instruction: Select a team to view their details.";
            // 
            // RacingSport
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(869, 613);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnSeasons);
            this.Controls.Add(this.lblPwrUnit);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.lblPrincipal);
            this.Controls.Add(this.lblWcc);
            this.Controls.Add(this.picBoxDriver2);
            this.Controls.Add(this.picBoxDriver1);
            this.Controls.Add(this.picBoxWDC);
            this.Controls.Add(teamNameLabel);
            this.Controls.Add(principalLabel);
            this.Controls.Add(driver1Label);
            this.Controls.Add(d1NumLabel);
            this.Controls.Add(driver2Label);
            this.Controls.Add(d2NumLabel);
            this.Controls.Add(championshipsLabel);
            this.Controls.Add(baseLabel);
            this.Controls.Add(powerUnitLabel);
            this.Controls.Add(this.btnMoreDetails);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listboxTeamName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RacingSport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F1 Dashboard";
            this.Load += new System.EventHandler(this.RacingSport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentConstructorsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDriver1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDriver2)).EndInit();
            this.ResumeLayout(false);

        }

        private void currentConstructorsBindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            this.Validate();
            this.currentConstructorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.f1DB);

        }

        private void RacingSport_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'f1DB.CurrentConstructors' table. You can move, or remove it, as needed.
            this.currentConstructorsTableAdapter.Fill(this.f1DB.CurrentConstructors);

        }

        private void btnBack_Click_1(object sender, System.EventArgs e)
        {
            //Goes back to the main form and closes this form
            var SportSelection = new SportSelectView();
            SportSelection.Show();
            this.Close();
        }

        private void btnMoreDetails_Click(object sender, System.EventArgs e)
        {
            //Opens More Data form
            RacingMoreData racingDetailsForm = new RacingMoreData();
            racingDetailsForm.Show();
        }

        private void btnSeasons_Click(object sender, System.EventArgs e)
        {
            //OPens Seasons form
            RacingSeasons racingSeasonsForm = new RacingSeasons();
            racingSeasonsForm.Show();
        }

        private void listboxTeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checks if an item is selected
            if (listboxTeamName.SelectedIndex != -1)
            {
                DataRowView selectedRow = (DataRowView)listboxTeamName.SelectedItem;
                //selection equals teams name
                string selectedTeam = selectedRow["TeamName"].ToString();

                //Depending on selected team, switch through pics of drivers
                if (selectedTeam == "Alpine")
                {
                    picBoxDriver1.Image = Properties.Resources.gasly;
                    picBoxDriver2.Image = Properties.Resources.doohan;
                }
                else if (selectedTeam == "Aston Martin")
                {
                    picBoxDriver1.Image = Properties.Resources.stroll;
                    picBoxDriver2.Image = Properties.Resources.alonso;
                }
                else if (selectedTeam == "Scuderia Ferrari")
                {
                    picBoxDriver1.Image = Properties.Resources.leclerc;
                    picBoxDriver2.Image = Properties.Resources.hamilton;
                    //^this one is my fav
                }
                else if (selectedTeam == "Haas")
                {
                    picBoxDriver1.Image = Properties.Resources.ocon;
                    picBoxDriver2.Image = Properties.Resources.bearman;
                }
                else if (selectedTeam == "Kick Sauber")
                {
                    picBoxDriver1.Image = Properties.Resources.hulkenberg;
                    picBoxDriver2.Image = Properties.Resources.bortoleto;
                }
                else if (selectedTeam == "Mclaren")
                {
                    picBoxDriver1.Image = Properties.Resources.piastri;
                    picBoxDriver2.Image = Properties.Resources.norris;
                }
                else if (selectedTeam == "Mercedes")
                {
                    picBoxDriver1.Image = Properties.Resources.russel;
                    picBoxDriver2.Image = Properties.Resources.antonelli;
                }
                else if (selectedTeam == "Racing Bulls")
                {
                    picBoxDriver1.Image = Properties.Resources.hadjar;
                    picBoxDriver2.Image = Properties.Resources.tsunoda;
                }
                else if (selectedTeam == "Red Bull")
                {
                    picBoxDriver1.Image = Properties.Resources.verstappen;
                    picBoxDriver2.Image = Properties.Resources.lawson;
                }
                else if (selectedTeam == "Williams")
                {
                    picBoxDriver1.Image = Properties.Resources.albon;
                    picBoxDriver2.Image = Properties.Resources.sainz;
                }

            }
        }

    }
}
