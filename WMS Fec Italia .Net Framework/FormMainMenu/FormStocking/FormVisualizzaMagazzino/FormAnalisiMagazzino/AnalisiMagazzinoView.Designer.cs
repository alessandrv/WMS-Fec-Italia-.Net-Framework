
using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    partial class AnalisiMagazzinoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalisiMagazzinoView));
            this.dataGridViewListaArticoli = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.articoloTextBox = new System.Windows.Forms.TextBox();
            this.fornitoreTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewLocazioniArticolo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaArticoli)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocazioniArticolo)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListaArticoli
            // 
            this.dataGridViewListaArticoli.AllowUserToAddRows = false;
            this.dataGridViewListaArticoli.AllowUserToDeleteRows = false;
            this.dataGridViewListaArticoli.AllowUserToOrderColumns = true;
            this.dataGridViewListaArticoli.AllowUserToResizeColumns = false;
            this.dataGridViewListaArticoli.AllowUserToResizeRows = false;
            this.dataGridViewListaArticoli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListaArticoli.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewListaArticoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListaArticoli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListaArticoli.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewListaArticoli.Location = new System.Drawing.Point(2, 54);
            this.dataGridViewListaArticoli.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListaArticoli.MultiSelect = false;
            this.dataGridViewListaArticoli.Name = "dataGridViewListaArticoli";
            this.dataGridViewListaArticoli.ReadOnly = true;
            this.dataGridViewListaArticoli.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewListaArticoli.RowHeadersVisible = false;
            this.dataGridViewListaArticoli.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewListaArticoli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListaArticoli.Size = new System.Drawing.Size(373, 445);
            this.dataGridViewListaArticoli.TabIndex = 0;
            this.dataGridViewListaArticoli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListaArticoli_CellClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(2, 411);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(374, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Visualizza locazione singoli pacchi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Codice fornitore:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Codice articolo:";
            // 
            // articoloTextBox
            // 
            this.articoloTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articoloTextBox.Location = new System.Drawing.Point(102, 5);
            this.articoloTextBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.articoloTextBox.Name = "articoloTextBox";
            this.articoloTextBox.Size = new System.Drawing.Size(278, 20);
            this.articoloTextBox.TabIndex = 17;
            this.articoloTextBox.TextChanged += new System.EventHandler(this.cambioFiltri);
            // 
            // fornitoreTextBox
            // 
            this.fornitoreTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fornitoreTextBox.Location = new System.Drawing.Point(102, 29);
            this.fornitoreTextBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.fornitoreTextBox.Name = "fornitoreTextBox";
            this.fornitoreTextBox.Size = new System.Drawing.Size(278, 20);
            this.fornitoreTextBox.TabIndex = 18;
            this.fornitoreTextBox.TextChanged += new System.EventHandler(this.cambioFiltri);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewLocazioniArticolo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewListaArticoli, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 501);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // dataGridViewLocazioniArticolo
            // 
            this.dataGridViewLocazioniArticolo.AllowUserToAddRows = false;
            this.dataGridViewLocazioniArticolo.AllowUserToDeleteRows = false;
            this.dataGridViewLocazioniArticolo.AllowUserToOrderColumns = true;
            this.dataGridViewLocazioniArticolo.AllowUserToResizeColumns = false;
            this.dataGridViewLocazioniArticolo.AllowUserToResizeRows = false;
            this.dataGridViewLocazioniArticolo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLocazioniArticolo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLocazioniArticolo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocazioniArticolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLocazioniArticolo.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewLocazioniArticolo.Location = new System.Drawing.Point(379, 54);
            this.dataGridViewLocazioniArticolo.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewLocazioniArticolo.MultiSelect = false;
            this.dataGridViewLocazioniArticolo.Name = "dataGridViewLocazioniArticolo";
            this.dataGridViewLocazioniArticolo.ReadOnly = true;
            this.dataGridViewLocazioniArticolo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewLocazioniArticolo.RowHeadersVisible = false;
            this.dataGridViewLocazioniArticolo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewLocazioniArticolo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLocazioniArticolo.Size = new System.Drawing.Size(373, 445);
            this.dataGridViewLocazioniArticolo.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(756, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 445);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fornitoreTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.articoloTextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(373, 48);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.2381F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1139, 532);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 501);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1133, 19);
            this.panel3.TabIndex = 21;
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
            this.toolStrip1.Size = new System.Drawing.Size(1133, 19);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 16);
            this.toolStripButton1.Text = "Indietro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 19);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 16);
            this.toolStripButton2.Text = "Aggiorna";
            this.toolStripButton2.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(254, 16);
            this.toolStripLabel1.Text = "Visualizza merce magazzino";
            // 
            // AnalisiMagazzinoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1139, 532);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AnalisiMagazzinoView";
            this.Text = "Visualizza merce magazzino";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaArticoli)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocazioniArticolo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridViewListaArticoli;
        private Label order_date;
        private Button button2;
        private Label label1;
        private Label label4;
        private TextBox articoloTextBox;
        private TextBox fornitoreTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DataGridView dataGridViewLocazioniArticolo;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private Panel panel3;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButton2;
    }
}
