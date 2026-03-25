namespace App_For_Tests
{
    partial class CreateTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTestForm));
            this.QuestionTextBox = new System.Windows.Forms.TextBox();
            this.Question = new System.Windows.Forms.Label();
            this.AnswerPanel = new System.Windows.Forms.Panel();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.EditQuestion = new System.Windows.Forms.Label();
            this.EditInsertQuestion = new System.Windows.Forms.Label();
            this.AddAnswer = new System.Windows.Forms.Button();
            this.AddText = new System.Windows.Forms.Button();
            this.QuestionNumberValueLabel = new System.Windows.Forms.Label();
            this.QuestionNumberLabel = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.CountOfAnswers = new System.Windows.Forms.NumericUpDown();
            this.AnswerCount = new System.Windows.Forms.Label();
            this.CreateNewQuestion = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeOfQuestions = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ToolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountOfAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionTextBox.Location = new System.Drawing.Point(12, 162);
            this.QuestionTextBox.Multiline = true;
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QuestionTextBox.Size = new System.Drawing.Size(960, 91);
            this.QuestionTextBox.TabIndex = 1;
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Question.Location = new System.Drawing.Point(12, 135);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(94, 24);
            this.Question.TabIndex = 2;
            this.Question.Text = "Вопрос:";
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.AutoScroll = true;
            this.AnswerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnswerPanel.Location = new System.Drawing.Point(12, 263);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(960, 286);
            this.AnswerPanel.TabIndex = 1;
            // 
            // ToolPanel
            // 
            this.ToolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolPanel.Controls.Add(this.EditQuestion);
            this.ToolPanel.Controls.Add(this.EditInsertQuestion);
            this.ToolPanel.Controls.Add(this.AddAnswer);
            this.ToolPanel.Controls.Add(this.AddText);
            this.ToolPanel.Controls.Add(this.QuestionNumberValueLabel);
            this.ToolPanel.Controls.Add(this.QuestionNumberLabel);
            this.ToolPanel.Controls.Add(this.EndButton);
            this.ToolPanel.Controls.Add(this.Apply);
            this.ToolPanel.Controls.Add(this.CountOfAnswers);
            this.ToolPanel.Controls.Add(this.AnswerCount);
            this.ToolPanel.Controls.Add(this.CreateNewQuestion);
            this.ToolPanel.Controls.Add(this.Next);
            this.ToolPanel.Controls.Add(this.Previous);
            this.ToolPanel.Controls.Add(this.SaveButton);
            this.ToolPanel.Controls.Add(this.TypeLabel);
            this.ToolPanel.Controls.Add(this.TypeOfQuestions);
            this.ToolPanel.Location = new System.Drawing.Point(12, 12);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(960, 120);
            this.ToolPanel.TabIndex = 0;
            // 
            // EditQuestion
            // 
            this.EditQuestion.AutoSize = true;
            this.EditQuestion.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditQuestion.Location = new System.Drawing.Point(71, 83);
            this.EditQuestion.Name = "EditQuestion";
            this.EditQuestion.Size = new System.Drawing.Size(378, 15);
            this.EditQuestion.TabIndex = 15;
            this.EditQuestion.Text = "Установитье количество ответов и нажмите \"Применить\".";
            this.EditQuestion.Visible = false;
            // 
            // EditInsertQuestion
            // 
            this.EditInsertQuestion.AutoSize = true;
            this.EditInsertQuestion.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditInsertQuestion.Location = new System.Drawing.Point(535, 78);
            this.EditInsertQuestion.Name = "EditInsertQuestion";
            this.EditInsertQuestion.Size = new System.Drawing.Size(168, 30);
            this.EditInsertQuestion.TabIndex = 14;
            this.EditInsertQuestion.Text = "Используйте кнопки для\r\nредактирования вопроса.";
            this.EditInsertQuestion.Visible = false;
            // 
            // AddAnswer
            // 
            this.AddAnswer.Enabled = false;
            this.AddAnswer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAnswer.Location = new System.Drawing.Point(624, 43);
            this.AddAnswer.Name = "AddAnswer";
            this.AddAnswer.Size = new System.Drawing.Size(128, 32);
            this.AddAnswer.TabIndex = 13;
            this.AddAnswer.Text = "Добавить ответ";
            this.AddAnswer.UseVisualStyleBackColor = true;
            this.AddAnswer.Click += new System.EventHandler(this.AddAnswer_Click);
            // 
            // AddText
            // 
            this.AddText.Enabled = false;
            this.AddText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddText.Location = new System.Drawing.Point(490, 43);
            this.AddText.Name = "AddText";
            this.AddText.Size = new System.Drawing.Size(128, 32);
            this.AddText.TabIndex = 12;
            this.AddText.Text = "Добавить текст";
            this.AddText.UseVisualStyleBackColor = true;
            this.AddText.Click += new System.EventHandler(this.AddText_Click);
            // 
            // QuestionNumberValueLabel
            // 
            this.QuestionNumberValueLabel.AutoSize = true;
            this.QuestionNumberValueLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionNumberValueLabel.Location = new System.Drawing.Point(660, 10);
            this.QuestionNumberValueLabel.Name = "QuestionNumberValueLabel";
            this.QuestionNumberValueLabel.Size = new System.Drawing.Size(20, 22);
            this.QuestionNumberValueLabel.TabIndex = 11;
            this.QuestionNumberValueLabel.Text = "1";
            // 
            // QuestionNumberLabel
            // 
            this.QuestionNumberLabel.AutoSize = true;
            this.QuestionNumberLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionNumberLabel.Location = new System.Drawing.Point(514, 10);
            this.QuestionNumberLabel.Name = "QuestionNumberLabel";
            this.QuestionNumberLabel.Size = new System.Drawing.Size(140, 22);
            this.QuestionNumberLabel.TabIndex = 10;
            this.QuestionNumberLabel.Text = "Вопрос номер:";
            // 
            // EndButton
            // 
            this.EndButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndButton.Location = new System.Drawing.Point(782, 5);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(173, 32);
            this.EndButton.TabIndex = 9;
            this.EndButton.Text = "Завершить";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // Apply
            // 
            this.Apply.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Apply.Location = new System.Drawing.Point(356, 53);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(93, 22);
            this.Apply.TabIndex = 8;
            this.Apply.Text = "Применить";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // CountOfAnswers
            // 
            this.CountOfAnswers.Location = new System.Drawing.Point(316, 53);
            this.CountOfAnswers.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.CountOfAnswers.Name = "CountOfAnswers";
            this.CountOfAnswers.Size = new System.Drawing.Size(34, 20);
            this.CountOfAnswers.TabIndex = 7;
            // 
            // AnswerCount
            // 
            this.AnswerCount.AutoSize = true;
            this.AnswerCount.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerCount.Location = new System.Drawing.Point(10, 51);
            this.AnswerCount.Name = "AnswerCount";
            this.AnswerCount.Size = new System.Drawing.Size(300, 22);
            this.AnswerCount.TabIndex = 6;
            this.AnswerCount.Text = "Количество вариантов ответов:";
            // 
            // CreateNewQuestion
            // 
            this.CreateNewQuestion.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateNewQuestion.Location = new System.Drawing.Point(782, 43);
            this.CreateNewQuestion.Name = "CreateNewQuestion";
            this.CreateNewQuestion.Size = new System.Drawing.Size(173, 34);
            this.CreateNewQuestion.TabIndex = 5;
            this.CreateNewQuestion.Text = "Добавить новый";
            this.CreateNewQuestion.UseVisualStyleBackColor = true;
            this.CreateNewQuestion.Click += new System.EventHandler(this.CreateNewQuestion_Click);
            // 
            // Next
            // 
            this.Next.BackgroundImage = global::App_For_Tests.Properties.Resources.RightArrow;
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Next.Location = new System.Drawing.Point(820, 83);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(32, 32);
            this.Next.TabIndex = 4;
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Previous
            // 
            this.Previous.BackgroundImage = global::App_For_Tests.Properties.Resources.LeftArrow;
            this.Previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Previous.Location = new System.Drawing.Point(782, 83);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(32, 32);
            this.Previous.TabIndex = 3;
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(858, 83);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(97, 32);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLabel.Location = new System.Drawing.Point(10, 10);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(130, 22);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Тип вопроса:";
            // 
            // TypeOfQuestions
            // 
            this.TypeOfQuestions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfQuestions.FormattingEnabled = true;
            this.TypeOfQuestions.Items.AddRange(new object[] {
            "Single",
            "Multi",
            "Sentence",
            "Compare",
            "Insert"});
            this.TypeOfQuestions.Location = new System.Drawing.Point(146, 13);
            this.TypeOfQuestions.Name = "TypeOfQuestions";
            this.TypeOfQuestions.Size = new System.Drawing.Size(179, 21);
            this.TypeOfQuestions.TabIndex = 0;
            this.TypeOfQuestions.SelectedIndexChanged += new System.EventHandler(this.TypeOfQuestions_SelectedIndexChanged);
            // 
            // CreateTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.AnswerPanel);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.QuestionTextBox);
            this.Controls.Add(this.ToolPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateTestForm";
            this.Load += new System.EventHandler(this.CreateTestForm_Load);
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountOfAnswers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox QuestionTextBox;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Panel AnswerPanel;
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox TypeOfQuestions;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label AnswerCount;
        private System.Windows.Forms.Button CreateNewQuestion;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.NumericUpDown CountOfAnswers;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Label QuestionNumberValueLabel;
        private System.Windows.Forms.Label QuestionNumberLabel;
        private System.Windows.Forms.Button AddAnswer;
        private System.Windows.Forms.Button AddText;
        private System.Windows.Forms.Label EditInsertQuestion;
        private System.Windows.Forms.Label EditQuestion;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}