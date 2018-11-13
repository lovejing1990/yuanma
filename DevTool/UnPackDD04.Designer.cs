namespace DevTool
{
	partial class UnPackDD04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnPackDD04));
            this.Conversion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Conversion
            // 
            this.Conversion.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Conversion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Conversion.Location = new System.Drawing.Point(125, 248);
            this.Conversion.Name = "Conversion";
            this.Conversion.Size = new System.Drawing.Size(196, 65);
            this.Conversion.TabIndex = 9;
            this.Conversion.Text = "D(S->R)";
            this.Conversion.UseVisualStyleBackColor = true;
            this.Conversion.Click += new System.EventHandler(this.Conversion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Result";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(13, 345);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(759, 203);
            this.ResultTextBox.TabIndex = 7;
            this.ResultTextBox.Text = resources.GetString("ResultTextBox.Text");
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Location = new System.Drawing.Point(13, 18);
            this.SourceTextBox.Multiline = true;
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourceTextBox.Size = new System.Drawing.Size(759, 203);
            this.SourceTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(425, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 65);
            this.button1.TabIndex = 10;
            this.button1.Text = "I(R->S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UnPackDD04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Conversion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.label1);
            this.Name = "UnPackDD04";
            this.Text = "UnPackDD04";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Conversion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ResultTextBox;
		private System.Windows.Forms.TextBox SourceTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}
