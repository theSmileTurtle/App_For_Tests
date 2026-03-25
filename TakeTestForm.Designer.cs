namespace App_For_Tests
{
    partial class TakeTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeTestForm));
            this.Question = new System.Windows.Forms.Label();
            this.QuestionTextBox = new System.Windows.Forms.TextBox();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TestProgress = new System.Windows.Forms.ProgressBar();
            this.QuestionNumberValueLabel = new System.Windows.Forms.Label();
            this.QuestionNumberLabel = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.AnswerPanel = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ToolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Question.Location = new System.Drawing.Point(12, 147);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(94, 24);
            this.Question.TabIndex = 4;
            this.Question.Text = "Вопрос:";
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionTextBox.Enabled = false;
            this.QuestionTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionTextBox.Location = new System.Drawing.Point(12, 174);
            this.QuestionTextBox.Multiline = true;
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.Size = new System.Drawing.Size(960, 91);
            this.QuestionTextBox.TabIndex = 0;
            // 
            // ToolPanel
            // 
            this.ToolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolPanel.Controls.Add(this.SaveButton);
            this.ToolPanel.Controls.Add(this.TestProgress);
            this.ToolPanel.Controls.Add(this.QuestionNumberValueLabel);
            this.ToolPanel.Controls.Add(this.QuestionNumberLabel);
            this.ToolPanel.Controls.Add(this.EndButton);
            this.ToolPanel.Controls.Add(this.Next);
            this.ToolPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(960, 120);
            this.ToolPanel.TabIndex = 5;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(73, 84);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(128, 32);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Сохранить ответ";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TestProgress
            // 
            this.TestProgress.Location = new System.Drawing.Point(3, 45);
            this.TestProgress.Name = "TestProgress";
            this.TestProgress.Size = new System.Drawing.Size(952, 32);
            this.TestProgress.TabIndex = 12;
            // 
            // QuestionNumberValueLabel
            // 
            this.QuestionNumberValueLabel.AutoSize = true;
            this.QuestionNumberValueLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionNumberValueLabel.Location = new System.Drawing.Point(149, 5);
            this.QuestionNumberValueLabel.Name = "QuestionNumberValueLabel";
            this.QuestionNumberValueLabel.Size = new System.Drawing.Size(20, 22);
            this.QuestionNumberValueLabel.TabIndex = 11;
            this.QuestionNumberValueLabel.Text = "1";
            // 
            // QuestionNumberLabel
            // 
            this.QuestionNumberLabel.AutoSize = true;
            this.QuestionNumberLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionNumberLabel.Location = new System.Drawing.Point(3, 5);
            this.QuestionNumberLabel.Name = "QuestionNumberLabel";
            this.QuestionNumberLabel.Size = new System.Drawing.Size(140, 22);
            this.QuestionNumberLabel.TabIndex = 10;
            this.QuestionNumberLabel.Text = "Вопрос номер:";
            // 
            // EndButton
            // 
            this.EndButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndButton.Location = new System.Drawing.Point(782, 83);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(173, 32);
            this.EndButton.TabIndex = 9;
            this.EndButton.Text = "Завершить тестирование";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // Next
            // 
            this.Next.BackgroundImage = global::App_For_Tests.Properties.Resources.RightArrow;
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Next.Location = new System.Drawing.Point(3, 83);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(64, 32);
            this.Next.TabIndex = 4;
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.AutoScroll = true;
            this.AnswerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnswerPanel.Location = new System.Drawing.Point(12, 271);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(960, 283);
            this.AnswerPanel.TabIndex = 6;
            // 
            // TakeTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.AnswerPanel);
            this.Controls.Add(this.ToolPanel);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.QuestionTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TakeTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakeTestForm";
            this.Load += new System.EventHandler(this.TakeTestForm_Load);
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.TextBox QuestionTextBox;
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.Label QuestionNumberValueLabel;
        private System.Windows.Forms.Label QuestionNumberLabel;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.ProgressBar TestProgress;
        private System.Windows.Forms.Panel AnswerPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button SaveButton;
    }
}