using System;
using System.Windows.Forms;

namespace Индивидуальное_задание
{
    public partial class Form1 : Form
    {
        private EventManager eventManager = new EventManager();
        public Form1()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            // Выводит текущую дату, день недели и время в заголовок формы Form1
            this.Text = "Сегодня: " + dateTime.ToString("D") + " " + dateTime.ToString("ddd") + " " + dateTime.ToString("HH:mm:ss");
            // Это привязывает listBox1 к Events, поэтому теперь он будет отображать его содержимое,
            // и если что-то будет добавлено в список Events, это будет отражено и в listBox1,
            // таким образом, список listBox1 будет содержать все заданные события,
            // посмотреть информацию о которых можно выбрав ту или иную его запись (вызовет метод: listBox1_SelectedIndexChanged)
            listBox1.DataSource = eventManager.Events;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(
                monthCalendar1.SelectionStart.Year, monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            // Добавить событие
            Form2 form2 = new Form2(eventManager, dateTime);
            form2.ShowDialog();
            // Выделить дату в monthCalendar1 для добавленного события
            monthCalendar1.AddBoldedDate(eventManager.Events[eventManager.Events.Count - 1].EventDate);
            // Обновить выделенные даты в monthCalendar1
            monthCalendar1.UpdateBoldedDates();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Удалить событие
            if (listBox1.SelectedItem != null)
            {
                Event selected = (Event)listBox1.SelectedItem;
                // Снять выделение даты в monthCalendar1 для удаляемого события
                monthCalendar1.RemoveBoldedDate(selected.EventDate);
                // Обновить выделенные даты в monthCalendar1
                monthCalendar1.UpdateBoldedDates();
                // Удалить событие из eventManager
                eventManager.Remove(selected);
            }
            if (listBox1.Items.Count == 0)
            {
                button2.Enabled=false;
                label2.Text = "Информация о выбранном событии:";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Вывести в label2 информацию о выбранном событии listBox1.SelectedItem
            if (listBox1.SelectedItem != null)
            {
                Event selected = (Event)listBox1.SelectedItem;
                label2.Text = "Информация о выбранном событии:\r" + selected.EventName + "" +
                    " назначено на " + selected.EventDate.ToString("D") + "" +
                    " " + selected.EventDate.ToString("ddd") + "" +
                    " в " + selected.EventDate.ToString("HH:mm:ss");
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
