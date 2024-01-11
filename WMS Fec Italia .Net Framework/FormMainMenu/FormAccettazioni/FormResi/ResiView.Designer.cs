using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    partial class ResiView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResiView));
            this.arrivato = new System.Windows.Forms.Label();
            this.aperti_checkbox = new System.Windows.Forms.CheckBox();
            this.revisionaOrdineButton = new System.Windows.Forms.Button();
            this.fornitoreComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.codiceOrdineTextBox = new System.Windows.Forms.TextBox();
            this.inArrivo_checkbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridViewOrdiniDaConfermare = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdiniDaConfermare)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // arrivato
            // 
            this.arrivato.AutoSize = true;
            this.arrivato.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.arrivato.Location = new System.Drawing.Point(1101, 174);
            this.arrivato.Name = "arrivato";
            this.arrivato.Size = new System.Drawing.Size(82, 35);
            this.arrivato.TabIndex = 7;
            this.arrivato.Text = "Aperti";
            // 
            // aperti_checkbox
            // 
            this.aperti_checkbox.AutoSize = true;
            this.aperti_checkbox.Checked = true;
            this.aperti_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aperti_checkbox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.aperti_checkbox.Location = new System.Drawing.Point(1195, 183);
            this.aperti_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aperti_checkbox.Name = "aperti_checkbox";
            this.aperti_checkbox.Size = new System.Drawing.Size(18, 17);
            this.aperti_checkbox.TabIndex = 8;
            this.aperti_checkbox.UseVisualStyleBackColor = true;
            this.aperti_checkbox.CheckedChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // revisionaOrdineButton
            // 
            this.revisionaOrdineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.revisionaOrdineButton.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.revisionaOrdineButton.Location = new System.Drawing.Point(1104, 380);
            this.revisionaOrdineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.revisionaOrdineButton.Name = "revisionaOrdineButton";
            this.revisionaOrdineButton.Size = new System.Drawing.Size(277, 41);
            this.revisionaOrdineButton.TabIndex = 1;
            this.revisionaOrdineButton.Text = "Revisiona ordine";
            this.revisionaOrdineButton.UseVisualStyleBackColor = true;
            this.revisionaOrdineButton.Click += new System.EventHandler(this.RevisionaOrdineButton_Click);
            // 
            // fornitoreComboBox
            // 
            this.fornitoreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fornitoreComboBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.fornitoreComboBox.FormattingEnabled = true;
            this.fornitoreComboBox.IntegralHeight = false;
            this.fornitoreComboBox.Location = new System.Drawing.Point(1203, 0);
            this.fornitoreComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fornitoreComboBox.MaxDropDownItems = 16;
            this.fornitoreComboBox.Name = "fornitoreComboBox";
            this.fornitoreComboBox.Size = new System.Drawing.Size(209, 43);
            this.fornitoreComboBox.Sorted = true;
            this.fornitoreComboBox.TabIndex = 11;
            this.fornitoreComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.Location = new System.Drawing.Point(1101, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label4.Location = new System.Drawing.Point(1101, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 35);
            this.label4.TabIndex = 16;
            this.label4.Text = "Codice ordine:";
            // 
            // codiceOrdineTextBox
            // 
            this.codiceOrdineTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.codiceOrdineTextBox.Location = new System.Drawing.Point(1291, 116);
            this.codiceOrdineTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codiceOrdineTextBox.Name = "codiceOrdineTextBox";
            this.codiceOrdineTextBox.Size = new System.Drawing.Size(96, 41);
            this.codiceOrdineTextBox.TabIndex = 17;
            this.codiceOrdineTextBox.TextChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // inArrivo_checkbox
            // 
            this.inArrivo_checkbox.AutoSize = true;
            this.inArrivo_checkbox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.inArrivo_checkbox.Location = new System.Drawing.Point(1276, 246);
            this.inArrivo_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inArrivo_checkbox.Name = "inArrivo_checkbox";
            this.inArrivo_checkbox.Size = new System.Drawing.Size(18, 17);
            this.inArrivo_checkbox.TabIndex = 19;
            this.inArrivo_checkbox.UseVisualStyleBackColor = true;
            this.inArrivo_checkbox.CheckedChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label3.Location = new System.Drawing.Point(1098, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 35);
            this.label3.TabIndex = 18;
            this.label3.Text = "Solo in arrivo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tipoComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.inArrivo_checkbox);
            this.panel1.Controls.Add(this.dataGridViewOrdiniDaConfermare);
            this.panel1.Controls.Add(this.revisionaOrdineButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.arrivato);
            this.panel1.Controls.Add(this.codiceOrdineTextBox);
            this.panel1.Controls.Add(this.aperti_checkbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fornitoreComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2168, 1047);
            this.panel1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label5.Location = new System.Drawing.Point(1104, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 35);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tipo:";
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComboBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Location = new System.Drawing.Point(1183, 57);
            this.tipoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(48, 43);
            this.tipoComboBox.Sorted = true;
            this.tipoComboBox.TabIndex = 20;
            this.tipoComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // dataGridViewOrdiniDaConfermare
            // 
            this.dataGridViewOrdiniDaConfermare.AllowUserToAddRows = false;
            this.dataGridViewOrdiniDaConfermare.AllowUserToDeleteRows = false;
            this.dataGridViewOrdiniDaConfermare.AllowUserToResizeColumns = false;
            this.dataGridViewOrdiniDaConfermare.AllowUserToResizeRows = false;
            this.dataGridViewOrdiniDaConfermare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOrdiniDaConfermare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewOrdiniDaConfermare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrdiniDaConfermare.Location = new System.Drawing.Point(3, -1);
            this.dataGridViewOrdiniDaConfermare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewOrdiniDaConfermare.MultiSelect = false;
            this.dataGridViewOrdiniDaConfermare.Name = "dataGridViewOrdiniDaConfermare";
            this.dataGridViewOrdiniDaConfermare.ReadOnly = true;
            this.dataGridViewOrdiniDaConfermare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewOrdiniDaConfermare.RowHeadersVisible = false;
            this.dataGridViewOrdiniDaConfermare.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewOrdiniDaConfermare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrdiniDaConfermare.Size = new System.Drawing.Size(1095, 1040);
            this.dataGridViewOrdiniDaConfermare.TabIndex = 0;
            this.dataGridViewOrdiniDaConfermare.SelectionChanged += new System.EventHandler(this.dataGridViewOrdiniDaConfermare_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2168, 47);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 44);
            this.toolStripButton1.Text = "Indietro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(75, 44);
            this.toolStripButton2.Text = "Aggiorna";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2176, 1110);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2168, 47);
            this.panel2.TabIndex = 21;
            // 
            // ResiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2176, 1110);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResiView";
            this.Text = "Resi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAccettazione_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdiniDaConfermare)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label order_date;
        private Label arrivato;
        private CheckBox aperti_checkbox;
        private Button revisionaOrdineButton;
        private ComboBox fornitoreComboBox;
        private Label label1;
        private Label label4;
        private TextBox codiceOrdineTextBox;
        private CheckBox inArrivo_checkbox;
        private Label label3;
        private Panel panel1;
        private DataGridView dataGridViewOrdiniDaConfermare;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private Panel panel2;
        private Label label5;
        private ComboBox tipoComboBox;
    }
}
