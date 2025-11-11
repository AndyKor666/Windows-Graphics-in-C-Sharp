using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool is_empty(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }
        bool is_valid_day(int day, int month)
        {
            if (day < 1)
            {
                return false;
            }
            int[] daysInMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return day <= daysInMonth[month - 1];
        }
        bool is_valid_month(int month)
        {
            return month >= 1 && month <= 12;
        }
        string GetZodiac(int day, int month)
        {
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19)) return "Aries";
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20)) return "Taurus";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20)) return "Gemini";
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22)) return "Cancer";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22)) return "Leo";
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22)) return "Virgo";
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22)) return "Libra";
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21)) return "Scorpio";
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21)) return "Sagittarius";
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19)) return "Capricorn";
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18)) return "Aquarius";
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20)) return "Pisces";
            else return "ERROR";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text?.Trim();

            if (is_empty(name))
            {
                this.label5.BackColor = Color.MistyRose;
                this.label5.Text = "Name cannot be empty!";
                return;
            }

            if (!int.TryParse(textBox2.Text, out int day))
            {
                this.label5.BackColor = Color.MistyRose;
                this.label5.Text = "Day must be a number!";
                return;
            }

            if (!int.TryParse(textBox3.Text, out int month))
            {
                this.label5.BackColor = Color.MistyRose;
                this.label5.Text = "Month must be a number!";
                return;
            }
            if (!is_valid_month(month))
            {
                this.label5.BackColor = Color.MistyRose;
                this.label5.Text = "Invalid month!";
                return;
            }
            if (!is_valid_day(day, month))
            {
                this.label5.BackColor = Color.MistyRose;
                this.label5.Text = "Invalid day!";
                return;
            }

            string zodiac = GetZodiac(day, month);
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            this.label5.BackColor = Color.WhiteSmoke;
            this.label5.Text = $"{name}, your zodiac sign is: {zodiac} . . .";
        }
    }
}
