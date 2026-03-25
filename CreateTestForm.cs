using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace App_For_Tests
{
    public partial class CreateTestForm : Form
    {
        List<Question> test = new List<Question>(); // список всех вопросов
        int count = 1, current = 0; // количество вопросов и индекс текущего
        bool save = false; // показывает сохранен последний вопрос или нет

        public CreateTestForm()
        {
            InitializeComponent();

            saveFileDialog.Filter = "XML file(*.xml)|*.xml";
        }
        private void CreateTestForm_Load(object sender, EventArgs e)
        {
            // блокировка кнопок <- ->
            Previous.Enabled = false; 
            Next.Enabled = false;
            QuestionNumberValueLabel.Text = "1"; // первый вопрос
        }

        #region Кнопки передвижения
        private void Show_Elements(Question question)
        {            
            var rightAnswer = question.GetRightAnswer();

            List<string> answers = question.GetAnswers();
            List<string> extra = question.GetExtra();

            AnswerPanel.Controls.Clear(); // очистка панели с ответами

            int label = 23, txt = 20;
            string  alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // для вопросов на сопаставление

            int iterator = answers.Count;
            for (int i = 0; i < iterator; i++)
            {
                if (question.Type != "Insert" && question.Type != "Sentence")
                {
                    // номер ответа
                    Label n = new Label();
                    n.Text = (i + 1).ToString() + ".";
                    n.Location = new Point(16, label);
                    n.Size = new Size(20, 20);
                    AnswerPanel.Controls.Add(n);
                }

                // текст ответа
                TextBox t = new TextBox();
                switch (question.Type)
                {
                    // один верный ответ
                    case "Single":
                        int right = (int)rightAnswer;

                        RadioButton r = new RadioButton();
                        r.Text = "";
                        r.Location = new Point(40, label);
                        r.Size = new Size(15, 15);
                        r.Name = $"{i + 1}";
                        if(i+1 == right)
                            r.Checked = true;
                        AnswerPanel.Controls.Add(r);

                        t.Location = new Point(60, txt);
                        t.Width = 800;
                        t.Name = "first";
                        t.Text = answers[i];
                        AnswerPanel.Controls.Add(t);

                        break;

                    // несколько верных
                    case "Multi":
                        List<int> rights = (List<int>)rightAnswer;

                        CheckBox c = new CheckBox();
                        c.Text = "";
                        c.Location = new Point(40, label);
                        c.Size = new Size(15, 15);
                        c.Name = $"{i + 1}";
                        if(rights.Contains(i + 1))
                            c.Checked = true;
                        AnswerPanel.Controls.Add(c);

                        t.Location = new Point(60, txt);
                        t.Width = 800;
                        t.Name = "first";
                        t.Text = answers[i];
                        AnswerPanel.Controls.Add(t);

                        break;

                    // ответ в виде словосочетания
                    case "Sentence":
                        t.Location = new Point(60, txt);
                        t.Width = 800;
                        t.Name = "first";
                        t.Text = answers[i];
                        AnswerPanel.Controls.Add(t);
                        break;

                    // сопаставление
                    case "Compare":
                        string rightCombination = (string)rightAnswer;

                        t.Location = new Point(60, txt);
                        t.Width = 350;
                        t.Name = $"first";
                        t.Text = answers[i];
                        AnswerPanel.Controls.Add(t);

                        Label simbols = new Label();
                        simbols.Text = alphabet[i].ToString();
                        simbols.Location = new Point(476, label);
                        simbols.Size = new Size(20, 20);
                        AnswerPanel.Controls.Add(simbols);

                        ComboBox comboBox = new ComboBox();
                        comboBox.Location = new Point(500, txt);
                        comboBox.Width = 40;
                        comboBox.Name = alphabet[i].ToString();
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                        for (int j = 1; j <= iterator; j++)
                            comboBox.Items.Add(j.ToString());

                        comboBox.SelectedItem = (rightCombination.IndexOf(alphabet[i]) + 1).ToString();

                        AnswerPanel.Controls.Add(comboBox);

                        TextBox snd = new TextBox();
                        snd.Location = new Point(550, txt);
                        snd.Width = 350;
                        snd.Name = $"second";
                        snd.Text = extra[i];
                        AnswerPanel.Controls.Add(snd);

                        break;

                    // вставка пропусков
                    case "Insert":
                        string mainText = (string)question.GetRightAnswer();
                        string[] text = mainText.Split(new[] { ":^(space)^:" }, StringSplitOptions.None);
                        List<string> insertAnswers = question.GetAnswers();

                        int it1 = 0, it2 = 0;

                        Label labelShow;
                        TextBox textShow;
                        int txtShowPosition = 25;
                        while (true)
                        {
                            if(it1 != text.Length)
                            {
                                labelShow = new Label();
                                labelShow.Location = new Point(15, txtShowPosition);
                                labelShow.Text = "Текст";
                                labelShow.Width = 40;
                                AnswerPanel.Controls.Add(labelShow);

                                textShow = new TextBox();
                                textShow.Location = new Point(60, txtShowPosition);
                                textShow.Multiline = true;
                                textShow.Width = 800;
                                textShow.Name = "Text";
                                textShow.Text = text[it1];
                                textShow.Height = 50;
                                textShow.ScrollBars = ScrollBars.Vertical;

                                txtShowPosition += 60;
                                AnswerPanel.Controls.Add(textShow);
                                it1++;
                            }
                            
                            if(it2 != insertAnswers.Count)
                            {
                                labelShow = new Label();
                                labelShow.Location = new Point(15, txtShowPosition);
                                labelShow.Text = "Слово";
                                labelShow.Width = 40;
                                AnswerPanel.Controls.Add(labelShow);

                                textShow = new TextBox();
                                textShow.Location = new Point(60, txtShowPosition);
                                textShow.Width = 250;
                                textShow.Name = "Answer";
                                textShow.Text = insertAnswers[it2];

                                txtShowPosition += 30;
                                AnswerPanel.Controls.Add(textShow);
                                it2++;
                            }

                            if (it1 == text.Length && it2 == insertAnswers.Count)
                                break;
                        }
                        break;

                    default:
                        return;
                }
                label += 48;
                txt += 48;
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if(save==false && current == count - 1)
            {
                count--;
                current = count - 1;
                Next.Enabled = false;
                save = true;
            }
            else
            {
                current--;
            }

            if (current < test.Count - 1 && save==true) // активация ->
            {
                Next.Enabled = true;
            }
            Question currentQuestion = test[current]; // выбор предыдущего вопроса

            // заполнение полей ввода
            QuestionNumberValueLabel.Text = (currentQuestion.Number).ToString();
            TypeOfQuestions.Text = currentQuestion.Type;
            CountOfAnswers.Value = currentQuestion.Count;
            QuestionTextBox.Text = currentQuestion.Wording;

            Show_Elements(currentQuestion); // прорисовка полей ответов
        }

        private void Next_Click(object sender, EventArgs e)
        {
            current++;
            if (current > 0) // активация <-
            {
                Previous.Enabled = true;
            }
            Question currentQuestion = test[current]; // выбор следующего вопроса

            // заполнение полей ввода
            QuestionNumberValueLabel.Text = (test[current].Number).ToString();
            TypeOfQuestions.Text = currentQuestion.Type;
            CountOfAnswers.Value = currentQuestion.Count;
            QuestionTextBox.Text = currentQuestion.Wording;

            Show_Elements(currentQuestion); // прорисовка полей ответов

            // блокировка ->
            if (current == test.Count - 1 || (current == count - 1 && save == false))
            {
                Next.Enabled = false;
            }
        }
        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var all = AnswerPanel.Controls;
            // проверка полей ввода на пустоту
            foreach (var i in all)
            {
                if (i.GetType() == typeof(TextBox))
                {
                    TextBox n = (TextBox)i;
                    if (n.Text == string.Empty)
                    {
                        Warning warning = new Warning();
                        warning.ShowDialog();
                        return;
                    }
                }
                else if (i.GetType() == typeof(ComboBox))
                {
                    ComboBox n = (ComboBox)i;
                    if(n.Text == string.Empty)
                    {
                        Warning warning = new Warning();
                        warning.ShowDialog();
                        return;
                    }
                }
            }

            // проверка полей ввода на пустоту
            if ((CountOfAnswers.Value == 0 && TypeOfQuestions.Text != "Insert" && TypeOfQuestions.Text != "Sentence") || TypeOfQuestions.Text == string.Empty || QuestionTextBox.Text == string.Empty)
            {
                Warning warning = new Warning();
                warning.ShowDialog();
                return;
            }

            Question currentQuestion = null;

            string key = TypeOfQuestions.Text;
            List<string> list = new List<string>();
            switch (key) // создание вопроса нужного типа
            {
                case "Single": 
                    int right = 0;
                    foreach (var i in all)
                    {
                        if (i.GetType() == typeof(TextBox))
                        {
                            TextBox n = (TextBox)i;
                            if (n.Name == "first")
                                list.Add(n.Text);
                        }

                        if (i.GetType() == typeof(RadioButton))
                        {
                            RadioButton r = (RadioButton)i;
                            if (r.Checked)
                            {
                                right = int.Parse(r.Name);
                            }
                        }
                    }
                    if (current + 1 < count)
                        test[current] = new SingleAnswer(test[current].Number, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, right);
                    else currentQuestion = new SingleAnswer(count, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, right);
                    break;

                case "Multi":
                    List<int> rightAnswers = new List<int>();
                    foreach (var i in all)
                    {
                        if (i.GetType() == typeof(TextBox))
                        {
                            TextBox n = (TextBox)i;
                            if (n.Name == "first")
                                list.Add(n.Text);
                        }

                        if (i.GetType() == typeof(CheckBox))
                        {
                            CheckBox c = (CheckBox)i;
                            if (c.Checked)
                            {
                                rightAnswers.Add(int.Parse(c.Name));
                            }
                        }
                    }
                    if (current + 1 < count)
                        test[current] = new MultiAnswer(test[current].Number, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, rightAnswers);
                    else currentQuestion = new MultiAnswer(count, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, rightAnswers);
                    break;

                case "Sentence":
                    string answer = "";
                    foreach(var i in all)
                    {
                        if (i.GetType() == typeof(TextBox))
                        {
                            TextBox n = (TextBox)i;
                            if (n.Name == "first")
                                answer = n.Text.ToLower();
                        }
                    }
                    if (current + 1 < count)
                        test[current] = new SentenceAnswer(test[current].Number, QuestionTextBox.Text, answer);
                    else currentQuestion = new SentenceAnswer(count, QuestionTextBox.Text, answer);
                    break;

                case "Compare":
                    string rightCombination = "", alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    List<string> extraList = new List<string>();
                    foreach (var i in all)
                    {
                        if (i.GetType() == typeof(TextBox))
                        {
                            TextBox n = (TextBox)i;
                            if (n.Name == "first")
                                list.Add(n.Text);
                            else if(n.Name == "second")
                                extraList.Add(n.Text);
                        }

                        if (i.GetType() == typeof(ComboBox))
                        {
                            ComboBox c = (ComboBox)i;
                            rightCombination += alphabet[int.Parse(c.Text) - 1];
                        }
                    }

                    if (current + 1 < count)
                        test[current] = new CompareAnswer(test[current].Number, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, extraList, rightCombination);
                    else currentQuestion = new CompareAnswer(count, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, extraList, rightCombination);
                    break;

                case "Insert":
                    string mainText = "";
                    foreach(var i in all)
                    {
                        if (i.GetType() == typeof(TextBox))
                        {
                            TextBox n = (TextBox)i;
                            if (n.Name == "Answer")
                            {
                                list.Add(n.Text);
                                mainText += ":^(space)^:";
                            }

                            else if (n.Name == "Text")
                                mainText += $"{n.Text}";
                        }
                    }
                    if (current + 1 < count)
                        test[current] = new InsertAnswer(test[current].Number, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, mainText);
                    else currentQuestion = new InsertAnswer(count, Convert.ToInt32(CountOfAnswers.Value), QuestionTextBox.Text, list, mainText);
                    break;

                default: return;
            }
            if (current + 1 < count)
            {
                save = true;
                return;
            }
            test.Add(currentQuestion);
            save = true;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            AnswerPanel.Controls.Clear(); // очистка панели с ответами

            int label = 23, txt = 20;
            string key = TypeOfQuestions.Text, alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // для вопросов на сопаставление
            if (key != string.Empty)
            {
                int iterator = Convert.ToInt32(CountOfAnswers.Value);
                for (int i = 0; i < iterator; i++)
                {
                    // номер ответа
                    Label n = new Label();
                    n.Text = (i + 1).ToString() + ".";
                    n.Location = new Point(16, label);
                    n.Size = new Size(20, 20);
                    AnswerPanel.Controls.Add(n);

                    // текст ответа
                    TextBox t = new TextBox();
                    switch (key)
                    {
                        // один верный ответ
                        case "Single":
                            RadioButton r = new RadioButton();
                            r.Text = "";
                            r.Location = new Point(40, label);
                            r.Size = new Size(15, 15);
                            r.Name = $"{i + 1}";
                            AnswerPanel.Controls.Add(r);

                            t.Location = new Point(60, txt);
                            t.Width = 800;
                            t.Name = "first";
                            AnswerPanel.Controls.Add(t);

                            break;

                        // несколько верных
                        case "Multi":
                            CheckBox c = new CheckBox();
                            c.Text = "";
                            c.Location = new Point(40, label);
                            c.Size = new Size(15, 15);
                            c.Name = $"{i + 1}";
                            AnswerPanel.Controls.Add(c);

                            t.Location = new Point(60, txt);
                            t.Width = 800;
                            t.Name = "first";
                            AnswerPanel.Controls.Add(t);

                            break;

                        // ответ в виде словосочетания
                        case "Sentence":
                            // реализуется в TypeOfQuestions
                            break;

                        // сопаставление
                        case "Compare":
                            t.Location = new Point(60, txt);
                            t.Width = 350;
                            t.Name = $"first";
                            AnswerPanel.Controls.Add(t);

                            Label simbols = new Label();
                            simbols.Text = alphabet[i].ToString();
                            simbols.Location = new Point(476, label);
                            simbols.Size = new Size(20, 20);
                            AnswerPanel.Controls.Add(simbols);

                            ComboBox comboBox = new ComboBox();
                            comboBox.Location = new Point(500, txt);
                            comboBox.Width = 40;
                            comboBox.Name = alphabet[i].ToString();
                            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                            
                            for(int j=1;j <= iterator;j++)
                                comboBox.Items.Add(j.ToString());

                            AnswerPanel.Controls.Add(comboBox);

                            TextBox snd = new TextBox();
                            snd.Location = new Point(550, txt);
                            snd.Width = 350;
                            snd.Name = $"second";
                            AnswerPanel.Controls.Add(snd);

                            break;

                        // вставка пропусков
                        case "Insert":
                            // реализуется с помощью кнопок AddText и AddAnswer
                            break;

                        default:
                            return;
                    }

                    label += 48;
                    txt += 48;
                }
            }
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            if (save)
            {
                SpecificationsForm form = new SpecificationsForm();
                form.ShowDialog();
                string path; // для пути сохранения теста
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {         
                    path = saveFileDialog.FileName;          

                    File.WriteAllText(path, "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<Test></Test>");

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(path);

                    XmlElement root = xdoc.DocumentElement;

                    if (root != null)
                    {
                        XmlNode specs = xdoc.CreateElement("Specifications");
                        XmlNode five = xdoc.CreateElement("Five");
                        XmlNode four = xdoc.CreateElement("Four");
                        XmlNode three = xdoc.CreateElement("Three");


                        five.InnerText = form.Five;
                        four.InnerText = form.Four;
                        three.InnerText = form.Three;

                        specs.AppendChild(five);
                        specs.AppendChild(four);
                        specs.AppendChild(three);
                        root.AppendChild(specs);

                        foreach(var qws in test)
                        {
                            qws.WriteToXml(ref xdoc);
                        }

                        xdoc.Save(path);
                        MessageBox.Show($"Тест сохранен в {path}");
                        this.Close();
                    }
                    else
                        MessageBox.Show($"Что-то пошло не так :^(\nПопробуйте еще раз.");
                }
                else
                    MessageBox.Show($"Что-то пошло не так :^(\nПопробуйте еще раз.");
            }
            else
                MessageBox.Show($"Нажмите \"Сохранить\"");
        }

        private void TypeOfQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnswerPanel.Controls.Clear();
            txtPosition = 25;
            if (TypeOfQuestions.Text == "Insert")
            {
                AddText.Enabled = true;
                AddAnswer.Enabled = true;
                EditInsertQuestion.Visible = true;
                CountOfAnswers.Enabled = false;
                Apply.Enabled = false;

                EditQuestion.Visible = false;
                AddText_Click(sender, e);
            }
            else if (TypeOfQuestions.Text == "Sentence")
            {
                CountOfAnswers.Enabled = false;
                Apply.Enabled = false;
                EditQuestion.Visible = false;
                EditInsertQuestion.Visible = false;

                TextBox t = new TextBox();
                t.Location = new Point(60, 20);
                t.Width = 800;
                t.Name = "first";
                AnswerPanel.Controls.Add(t);

            }
            else
            {
                AddText.Enabled = false;
                AddAnswer.Enabled = false;
                EditInsertQuestion.Visible = false;
                CountOfAnswers.Enabled = true;
                Apply.Enabled = true;
                EditQuestion.Visible = true;
            }
        }

        #region Кнопки для вопросов типа Insert
        int txtPosition = 25;
        private void AddText_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Location = new Point(15, txtPosition + 20);
            label.Text = "Текст";
            label.Width = 40;
            AnswerPanel.Controls.Add(label);

            TextBox text = new TextBox();
            text.Location = new Point(60, txtPosition);
            text.Multiline = true;
            text.Width = 800;
            text.Name = "Text";
            text.Height = 50;
            text.ScrollBars = ScrollBars.Vertical;

            txtPosition += 60;

            AnswerPanel.Controls.Add(text);
        }

        private void AddAnswer_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Location = new Point(15, txtPosition);
            label.Text = "Слово";
            label.Width = 40;
            AnswerPanel.Controls.Add(label);

            TextBox text = new TextBox();
            text.Location = new Point(60, txtPosition);
            text.Width = 250;
            text.Name = "Answer";

            txtPosition += 30;

            AnswerPanel.Controls.Add(text);
        }
        #endregion

        private void CreateNewQuestion_Click(object sender, EventArgs e)
        {
            if (save)
            {
                count++;

                txtPosition = 25;

                current = count - 1;
                QuestionNumberValueLabel.Text = (count).ToString();
                QuestionTextBox.Text = "";
                TypeOfQuestions.Text = "";
                Next.Enabled = false;
                Previous.Enabled = true;

                AnswerPanel.Controls.Clear();
                save = false;
            }
            else MessageBox.Show($"Нажмите \"Сохранить\"");
        }
    }
}
