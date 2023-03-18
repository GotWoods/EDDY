namespace EdiParser.ClassGenerator
{
    partial class Form1
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtEdifactElement = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtEdifactSegment = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtX12 = new System.Windows.Forms.TextBox();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(490, 12);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(371, 426);
            this.txtOutput.TabIndex = 1;
            // 
            // txtEdifactElement
            // 
            this.txtEdifactElement.Location = new System.Drawing.Point(12, 38);
            this.txtEdifactElement.Name = "txtEdifactElement";
            this.txtEdifactElement.Size = new System.Drawing.Size(361, 23);
            this.txtEdifactElement.TabIndex = 5;
            this.txtEdifactElement.Text = "https://www.stedi.com/edi/edifact/elements/E017";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Convert >>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(379, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Convert >>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtEdifactSegment
            // 
            this.txtEdifactSegment.Location = new System.Drawing.Point(12, 67);
            this.txtEdifactSegment.Name = "txtEdifactSegment";
            this.txtEdifactSegment.Size = new System.Drawing.Size(361, 23);
            this.txtEdifactSegment.TabIndex = 7;
            this.txtEdifactSegment.Text = "https://www.stedi.com/edi/edifact/segments/BGM";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(379, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Convert >>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtX12
            // 
            this.txtX12.Location = new System.Drawing.Point(12, 96);
            this.txtX12.Name = "txtX12";
            this.txtX12.Size = new System.Drawing.Size(361, 23);
            this.txtX12.TabIndex = 9;
            this.txtX12.Text = "https://www.stedi.com/edi/x12-008020/segment/MS1";
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(886, 12);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTest.Size = new System.Drawing.Size(371, 426);
            this.txtTest.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 463);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtX12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtEdifactSegment);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtEdifactElement);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtOutput;
        private TextBox txtEdifactElement;
        private Button button2;
        private Button button3;
        private TextBox txtEdifactSegment;
        private Button button4;
        private TextBox txtX12;
        private TextBox txtTest;
    }
}