using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    partial class StockingDettagliView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockingDettagliView));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.fornitoreCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ragioneSocialTextBox = new System.Windows.Forms.TextBox();
            this.quantitaPerPaccoTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.descrizioneTextBox = new System.Windows.Forms.TextBox();
            this.codicearticolo_label = new System.Windows.Forms.Label();
            this.articoloCodeTextBox = new System.Windows.Forms.TextBox();
            this.dimensioneComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numeroPacchiNumBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.quantitaMossa = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.movimentoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroPacchiNumBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.fornitoreCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ragioneSocialTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 196);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 164);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label7.Location = new System.Drawing.Point(15, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 28);
            this.label7.TabIndex = 46;
            this.label7.Text = "Ragione sociale:";
            // 
            // fornitoreCode
            // 
            this.fornitoreCode.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.fornitoreCode.Location = new System.Drawing.Point(172, 10);
            this.fornitoreCode.Margin = new System.Windows.Forms.Padding(2);
            this.fornitoreCode.Name = "fornitoreCode";
            this.fornitoreCode.Size = new System.Drawing.Size(161, 34);
            this.fornitoreCode.TabIndex = 45;
            this.fornitoreCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fornitoreCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 28);
            this.label2.TabIndex = 44;
            this.label2.Text = "Codice fornitore:";
            // 
            // ragioneSocialTextBox
            // 
            this.ragioneSocialTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.ragioneSocialTextBox.Location = new System.Drawing.Point(167, 53);
            this.ragioneSocialTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ragioneSocialTextBox.MaxLength = 5;
            this.ragioneSocialTextBox.Name = "ragioneSocialTextBox";
            this.ragioneSocialTextBox.Size = new System.Drawing.Size(350, 34);
            this.ragioneSocialTextBox.TabIndex = 51;
            // 
            // quantitaPerPaccoTextBox
            // 
            this.quantitaPerPaccoTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.quantitaPerPaccoTextBox.Location = new System.Drawing.Point(193, 51);
            this.quantitaPerPaccoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.quantitaPerPaccoTextBox.MaxLength = 5;
            this.quantitaPerPaccoTextBox.Name = "quantitaPerPaccoTextBox";
            this.quantitaPerPaccoTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.quantitaPerPaccoTextBox.Size = new System.Drawing.Size(91, 34);
            this.quantitaPerPaccoTextBox.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.descrizioneTextBox);
            this.panel1.Controls.Add(this.codicearticolo_label);
            this.panel1.Controls.Add(this.articoloCodeTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 164);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 28);
            this.label4.TabIndex = 56;
            this.label4.Text = "Descrizione articolo:";
            // 
            // descrizioneTextBox
            // 
            this.descrizioneTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.descrizioneTextBox.Location = new System.Drawing.Point(197, 55);
            this.descrizioneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.descrizioneTextBox.Multiline = true;
            this.descrizioneTextBox.Name = "descrizioneTextBox";
            this.descrizioneTextBox.Size = new System.Drawing.Size(321, 50);
            this.descrizioneTextBox.TabIndex = 58;
            // 
            // codicearticolo_label
            // 
            this.codicearticolo_label.AutoSize = true;
            this.codicearticolo_label.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.codicearticolo_label.Location = new System.Drawing.Point(12, 12);
            this.codicearticolo_label.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.codicearticolo_label.Name = "codicearticolo_label";
            this.codicearticolo_label.Size = new System.Drawing.Size(148, 28);
            this.codicearticolo_label.TabIndex = 55;
            this.codicearticolo_label.Text = "Codice articolo:";
            // 
            // articoloCodeTextBox
            // 
            this.articoloCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.articoloCodeTextBox.Location = new System.Drawing.Point(160, 11);
            this.articoloCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.articoloCodeTextBox.Name = "articoloCodeTextBox";
            this.articoloCodeTextBox.Size = new System.Drawing.Size(178, 34);
            this.articoloCodeTextBox.TabIndex = 57;
            this.articoloCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.aritcoloCodeTextBox_KeyDown);
            // 
            // dimensioneComboBox
            // 
            this.dimensioneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dimensioneComboBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dimensioneComboBox.FormattingEnabled = true;
            this.dimensioneComboBox.Items.AddRange(new object[] {
            "",
            "Grande",
            "Medio",
            "Piccolo"});
            this.dimensioneComboBox.Location = new System.Drawing.Point(690, 49);
            this.dimensioneComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.dimensioneComboBox.Name = "dimensioneComboBox";
            this.dimensioneComboBox.Size = new System.Drawing.Size(111, 36);
            this.dimensioneComboBox.Sorted = true;
            this.dimensioneComboBox.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label5.Location = new System.Drawing.Point(574, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 28);
            this.label5.TabIndex = 59;
            this.label5.Text = "Dimensione:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.numeroPacchiNumBox);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dimensioneComboBox);
            this.panel3.Controls.Add(this.quantitaMossa);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.quantitaPerPaccoTextBox);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.movimentoTextBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 364);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1135, 166);
            this.panel3.TabIndex = 2;
            // 
            // numeroPacchiNumBox
            // 
            this.numeroPacchiNumBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.numeroPacchiNumBox.Location = new System.Drawing.Point(459, 53);
            this.numeroPacchiNumBox.Margin = new System.Windows.Forms.Padding(2);
            this.numeroPacchiNumBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numeroPacchiNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeroPacchiNumBox.Name = "numeroPacchiNumBox";
            this.numeroPacchiNumBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numeroPacchiNumBox.Size = new System.Drawing.Size(69, 34);
            this.numeroPacchiNumBox.TabIndex = 65;
            this.numeroPacchiNumBox.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numeroPacchiNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label10.Location = new System.Drawing.Point(339, 54);
            this.label10.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 28);
            this.label10.TabIndex = 64;
            this.label10.Text = "Totale pacchi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label9.Location = new System.Drawing.Point(542, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 28);
            this.label9.TabIndex = 62;
            this.label9.Text = "X";
            // 
            // quantitaMossa
            // 
            this.quantitaMossa.AutoSize = true;
            this.quantitaMossa.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.quantitaMossa.Location = new System.Drawing.Point(624, 10);
            this.quantitaMossa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantitaMossa.Name = "quantitaMossa";
            this.quantitaMossa.Size = new System.Drawing.Size(0, 28);
            this.quantitaMossa.TabIndex = 55;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.button2.Location = new System.Drawing.Point(955, 96);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 62);
            this.button2.TabIndex = 54;
            this.button2.Text = "Ricerca spazio disponibile.";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // movimentoTextBox
            // 
            this.movimentoTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.movimentoTextBox.Location = new System.Drawing.Point(127, 10);
            this.movimentoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.movimentoTextBox.MaxLength = 6;
            this.movimentoTextBox.Name = "movimentoTextBox";
            this.movimentoTextBox.Size = new System.Drawing.Size(65, 34);
            this.movimentoTextBox.TabIndex = 53;
            this.movimentoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.movimentoTextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 28);
            this.label3.TabIndex = 49;
            this.label3.Text = "Movimento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 28);
            this.label1.TabIndex = 48;
            this.label1.Text = "Quantità per pacco:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.007077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.66114F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.66114F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.67064F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 532);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1135, 22);
            this.panel4.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1135, 22);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 22);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(184, 19);
            this.toolStripLabel1.Text = "Immagazzinamento";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 19);
            this.toolStripButton1.Text = "Indietro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 19);
            this.toolStripButton2.Text = "Pulisci campi";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // StockingDettagliView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 532);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StockingDettagliView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Aggiungi merce al magazzino";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroPacchiNumBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PageSetupDialog pageSetupDialog1;
        private Panel panel2;
        private TextBox quantitaPerPaccoTextBox;
        private Label label7;
        private TextBox fornitoreCode;
        private Label label2;
        private Panel panel1;
        private ComboBox dimensioneComboBox;
        private Label label5;
        private Label label4;
        private TextBox descrizioneTextBox;
        private Label codicearticolo_label;
        private TextBox articoloCodeTextBox;
        private Panel panel3;
        private TextBox movimentoTextBox;
        private Label label3;
        private Label label1;
        private TextBox ragioneSocialTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Button button2;
        private Label quantitaMossa;
        private Label label10;
        private Label label9;
        private NumericUpDown numeroPacchiNumBox;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripLabel toolStripLabel1;
    }
}