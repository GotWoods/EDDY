namespace Eddy.ClassGenerator
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
            this.btnEdifactElement = new System.Windows.Forms.Button();
            this.btnEdifactSegment = new System.Windows.Forms.Button();
            this.txtEdifactSegment = new System.Windows.Forms.TextBox();
            this.btnx12Segment = new System.Windows.Forms.Button();
            this.txtX12 = new System.Windows.Forms.TextBox();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.btnx12BatchConvert = new System.Windows.Forms.Button();
            this.btnx12Element = new System.Windows.Forms.Button();
            this.txtx12Element = new System.Windows.Forms.TextBox();
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
            // btnEdifactElement
            // 
            this.btnEdifactElement.Location = new System.Drawing.Point(379, 37);
            this.btnEdifactElement.Name = "btnEdifactElement";
            this.btnEdifactElement.Size = new System.Drawing.Size(95, 23);
            this.btnEdifactElement.TabIndex = 6;
            this.btnEdifactElement.Text = "Convert >>";
            this.btnEdifactElement.UseVisualStyleBackColor = true;
            this.btnEdifactElement.Click += new System.EventHandler(this.btnEdifactElement_Click);
            // 
            // btnEdifactSegment
            // 
            this.btnEdifactSegment.Location = new System.Drawing.Point(379, 66);
            this.btnEdifactSegment.Name = "btnEdifactSegment";
            this.btnEdifactSegment.Size = new System.Drawing.Size(95, 23);
            this.btnEdifactSegment.TabIndex = 8;
            this.btnEdifactSegment.Text = "Convert >>";
            this.btnEdifactSegment.UseVisualStyleBackColor = true;
            this.btnEdifactSegment.Click += new System.EventHandler(this.btnEdifactSegment_Click);
            // 
            // txtEdifactSegment
            // 
            this.txtEdifactSegment.Location = new System.Drawing.Point(12, 67);
            this.txtEdifactSegment.Name = "txtEdifactSegment";
            this.txtEdifactSegment.Size = new System.Drawing.Size(361, 23);
            this.txtEdifactSegment.TabIndex = 7;
            this.txtEdifactSegment.Text = "https://www.stedi.com/edi/edifact/segments/BGM";
            // 
            // btnx12Segment
            // 
            this.btnx12Segment.Location = new System.Drawing.Point(379, 95);
            this.btnx12Segment.Name = "btnx12Segment";
            this.btnx12Segment.Size = new System.Drawing.Size(95, 23);
            this.btnx12Segment.TabIndex = 10;
            this.btnx12Segment.Text = "Convert >>";
            this.btnx12Segment.UseVisualStyleBackColor = true;
            this.btnx12Segment.Click += new System.EventHandler(this.btnx12Segment_Click);
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
            // btnx12BatchConvert
            // 
            this.btnx12BatchConvert.Location = new System.Drawing.Point(11, 150);
            this.btnx12BatchConvert.Name = "btnx12BatchConvert";
            this.btnx12BatchConvert.Size = new System.Drawing.Size(362, 23);
            this.btnx12BatchConvert.TabIndex = 12;
            this.btnx12BatchConvert.Text = "Generate Next 10 EDI x12 Segments";
            this.btnx12BatchConvert.UseVisualStyleBackColor = true;
            this.btnx12BatchConvert.Click += new System.EventHandler(this.btnx12BatchConvert_Click);
            // 
            // btnx12Element
            // 
            this.btnx12Element.Location = new System.Drawing.Point(379, 124);
            this.btnx12Element.Name = "btnx12Element";
            this.btnx12Element.Size = new System.Drawing.Size(95, 23);
            this.btnx12Element.TabIndex = 14;
            this.btnx12Element.Text = "Convert >>";
            this.btnx12Element.UseVisualStyleBackColor = true;
            this.btnx12Element.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtx12Element
            // 
            this.txtx12Element.Location = new System.Drawing.Point(12, 125);
            this.txtx12Element.Name = "txtx12Element";
            this.txtx12Element.Size = new System.Drawing.Size(361, 23);
            this.txtx12Element.TabIndex = 13;
            this.txtx12Element.Text = "https://www.stedi.com/edi/x12-008020/element/C030";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 463);
            this.Controls.Add(this.btnx12Element);
            this.Controls.Add(this.txtx12Element);
            this.Controls.Add(this.btnx12BatchConvert);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.btnx12Segment);
            this.Controls.Add(this.txtX12);
            this.Controls.Add(this.btnEdifactSegment);
            this.Controls.Add(this.txtEdifactSegment);
            this.Controls.Add(this.btnEdifactElement);
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
        private Button btnEdifactElement;
        private Button btnEdifactSegment;
        private TextBox txtEdifactSegment;
        private Button btnx12Segment;
        private TextBox txtX12;
        private TextBox txtTest;
        private Button btnx12BatchConvert;
        private Button btnx12Element;
        private TextBox txtx12Element;
    }
}