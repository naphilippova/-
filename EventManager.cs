using System;
using System.ComponentModel;

namespace Индивидуальное_задание
{
    internal class EventManager
    {
        // Свойство: список событий Events
        public BindingList<Event> Events { get; set; }
        // Конструктор: создание списка событий Events
        public EventManager()
        {
            Events = new BindingList<Event>();
        }
        // Метод: добавляет новое событие в сисок событий Events
        public void Add(string eventname, DateTime eventdate)
        {
            // Проверяем, название должно быть больше 3 символов
            if (eventname.Length < 3)
                throw new ArgumentException("Название слишком короткое...");
            // Проверяем, событие не должно быть в прошлом
            if (eventdate.Date < DateTime.Today)
                throw new ArgumentException("Дата события не должна быть в прошлом...");
            // Создаём событие с названием eventname и датой eventdate
            Event evt = new Event(eventname, eventdate);
            Events.Add(evt);
        }
        // Метод: удаляет событие evt из списка событий Events
        public void Remove(Event evt)
        {
            Events.Remove(evt);
        }
    }
}
