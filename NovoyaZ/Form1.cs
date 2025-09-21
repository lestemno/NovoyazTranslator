using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NovoyaZ;

namespace Novoyaz
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> dict = dictionary.slov;
        private List<string> zapret = lists.zapretki;
        public Form1()
        {
            InitializeComponent();
            this.Text = "НовоязПереводчик";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Clipboard.SetText(textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}