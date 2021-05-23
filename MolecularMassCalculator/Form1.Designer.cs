namespace MolecularMassCalculator
{
    partial class Form1
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
            this.UI_dgvElements = new System.Windows.Forms.DataGridView();
            this.UI_btnSortName = new System.Windows.Forms.Button();
            this.UI_btnSymbol = new System.Windows.Forms.Button();
            this.UI_btnSortAtomic = new System.Windows.Forms.Button();
            this.UI_lblFormula = new System.Windows.Forms.Label();
            this.UI_tbFormula = new System.Windows.Forms.TextBox();
            this.UI_lblMolarMass = new System.Windows.Forms.Label();
            this.UI_tbMolarMass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_dgvElements)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_dgvElements
            // 
            this.UI_dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_dgvElements.Location = new System.Drawing.Point(13, 13);
            this.UI_dgvElements.Name = "UI_dgvElements";
            this.UI_dgvElements.Size = new System.Drawing.Size(630, 384);
            this.UI_dgvElements.TabIndex = 0;
            // 
            // UI_btnSortName
            // 
            this.UI_btnSortName.Location = new System.Drawing.Point(649, 13);
            this.UI_btnSortName.Name = "UI_btnSortName";
            this.UI_btnSortName.Size = new System.Drawing.Size(139, 28);
            this.UI_btnSortName.TabIndex = 1;
            this.UI_btnSortName.Text = "Sort By Name";
            this.UI_btnSortName.UseVisualStyleBackColor = true;
            this.UI_btnSortName.Click += new System.EventHandler(this.UI_btnSortName_Click);
            // 
            // UI_btnSymbol
            // 
            this.UI_btnSymbol.Location = new System.Drawing.Point(649, 47);
            this.UI_btnSymbol.Name = "UI_btnSymbol";
            this.UI_btnSymbol.Size = new System.Drawing.Size(139, 28);
            this.UI_btnSymbol.TabIndex = 2;
            this.UI_btnSymbol.Text = "Single Character Symbols";
            this.UI_btnSymbol.UseVisualStyleBackColor = true;
            this.UI_btnSymbol.Click += new System.EventHandler(this.UI_btnSymbol_Click);
            // 
            // UI_btnSortAtomic
            // 
            this.UI_btnSortAtomic.Location = new System.Drawing.Point(649, 81);
            this.UI_btnSortAtomic.Name = "UI_btnSortAtomic";
            this.UI_btnSortAtomic.Size = new System.Drawing.Size(139, 28);
            this.UI_btnSortAtomic.TabIndex = 3;
            this.UI_btnSortAtomic.Text = "Sort by Atomic #";
            this.UI_btnSortAtomic.UseVisualStyleBackColor = true;
            this.UI_btnSortAtomic.Click += new System.EventHandler(this.UI_btnSortAtomic_Click);
            // 
            // UI_lblFormula
            // 
            this.UI_lblFormula.AutoSize = true;
            this.UI_lblFormula.Location = new System.Drawing.Point(13, 413);
            this.UI_lblFormula.Name = "UI_lblFormula";
            this.UI_lblFormula.Size = new System.Drawing.Size(93, 13);
            this.UI_lblFormula.TabIndex = 4;
            this.UI_lblFormula.Text = "Chemical Formula:";
            // 
            // UI_tbFormula
            // 
            this.UI_tbFormula.Location = new System.Drawing.Point(109, 413);
            this.UI_tbFormula.Name = "UI_tbFormula";
            this.UI_tbFormula.Size = new System.Drawing.Size(338, 20);
            this.UI_tbFormula.TabIndex = 5;
            this.UI_tbFormula.TextChanged += new System.EventHandler(this.UI_tbFormula_TextChanged);
            // 
            // UI_lblMolarMass
            // 
            this.UI_lblMolarMass.AutoSize = true;
            this.UI_lblMolarMass.Location = new System.Drawing.Point(565, 413);
            this.UI_lblMolarMass.Name = "UI_lblMolarMass";
            this.UI_lblMolarMass.Size = new System.Drawing.Size(103, 13);
            this.UI_lblMolarMass.TabIndex = 6;
            this.UI_lblMolarMass.Text = "Approx. Molar Mass:";
            // 
            // UI_tbMolarMass
            // 
            this.UI_tbMolarMass.Location = new System.Drawing.Point(671, 410);
            this.UI_tbMolarMass.Name = "UI_tbMolarMass";
            this.UI_tbMolarMass.Size = new System.Drawing.Size(117, 20);
            this.UI_tbMolarMass.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_tbMolarMass);
            this.Controls.Add(this.UI_lblMolarMass);
            this.Controls.Add(this.UI_tbFormula);
            this.Controls.Add(this.UI_lblFormula);
            this.Controls.Add(this.UI_btnSortAtomic);
            this.Controls.Add(this.UI_btnSymbol);
            this.Controls.Add(this.UI_btnSortName);
            this.Controls.Add(this.UI_dgvElements);
            this.Name = "Form1";
            this.Text = "LINQ ICA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_dgvElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_dgvElements;
        private System.Windows.Forms.Button UI_btnSortName;
        private System.Windows.Forms.Button UI_btnSymbol;
        private System.Windows.Forms.Button UI_btnSortAtomic;
        private System.Windows.Forms.Label UI_lblFormula;
        private System.Windows.Forms.TextBox UI_tbFormula;
        private System.Windows.Forms.Label UI_lblMolarMass;
        private System.Windows.Forms.TextBox UI_tbMolarMass;
    }
}

