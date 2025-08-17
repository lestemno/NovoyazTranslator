using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Novoyaz
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "война", "мир" },
            { "свобода", "рабство" },
            { "незнание", "сила" },
            { "большому брату", "бб" },
            { "большой брат", "бб" },
            { "большого брата", "бб" },
            { "большим братом", "бб" },
            { "большом брате", "бб" },
            { "Австрали", "Океани" },
            { "Исланди", "Океани" },
            { "Америка", "Океания" },
            { "Америку", "Океанию" },
            { "Америке", "Океании" },
            { "Америки", "Океании" },
            { "Америкой", "Океанией" },
            { "Африка", "Океания" },
            { "Африку", "Океанию" },
            { "Африке", "Океании" },
            { "Африки", "Океании" },
            { "рабочие", "пролы" },
            { "Антарктида", "Океания" },
            { "пролетариат", "пролы" },
            { "пропаганда", "пролфид" },
            { " до ", "анте" },
            { "иначе", "анте" },
            { "Великобритания", "Аирстрип Один" },
            { "Соединенное Королевство", "Аирстрип Один" },
            { "очень", "даблплюс" },
            { "невероятно", "даблплюс" },
            { "одинаково", "эквил" },
            { "одинаковы", "эквил" },
            { "полный", "фулвайс" },
            { "полностью", "фулвайс" },
            { "правильно", "гудвайс" },
            { "язык", "новояз" },
            { "английский", "старояз" }
        };

        List<string> zapret = new List<string>()
        {
            "бунт",
            "революция",
            "восстание",
            "братство",
            "равенство",
            "ненависть",
            "мысль",
            "идея",
            "самостоятельность",
            "анархия",
            "право",
            "справедливость",
            "сексуальность",
            "интимность",
            "романтика",
            "эротика",
            "измена",
            "счастье",
            "радость",
            "печаль",
            "страх",
            "тоска",
            "грусть",
            "ненужный",
            "республика",
            "оппозиция",
            "заговор",
            "забастовка",
            "террор",
            "критика",
            "сомнение"
        };

        public Form1()
        {
            InitializeComponent();
            this.Text = "Новояз Переводчик";
        }

        private string deletezapretki(string text)
        {
            foreach (var word in zapret)
            {
                text = Regex.Replace(text, @"\b" + Regex.Escape(word) + @"\b", "", RegexOptions.IgnoreCase);
            }
            text = Regex.Replace(text, @"\s+", " ").Trim();
            return text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            input = deletezapretki(input);
            var sortedDict = dict.OrderByDescending(p => p.Key.Length);
            string output = input;

            foreach (var pair in sortedDict)
            {
                output = Regex.Replace(output, Regex.Escape(pair.Key), m =>
                {
                    string tr = pair.Value;
                    if (char.IsUpper(m.Value[0]))
                    {
                        return char.ToUpper(tr[0]) + tr.Substring(1);
                    }
                    return tr;
                },
                RegexOptions.IgnoreCase);
            }

            textBox2.Text = output;
        }

    }
}
