namespace DevTool
{
    partial class UnPackDD05
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Conversion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Location = new System.Drawing.Point(12, 24);
            this.SourceTextBox.Multiline = true;
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourceTextBox.Size = new System.Drawing.Size(765, 203);
            this.SourceTextBox.TabIndex = 1;
            this.SourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SourceTextBox_KeyPress);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(12, 351);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(765, 203);
            this.ResultTextBox.TabIndex = 2;
            this.ResultTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SourceTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result";
            // 
            // Conversion
            // 
            this.Conversion.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Conversion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Conversion.Location = new System.Drawing.Point(124, 254);
            this.Conversion.Name = "Conversion";
            this.Conversion.Size = new System.Drawing.Size(483, 65);
            this.Conversion.TabIndex = 4;
            this.Conversion.Text = "conversion";
            this.Conversion.UseVisualStyleBackColor = true;
            this.Conversion.Click += new System.EventHandler(this.Conversion_Click);
            // 
            // UnPackDD05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 566);
            this.Controls.Add(this.Conversion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.label1);
            this.Name = "UnPackDD05";
            this.Text = "UnPackDD05";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Conversion;
    }
}

