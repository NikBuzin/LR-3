namespace LR_2_
{
    partial class LR6
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.But_Clean = new System.Windows.Forms.Button();
            this.CB_Betta = new System.Windows.Forms.CheckBox();
            this.CB_Bezie = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // But_Clean
            // 
            this.But_Clean.Location = new System.Drawing.Point(13, 12);
            this.But_Clean.Name = "But_Clean";
            this.But_Clean.Size = new System.Drawing.Size(60, 21);
            this.But_Clean.TabIndex = 5;
            this.But_Clean.Text = "Clean";
            this.But_Clean.UseVisualStyleBackColor = true;
            this.But_Clean.Click += new System.EventHandler(this.But_Clean_Click);
            // 
            // CB_Betta
            // 
            this.CB_Betta.AutoSize = true;
            this.CB_Betta.Location = new System.Drawing.Point(3, 39);
            this.CB_Betta.Name = "CB_Betta";
            this.CB_Betta.Size = new System.Drawing.Size(81, 17);
            this.CB_Betta.TabIndex = 7;
            this.CB_Betta.Text = "Betta-spline";
            this.CB_Betta.UseVisualStyleBackColor = true;
            this.CB_Betta.CheckedChanged += new System.EventHandler(this.ChangeCheck);
            // 
            // CB_Bezie
            // 
            this.CB_Bezie.AutoSize = true;
            this.CB_Bezie.Location = new System.Drawing.Point(3, 62);
            this.CB_Bezie.Name = "CB_Bezie";
            this.CB_Bezie.Size = new System.Drawing.Size(52, 17);
            this.CB_Bezie.TabIndex = 8;
            this.CB_Bezie.Text = "Bezie";
            this.CB_Bezie.UseVisualStyleBackColor = true;
            this.CB_Bezie.CheckedChanged += new System.EventHandler(this.ChangeCheck);
            this.CB_Bezie.Click += new System.EventHandler(this.CB_Betta_CheckedChanged);
            // 
            // LR6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(653, 643);
            this.Controls.Add(this.CB_Bezie);
            this.Controls.Add(this.CB_Betta);
            this.Controls.Add(this.But_Clean);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "LR6";
            this.Text = "LR6";
            this.Load += new System.EventHandler(this.LR3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LR3_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LR6_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LR6_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LR6_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LR3_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LR3_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LR3_MouseUp);
            this.Resize += new System.EventHandler(this.LR3_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button But_Clean;
        private System.Windows.Forms.CheckBox CB_Betta;
        private System.Windows.Forms.CheckBox CB_Bezie;
    }
}

