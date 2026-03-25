using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App_For_Tests
{
    internal abstract class Question
    {
        public int Number { get; set; } // порядковый номер вопроса
        public string Type { get; set; } // тип вопроса
        public int Count { get; set; } // количество вариантов ответов
        public string Wording { get; set; } // формулировка вопроса
        protected List<string> answers = new List<string>();

        protected Question() { }
        protected Question(int number, int count, string wording, List<string> answs)
        {
            Number = number;
            Count = count;
            Wording = wording;
            answers = answs;
        }

        public List<string> GetAnswers() { return answers; }
        abstract public object GetRightAnswer();
        virtual public List<string> GetExtra() { return answers; }
        public abstract void WriteToXml(ref XmlDocument openXml);
    }

    internal class SingleAnswer : Question
    {
        int rightAnswer; // номер правильного ответа
        public SingleAnswer()
        {
            Type = "Single";
        }

        public SingleAnswer(int number, int count, string wording, List<string> answs, int rghtAns) : base(number, count, wording, answs)
        {
            Type = "Single";
            rightAnswer = rghtAns;
        }

        public override object GetRightAnswer() {  return rightAnswer; }

        public override void WriteToXml(ref XmlDocument openXml)
        {
            XmlNode rootNode = openXml.DocumentElement;

            XmlNode questionNode = openXml.CreateElement("Single");

            XmlNode numberNode = openXml.CreateElement("Number");
            XmlNode typeNode = openXml.CreateElement("Type");
            XmlNode countNode = openXml.CreateElement("Count");
            XmlNode wordingNode = openXml.CreateElement("Wording");
            XmlNode answersNode = openXml.CreateElement("Answers");
            XmlNode rightAnswerNode = openXml.CreateElement("RightAnswer");

            numberNode.InnerText = Number.ToString();
            typeNode.InnerText = Type;
            countNode.InnerText = Count.ToString();
            wordingNode.InnerText = Wording;
            rightAnswerNode.InnerText = rightAnswer.ToString();

            XmlNode added;
            foreach(string ans in answers)
            {
                added = openXml.CreateElement("Answer");
                added.InnerText = ans;
                answersNode.AppendChild(added);
            }

            questionNode.AppendChild(numberNode);
            questionNode.AppendChild(typeNode);
            questionNode.AppendChild(countNode);
            questionNode.AppendChild(wordingNode);
            questionNode.AppendChild(answersNode);
            questionNode.AppendChild(rightAnswerNode);

            rootNode.AppendChild(questionNode);
        }
    }

    internal class MultiAnswer : SingleAnswer
    {
        List<int> rightAnswers = new List<int>();
        public MultiAnswer()
        {
            Type = "Multi";
        }
        public MultiAnswer(int number, int count, string wording, List<string> answs, List<int> rghtAnswers) : base(number, count, wording, answs, 0)
        {
            Type = "Multi";
            rightAnswers = rghtAnswers;
        }

        public override object GetRightAnswer() { return rightAnswers; }

        public override void WriteToXml(ref XmlDocument openXml)
        {
            XmlNode rootNode = openXml.DocumentElement;

            XmlNode questionNode = openXml.CreateElement("Multi");

            XmlNode numberNode = openXml.CreateElement("Number");
            XmlNode typeNode = openXml.CreateElement("Type");
            XmlNode countNode = openXml.CreateElement("Count");
            XmlNode wordingNode = openXml.CreateElement("Wording");
            XmlNode answersNode = openXml.CreateElement("Answers");
            XmlNode rightAnswerNode = openXml.CreateElement("RightAnswers");

            numberNode.InnerText = Number.ToString();
            typeNode.InnerText = Type;
            countNode.InnerText = Count.ToString();
            wordingNode.InnerText = Wording;

            XmlNode added;
            foreach (string ans in answers)
            {
                added = openXml.CreateElement("Answer");
                added.InnerText = ans;
                answersNode.AppendChild(added);
            }

            foreach (int ans in rightAnswers)
            {
                added = openXml.CreateElement("RightAnswer");
                added.InnerText = ans.ToString();
                rightAnswerNode.AppendChild(added);
            }

            questionNode.AppendChild(numberNode);
            questionNode.AppendChild(typeNode);
            questionNode.AppendChild(countNode);
            questionNode.AppendChild(wordingNode);
            questionNode.AppendChild(answersNode);
            questionNode.AppendChild(rightAnswerNode);

            rootNode.AppendChild(questionNode);
        }
    }

    internal class SentenceAnswer : SingleAnswer
    {
        string rightAnswer;

        public SentenceAnswer() 
        {
            Type = "Sentence";
        }

        public SentenceAnswer(int number, string wording,  string answer) : base(number, 1, wording, new List<string>() { answer }, 0) 
        {
            Type = "Sentence";
            rightAnswer = answer;
        }

        public override object GetRightAnswer() { return rightAnswer; }

        public override void WriteToXml(ref XmlDocument openXml)
        {
            XmlNode rootNode = openXml.DocumentElement;

            XmlNode questionNode = openXml.CreateElement("Sentence");

            XmlNode numberNode = openXml.CreateElement("Number");
            XmlNode typeNode = openXml.CreateElement("Type");
            XmlNode countNode = openXml.CreateElement("Count");
            XmlNode wordingNode = openXml.CreateElement("Wording");
            XmlNode answerNode = openXml.CreateElement("Answer");
            XmlNode rightAnswerNode = openXml.CreateElement("RightAnswer");

            numberNode.InnerText = Number.ToString();
            typeNode.InnerText = Type;
            countNode.InnerText = Count.ToString();
            wordingNode.InnerText = Wording;
            answerNode.InnerText = rightAnswer;
            rightAnswerNode.InnerText = rightAnswer;

            questionNode.AppendChild(numberNode);
            questionNode.AppendChild(typeNode);
            questionNode.AppendChild(countNode);
            questionNode.AppendChild(wordingNode);
            questionNode.AppendChild(answerNode);
            questionNode.AppendChild(rightAnswerNode);

            rootNode.AppendChild(questionNode);
        }
    }

    internal class CompareAnswer : Question
    {
        List<string> extraAnswers = new List<string>();
        string rightAnswers; // правильная последовательность букв, например "CDAB"

        public CompareAnswer()
        {
            Type = "Compare";
        }
        public CompareAnswer(int number, int count, string wording, List<string> answs, List<string> extra, string rghtAnswers) : base(number, count, wording, answs)
        {
            Type = "Compare";
            extraAnswers = extra;
            rightAnswers = rghtAnswers;
        }

        public override object GetRightAnswer() { return rightAnswers; }
        override public List<string> GetExtra() { return extraAnswers; }

        public override void WriteToXml(ref XmlDocument openXml)
        {
            XmlNode rootNode = openXml.DocumentElement;

            XmlNode questionNode = openXml.CreateElement("Compare");

            XmlNode numberNode = openXml.CreateElement("Number");
            XmlNode typeNode = openXml.CreateElement("Type");
            XmlNode countNode = openXml.CreateElement("Count");
            XmlNode wordingNode = openXml.CreateElement("Wording");
            XmlNode answersNode = openXml.CreateElement("Answers");
            XmlNode extraAnswersNode = openXml.CreateElement("ExtraAnswers");
            XmlNode rightAnswerNode = openXml.CreateElement("RightAnswer");

            numberNode.InnerText = Number.ToString();
            typeNode.InnerText = Type;
            countNode.InnerText = Count.ToString();
            wordingNode.InnerText = Wording;
            rightAnswerNode.InnerText = rightAnswers;

            XmlNode added;
            foreach (string ans in answers)
            {
                added = openXml.CreateElement("Answer");
                added.InnerText = ans;
                answersNode.AppendChild(added);
            }

            foreach (string ans in extraAnswers)
            {
                added = openXml.CreateElement("ExtraAnswer");
                added.InnerText = ans.ToString();
                extraAnswersNode.AppendChild(added);
            }

            questionNode.AppendChild(numberNode);
            questionNode.AppendChild(typeNode);
            questionNode.AppendChild(countNode);
            questionNode.AppendChild(wordingNode);
            questionNode.AppendChild(answersNode);
            questionNode.AppendChild(extraAnswersNode);
            questionNode.AppendChild(rightAnswerNode);

            rootNode.AppendChild(questionNode);
        }
    }

    internal class InsertAnswer : Question
    {
        string mainText;

        public InsertAnswer()
        {
            Type = "Insert";
        }

        public InsertAnswer(int number, int count, string wording, List<string> answs, string txt) : base(number, count, wording, answs)
        {
            Type = "Insert";
            mainText = txt;
        }

        public override object GetRightAnswer() { return mainText; } 

        public override void WriteToXml(ref XmlDocument openXml)
        {
            XmlNode rootNode = openXml.DocumentElement;

            XmlNode questionNode = openXml.CreateElement("Insert");

            XmlNode numberNode = openXml.CreateElement("Number");
            XmlNode typeNode = openXml.CreateElement("Type");
            XmlNode countNode = openXml.CreateElement("Count");
            XmlNode wordingNode = openXml.CreateElement("Wording");
            XmlNode answersNode = openXml.CreateElement("Answers");
            XmlNode mainTextNode = openXml.CreateElement("MainText");

            numberNode.InnerText = Number.ToString();
            typeNode.InnerText = Type;
            countNode.InnerText = Count.ToString();
            wordingNode.InnerText = Wording;
            mainTextNode.InnerText = mainText;

            XmlNode added;
            foreach (string ans in answers)
            {
                added = openXml.CreateElement("Answer");
                added.InnerText = ans;
                answersNode.AppendChild(added);
            }

            questionNode.AppendChild(numberNode);
            questionNode.AppendChild(typeNode);
            questionNode.AppendChild(countNode);
            questionNode.AppendChild(wordingNode);
            questionNode.AppendChild(answersNode);
            questionNode.AppendChild(mainTextNode);

            rootNode.AppendChild(questionNode);
        }
    }
}
