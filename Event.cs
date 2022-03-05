using System;

namespace Индивидуальное_задание
{
    internal class Event
    {
        // Свойство: название события
        public string EventName { get; set; }
        // Свойство: дата события
        public DateTime EventDate { get; set; }
        // Конструктор: создание события с названием eventname в день eventdate
        public Event(string eventname, DateTime eventdate)
        {
            this.EventName = eventname;
            this.EventDate = eventdate;
        }
        // Переопределение метода ToString(), чтобы он возвращал его название события
        public override string ToString()
        {
            return this.EventName;
        }
    }
}
