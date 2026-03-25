using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace App_For_Tests
{
    public partial class TakeTestForm : Form
    {
        List<Question> test = new List<Question>();
        List<EndAnswer> forCheck = new List<EndAnswer>();

        int five, four, three;
        int countOfTaked;

        bool save = false;
        int current = 0;

        public TakeTestForm()
        {
            InitializeComponent();

            openFileDialog.Filter = "XML file|*.xml";
        }

        private void TakeTestForm_Load(object sender, EventArgs e)
        {
            string path;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                #region Заполнение списка вопросов
                path = openFileDialog.FileName;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                XmlElement root = xDoc.DocumentElement;

                Question question = null;

                int number = 0, count = 0;
                string wording = "";
                foreach (XmlNode node in root.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Specifications":
                            foreach (XmlNode spec in node.ChildNodes)
                            {
                                if (spec.Name == "Five")
                                    five = int.Parse(spec.InnerText);
                                else if (spec.Name == "Four")
                                    four = int.Parse(spec.InnerText);
                                else three = int.Parse(spec.InnerText);
                            }
                            break;

                        case "Single":
                            List<string> answers = new List<string>();
                            int rightAnswer = 0;
                            foreach (XmlNode single in node.ChildNodes)
                            {
                                switch (single.Name)
                                {
                                    case "Number":
                                        number = int.Parse(single.InnerText);
                                        break;
                                    case "Count":
                                        count = int.Parse(single.InnerText);
                                        break;
                                    case "Wording":
                                        wording = single.InnerText;
                                        break;
                                    case "Answers":
                                        foreach (XmlNode answ in single.ChildNodes)
                                            answers.Add(answ.InnerText);
                                        break;
                                    case "RightAnswer":
                                        rightAnswer = int.Parse(single.InnerText);
                                        break;
                                    default: break;
                                }
                            }
                            question = new SingleAnswer(number, count, wording, answers, rightAnswer);
                            test.Add(question);
                            break;

                        case "Multi":
                            List<string> answersMulti = new List<string>();
                            List<int> rightAnswers = new List<int>();
                            foreach (XmlNode multi in node.ChildNodes)
                            {
                                switch (multi.Name)
                                {
                                    case "Number":
                                        number = int.Parse(multi.InnerText);
                                        break;
                                    case "Count":
                                        count = int.Parse(multi.InnerText);
                                        break;
                                    case "Wording":
                                        wording = multi.InnerText;
                                        break;
                                    case "Answers":
                                        foreach (XmlNode answ in multi.ChildNodes)
                                            answersMulti.Add(answ.InnerText);
                                        break;
                                    case "RightAnswers":
                                        foreach (XmlNode answ in multi.ChildNodes)
                                            rightAnswers.Add(int.Parse(answ.InnerText));
                                        break;
                                    default: break;
                                }
                            }
                            question = new MultiAnswer(number, count, wording, answersMulti, rightAnswers);
                            test.Add(question);
                            break;

                        case "Sentence":
                            string rightAnswerSent = "";
                            foreach (XmlNode sent in node.ChildNodes)
                            {
                                switch (sent.Name)
                                {
                                    case "Number":
                                        number = int.Parse(sent.InnerText);
                                        break;
                                    case "Wording":
                                        wording = sent.InnerText;
                                        break;
                                    case "RightAnswer":
                                        rightAnswerSent = sent.InnerText;
                                        break;
                                    default: break;
                                }
                            }
                            question = new SentenceAnswer(number, wording, rightAnswerSent);
                            test.Add(question);
                            break;

                        case "Compare":
                            List<string> answersComp = new List<string>();
                            List<string> extraAnswers = new List<string>();
                            string rightCombination = "";
                            foreach (XmlNode comp in node.ChildNodes)
                            {
                                switch (comp.Name)
                                {
                                    case "Number":
                                        number = int.Parse(comp.InnerText);
                                        break;
                                    case "Count":
                                        count = int.Parse(comp.InnerText);
                                        break;
                                    case "Wording":
                                        wording = comp.InnerText;
                                        break;
                                    case "Answers":
                                        foreach (XmlNode answ in comp.ChildNodes)
                                            answersComp.Add(answ.InnerText);
                                        break;
                                    case "ExtraAnswers":
                                        foreach (XmlNode answ in comp.ChildNodes)
                                            extraAnswers.Add(answ.InnerText);
                                        break;
                                    case "RightAnswer":
                                        rightCombination = comp.InnerText;
                                        break;
                                    default: break;
                                }
                            }
                            question = new CompareAnswer(number, count, wording, answersComp, extraAnswers, rightCombination);
                            test.Add(question);
                            break;

                        case "Insert":
                            List<string> answersIns = new List<string>();
                            string mainText = "";
                            foreach (XmlNode ins in node.ChildNodes)
                            {
                                switch (ins.Name)
                                {
                                    case "Number":
                                        number = int.Parse(ins.InnerText);
                                        break;
                                    case "Count":
                                        count = int.Parse(ins.InnerText);
                                        break;
                                    case "Wording":
                                        wording = ins.InnerText;
                                        break;
                                    case "Answers":
                                        foreach (XmlNode answ in ins.ChildNodes)
                                            answersIns.Add(answ.InnerText);
                                        break;
                                    case "MainText":
                                        mainText = ins.InnerText;
                                        break;
                                    default: break;
                                }
                            }
                            question = new InsertAnswer(number, count, wording, answersIns, mainText);
                            test.Add(question);
                            break;
                        default:break;
                    }
                }
                #endregion

                // отображение первого вопроса
                Show_Elements(test[current]);

                //count = test.Count;
                TestProgress.Maximum = test.Count - 1;
            }
            else
            {
                MessageBox.Show($"Что-то пошло не так :^(\nПопробуйте еще раз.");
                this.Close();
            }
        }

        private void Show_Elements(Question question)
        {
            var rightAnswer = question.GetRightAnswer();

            List<string> answers = question.GetAnswers();
            List<string> extra = question.GetExtra();

            QuestionNumberValueLabel.Text = question.Number.ToString();
            QuestionTextBox.Text = question.Wording;

            AnswerPanel.Controls.Clear(); // очистка панели с ответами

            int label = 23, txt = 20;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // для вопросов на сопаставление
            int numPosition = 100;

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
                Label t = new Label();
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
                        AnswerPanel.Controls.Add(c);

                        t.Location = new Point(60, txt);
                        t.Width = 800;
                        t.Name = "first";
                        t.Text = answers[i];
                        AnswerPanel.Controls.Add(t);

                        break;

                    // ответ в виде словосочетания
                    case "Sentence":
                        TextBox textBox = new TextBox();

                        textBox.Location = new Point(60, txt);
                        textBox.Width = 800;
                        textBox.Name = "first";
                        AnswerPanel.Controls.Add(textBox);
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

                        AnswerPanel.Controls.Add(comboBox);

                        //TextBox snd = new TextBox();
                        Label snd = new Label();
                        snd.Location = new Point(550, txt);
                        snd.Width = 350;
                        snd.Name = $"second";
                        snd.Text = extra[i];
                        AnswerPanel.Controls.Add(snd);

                        break;

                    // вставка пропусков
                    case "Insert":
                        string mainText = (string)question.GetRightAnswer();
                        mainText = mainText.Replace(":^(space)^:", "__________");
                        TextBox questionText = new TextBox();

                        questionText.Location = new Point(30, 20);
                        questionText.Text = mainText;
                        questionText.Width = 900;
                        questionText.Height = 75;
                        questionText.Multiline = true;
                        questionText.Enabled = false;
                        questionText.ScrollBars = ScrollBars.Vertical;

                        AnswerPanel.Controls.Add(questionText);

                        Label num = new Label();
                        TextBox numText = new TextBox();

                        num.Location = new Point(30, numPosition);
                        num.Text = $"{i + 1}.";
                        num.Size = new Size(20, 20);
                        AnswerPanel.Controls.Add(num);

                        numText.Location = new Point(50, numPosition);
                        numText.Name = "Text";
                        numText.Width = 150;
                        AnswerPanel.Controls.Add(numText);
                        numPosition += 20;

                        break;

                    default:
                        return;
                }
                label += 48;
                txt += 48;
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (save && current + 1 < test.Count)
            {
                TestProgress.Increment(1);
                current++;
                Show_Elements(test[current]);
                if (current == test.Count - 1)
                {
                    Next.Enabled = false;
                }
                save = false;
            }
            else MessageBox.Show($"Нажмите \"Сохранить ответ\"");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!save)
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
                        if (n.Text == string.Empty)
                        {
                            Warning warning = new Warning();
                            warning.ShowDialog();
                            return;
                        }
                    }
                }

                switch (test[current].Type)
                {
                    case "Single":
                        int right = 0;
                        foreach (var i in all)
                        {
                            if (i.GetType() == typeof(RadioButton))
                            {
                                RadioButton r = (RadioButton)i;
                                if (r.Checked)
                                {
                                    right = int.Parse(r.Name);
                                    break;
                                }
                            }
                        }
                        forCheck.Add(new EndAnswer(right));
                        break;

                    case "Multi":
                        List<int> rightAnswers = new List<int>();
                        foreach (var i in all)
                        {
                            if (i.GetType() == typeof(CheckBox))
                            {
                                CheckBox c = (CheckBox)i;
                                if (c.Checked)
                                    rightAnswers.Add(int.Parse(c.Name));
                            }
                        }
                        forCheck.Add(new EndAnswer(rightAnswers));
                        break;

                    case "Sentence":
                        string answer = "";
                        foreach (var i in all)
                        {
                            if (i.GetType() == typeof(TextBox))
                            {
                                TextBox n = (TextBox)i;
                                if (n.Name == "first")
                                    answer = n.Text.ToLower();
                            }
                        }
                        forCheck.Add(new EndAnswer(answer));
                        break;

                    case "Compare":
                        string rightCombination = "", alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        foreach (var i in all)
                        {
                            if (i.GetType() == typeof(ComboBox))
                            {
                                ComboBox c = (ComboBox)i;
                                rightCombination += alphabet[int.Parse(c.Text) - 1];
                            }
                        }
                        forCheck.Add(new EndAnswer(rightCombination));
                        break;

                    case "Insert":
                        List<string> answs = new List<string>();
                        foreach (var i in all)
                        {
                            if (i.GetType() == typeof(TextBox))
                            {
                                TextBox tb = (TextBox)i;
                                if (tb.Name == "Text")
                                    answs.Add(tb.Text);
                            }
                        }

                        forCheck.Add(new EndAnswer(answs));
                        break;
                }
                save = true;
            }
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            if (save)
            {
                if(test.Count==forCheck.Count)
                {
                    for(int i = 0; i < test.Count; i++)
                    {
                        switch(test[i].Type)
                        {
                            case "Single":
                                if ((int)test[i].GetRightAnswer() == (int)forCheck[i].GetResult())
                                    countOfTaked++;
                                break;

                            case "Multi":
                                List<int> it1 = (List<int>)test[i].GetRightAnswer(), it2 = (List<int>)forCheck[i].GetResult();
                                if(it1.SequenceEqual(it2))
                                    countOfTaked++;
                                break;

                            case "Sentence":
                            case "Compare":
                                if ((string)test[i].GetRightAnswer() == (string)forCheck[i].GetResult())
                                    countOfTaked++;
                                break;

                            case "Insert":
                                List<string> l1 = test[i].GetAnswers(), l2 = test[i].GetAnswers();
                                if (l1.SequenceEqual(l2))
                                    countOfTaked++;
                                break;
                        }
                    }

                    ResultForm resultForm = new ResultForm();
                    resultForm.Five = five;
                    resultForm.Four = four;
                    resultForm.Three = three;
                    resultForm.Count = test.Count;
                    resultForm.CountOfTaked = countOfTaked;
                    resultForm.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show($"Вы ответили не на все вопросы!");
            }
            else MessageBox.Show($"Нажмите \"Сохранить ответ\"");
        }

    }
}
