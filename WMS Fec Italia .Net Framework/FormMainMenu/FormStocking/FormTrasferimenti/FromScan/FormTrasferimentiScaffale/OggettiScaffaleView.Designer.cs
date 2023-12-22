using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    partial class OggettiScaffaleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OggettiScaffaleView));
            this.dataGridViewOggettiScaffale = new System.Windows.Forms.DataGridView();
            this.trasferisciButton = new System.Windows.Forms.Button();
            this.orderID_label = new System.Windows.Forms.Label();
            this.fornitore_label = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scaffaleLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOggettiScaffale)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOggettiScaffale
            // 
            this.dataGridViewOggettiScaffale.AllowUserToAddRows = false;
            this.dataGridViewOggettiScaffale.AllowUserToDeleteRows = false;
            this.dataGridViewOggettiScaffale.AllowUserToResizeColumns = false;
            this.dataGridViewOggettiScaffale.AllowUserToResizeRows = false;
            this.dataGridViewOggettiScaffale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOggettiScaffale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewOggettiScaffale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOggettiScaffale.Location = new System.Drawing.Point(0, 2);
            this.dataGridViewOggettiScaffale.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewOggettiScaffale.MultiSelect = false;
            this.dataGridViewOggettiScaffale.Name = "dataGridViewOggettiScaffale";
            this.dataGridViewOggettiScaffale.ReadOnly = true;
            this.dataGridViewOggettiScaffale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewOggettiScaffale.RowHeadersVisible = false;
            this.dataGridViewOggettiScaffale.RowHeadersWidth = 62;
            this.dataGridViewOggettiScaffale.RowTemplate.Height = 100;
            this.dataGridViewOggettiScaffale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOggettiScaffale.Size = new System.Drawing.Size(716, 501);
            this.dataGridViewOggettiScaffale.TabIndex = 1;
            this.dataGridViewOggettiScaffale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOggettiOrdine_CellContentClick);
            // 
            // trasferisciButton
            // 
            this.trasferisciButton.Location = new System.Drawing.Point(719, 458);
            this.trasferisciButton.Margin = new System.Windows.Forms.Padding(2);
            this.trasferisciButton.Name = "trasferisciButton";
            this.trasferisciButton.Size = new System.Drawing.Size(233, 36);
            this.trasferisciButton.TabIndex = 2;
            this.trasferisciButton.Text = "Avvia trasferimento";
            this.trasferisciButton.UseVisualStyleBackColor = true;
            this.trasferisciButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // orderID_label
            // 
            this.orderID_label.AutoSize = true;
            this.orderID_label.Location = new System.Drawing.Point(898, 4);
            this.orderID_label.Name = "orderID_label";
            this.orderID_label.Size = new System.Drawing.Size(0, 13);
            this.orderID_label.TabIndex = 4;
            // 
            // fornitore_label
            // 
            this.fornitore_label.AutoSize = true;
            this.fornitore_label.Location = new System.Drawing.Point(898, 29);
            this.fornitore_label.Name = "fornitore_label";
            this.fornitore_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fornitore_label.Size = new System.Drawing.Size(0, 13);
            this.fornitore_label.TabIndex = 5;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Location = new System.Drawing.Point(898, 53);
            this.date_label.Name = "date_label";
            this.date_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date_label.Size = new System.Drawing.Size(0, 13);
            this.date_label.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 532);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewOggettiScaffale);
            this.panel1.Controls.Add(this.trasferisciButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 500);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 20);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.scaffaleLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1133, 20);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 17);
            this.toolStripButton1.Text = "Indietro";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // scaffaleLabel
            // 
            this.scaffaleLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.scaffaleLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.scaffaleLabel.Name = "scaffaleLabel";
            this.scaffaleLabel.Size = new System.Drawing.Size(79, 17);
            this.scaffaleLabel.Text = "Scaffale";
            // 
            // OggettiScaffaleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 532);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.fornitore_label);
            this.Controls.Add(this.orderID_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OggettiScaffaleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista ordine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOggettiScaffale)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewOggettiScaffale;
        private Button trasferisciButton;
        private Label orderID_label;
        private Label fornitore_label;
        private Label date_label;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel scaffaleLabel;
    }
}