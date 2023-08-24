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
            txtOutput = new TextBox();
            txtEdifactElement = new TextBox();
            btnEdifactElement = new Button();
            btnEdifactSegment = new Button();
            txtEdifactSegment = new TextBox();
            btnx12Segment = new Button();
            txtX12 = new TextBox();
            txtTest = new TextBox();
            btnx12BatchConvert = new Button();
            btnx12Element = new Button();
            txtx12Element = new TextBox();
            txtBatchCount = new TextBox();
            txtLog = new TextBox();
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
            // btnEdifactElement
            // 
            btnEdifactElement.Location = new Point(433, 49);
            btnEdifactElement.Margin = new Padding(3, 4, 3, 4);
            btnEdifactElement.Name = "btnEdifactElement";
            btnEdifactElement.Size = new Size(109, 31);
            btnEdifactElement.TabIndex = 6;
            btnEdifactElement.Text = "Convert >>";
            btnEdifactElement.UseVisualStyleBackColor = true;
            btnEdifactElement.Click += btnEdifactElement_Click;
            // 
            // btnEdifactSegment
            // 
            btnEdifactSegment.Location = new Point(433, 88);
            btnEdifactSegment.Margin = new Padding(3, 4, 3, 4);
            btnEdifactSegment.Name = "btnEdifactSegment";
            btnEdifactSegment.Size = new Size(109, 31);
            btnEdifactSegment.TabIndex = 8;
            btnEdifactSegment.Text = "Convert >>";
            btnEdifactSegment.UseVisualStyleBackColor = true;
            btnEdifactSegment.Click += btnEdifactSegment_Click;
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
            // btnx12Segment
            // 
            btnx12Segment.Location = new Point(433, 127);
            btnx12Segment.Margin = new Padding(3, 4, 3, 4);
            btnx12Segment.Name = "btnx12Segment";
            btnx12Segment.Size = new Size(109, 31);
            btnx12Segment.TabIndex = 10;
            btnx12Segment.Text = "Convert >>";
            btnx12Segment.UseVisualStyleBackColor = true;
            btnx12Segment.Click += btnx12Segment_Click;
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
            // btnx12BatchConvert
            // 
            btnx12BatchConvert.Location = new Point(70, 200);
            btnx12BatchConvert.Margin = new Padding(3, 4, 3, 4);
            btnx12BatchConvert.Name = "btnx12BatchConvert";
            btnx12BatchConvert.Size = new Size(357, 31);
            btnx12BatchConvert.TabIndex = 12;
            btnx12BatchConvert.Text = "Generate Next Batch of EDI x12 Segments";
            btnx12BatchConvert.UseVisualStyleBackColor = true;
            btnx12BatchConvert.Click += btnx12BatchConvert_Click;
            // 
            // btnx12Element
            // 
            btnx12Element.Location = new Point(433, 165);
            btnx12Element.Margin = new Padding(3, 4, 3, 4);
            btnx12Element.Name = "btnx12Element";
            btnx12Element.Size = new Size(109, 31);
            btnx12Element.TabIndex = 14;
            btnx12Element.Text = "Convert >>";
            btnx12Element.UseVisualStyleBackColor = true;
            btnx12Element.Click += button5_Click;
            // 
            // txtx12Element
            // 
            txtx12Element.Location = new Point(14, 167);
            txtx12Element.Margin = new Padding(3, 4, 3, 4);
            txtx12Element.Name = "txtx12Element";
            txtx12Element.Size = new Size(412, 27);
            txtx12Element.TabIndex = 13;
            txtx12Element.Text = "https://www.stedi.com/edi/x12-008020/element/C030";
            // 
            // txtBatchCount
            // 
            txtBatchCount.Location = new Point(14, 205);
            txtBatchCount.Margin = new Padding(3, 4, 3, 4);
            txtBatchCount.Name = "txtBatchCount";
            txtBatchCount.Size = new Size(49, 27);
            txtBatchCount.TabIndex = 15;
            txtBatchCount.Text = "10";
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtLog.Location = new Point(14, 244);
            txtLog.Margin = new Padding(3, 4, 3, 4);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(527, 356);
            txtLog.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 617);
            Controls.Add(txtLog);
            Controls.Add(txtBatchCount);
            Controls.Add(btnx12Element);
            Controls.Add(txtx12Element);
            Controls.Add(btnx12BatchConvert);
            Controls.Add(txtTest);
            Controls.Add(btnx12Segment);
            Controls.Add(txtX12);
            Controls.Add(btnEdifactSegment);
            Controls.Add(txtEdifactSegment);
            Controls.Add(btnEdifactElement);
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
        private Button btnEdifactElement;
        private Button btnEdifactSegment;
        private TextBox txtEdifactSegment;
        private Button btnx12Segment;
        private TextBox txtX12;
        private TextBox txtTest;
        private Button btnx12BatchConvert;
        private Button btnx12Element;
        private TextBox txtx12Element;
        private TextBox txtBatchCount;
        private TextBox txtLog;
    }
}