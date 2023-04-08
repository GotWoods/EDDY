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
            txtOutput = new TextBox();
            txtEdifactElement = new TextBox();
            button2 = new Button();
            button3 = new Button();
            txtEdifactSegment = new TextBox();
            button4 = new Button();
            txtX12 = new TextBox();
            txtTest = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(560, 16);
            txtOutput.Margin = new Padding(3, 4, 3, 4);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(423, 567);
            txtOutput.TabIndex = 1;
            // 
            // txtEdifactElement
            // 
            txtEdifactElement.Location = new Point(14, 51);
            txtEdifactElement.Margin = new Padding(3, 4, 3, 4);
            txtEdifactElement.Name = "txtEdifactElement";
            txtEdifactElement.Size = new Size(412, 27);
            txtEdifactElement.TabIndex = 5;
            txtEdifactElement.Text = "https://www.stedi.com/edi/edifact/elements/E017";
            // 
            // button2
            // 
            button2.Location = new Point(433, 49);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(109, 31);
            button2.TabIndex = 6;
            button2.Text = "Convert >>";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(433, 88);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(109, 31);
            button3.TabIndex = 8;
            button3.Text = "Convert >>";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtEdifactSegment
            // 
            txtEdifactSegment.Location = new Point(14, 89);
            txtEdifactSegment.Margin = new Padding(3, 4, 3, 4);
            txtEdifactSegment.Name = "txtEdifactSegment";
            txtEdifactSegment.Size = new Size(412, 27);
            txtEdifactSegment.TabIndex = 7;
            txtEdifactSegment.Text = "https://www.stedi.com/edi/edifact/segments/BGM";
            // 
            // button4
            // 
            button4.Location = new Point(433, 127);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(109, 31);
            button4.TabIndex = 10;
            button4.Text = "Convert >>";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // txtX12
            // 
            txtX12.Location = new Point(14, 128);
            txtX12.Margin = new Padding(3, 4, 3, 4);
            txtX12.Name = "txtX12";
            txtX12.Size = new Size(412, 27);
            txtX12.TabIndex = 9;
            txtX12.Text = "https://www.stedi.com/edi/x12-008020/segment/MS1";
            // 
            // txtTest
            // 
            txtTest.Location = new Point(1013, 16);
            txtTest.Margin = new Padding(3, 4, 3, 4);
            txtTest.Multiline = true;
            txtTest.Name = "txtTest";
            txtTest.ScrollBars = ScrollBars.Vertical;
            txtTest.Size = new Size(423, 567);
            txtTest.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(12, 163);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(414, 31);
            button1.TabIndex = 12;
            button1.Text = "Generate Next 10 EDI x12 Segments";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 617);
            Controls.Add(button1);
            Controls.Add(txtTest);
            Controls.Add(button4);
            Controls.Add(txtX12);
            Controls.Add(button3);
            Controls.Add(txtEdifactSegment);
            Controls.Add(button2);
            Controls.Add(txtEdifactElement);
            Controls.Add(txtOutput);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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
        private Button button1;
    }
}