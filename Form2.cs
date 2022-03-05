using System;
using System.Drawing;
using System.Windows.Forms;

namespace Индивидуальное_задание
{
    public partial class Form2 : Form
    {
        private EventManager eventManager;
        private static int EventID = 1;
        internal Form2(EventManager evtMng) : this()
        {
            this.eventManager = evtMng;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                eventManager.Add(textBox1.Text, dateTimePicker1.Value);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Подсказка в textBox1
            textBox1.Text = "Событие " + EventID.ToString();
            textBox1.ForeColor = Color.Gray;
            EventID++;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            // Возращаем в исходжное положение textBox1
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }
    }
}
