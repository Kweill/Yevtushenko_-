using Core;
using System;
using System.Windows.Forms;

namespace Project_Yevtushenko_Lab6
{
    public partial class EditTransactionForm : Form
    {
        public Transaction? Result { get; private set; }

        public EditTransactionForm()
        {
            InitializeComponent();

            // чтобы по умолчанию было Income
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desc = textBox1.Text;
            double amount = (double)numericUpDown1.Value;
            DateTime date = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("Введи описание!");
                return;
            }

            Transaction t;

            if (radioButton2.Checked)
            {
                t = new ExpenseTransaction
                {
                    Description = desc,
                    Amount = amount,
                    Date = date
                };
            }
            else
            {
                t = new IncomeTransaction
                {
                    Description = desc,
                    Amount = amount,
                    Date = date
                };
            }

            Result = t;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EditTransactionForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // не нужно
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // не нужно
        }
    }
}