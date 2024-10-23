using Plugin.Maui.Calendar.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_desafio100dias.viewModels
{
    internal class CalendarViewModel
    {
        public CultureInfo Culture { get; } = new CultureInfo("pt-BR");
        public EventCollection Events { get; set; }
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public CalendarViewModel()
        {
            Events = new EventCollection();
        }

        public void AddEvent(EventModel newEvent)
        {
            if (!Events.ContainsKey(newEvent.eventDate))
                Events[newEvent.eventDate] = new List<EventModel>();

            var eventList = Events[newEvent.eventDate] as List<EventModel>;
            eventList?.Add(newEvent);
        }

        public void RemoveEvent(EventModel eventToRemove)
        {
            if (Events.ContainsKey(eventToRemove.eventDate))
            {
                var eventList = Events[eventToRemove.eventDate] as List<EventModel>;
                eventList?.Remove(eventToRemove);
                if (eventList != null && eventList.Count == 0)
                {
                    Events.Remove(eventToRemove.eventDate);
                }
            }
        }

        public void UpdateEvent(EventModel updatedEvent)
        {
            if (Events.ContainsKey(updatedEvent.eventDate))
            {
                var eventList = Events[updatedEvent.eventDate] as List<EventModel>;
                var existingEvent = eventList?.FirstOrDefault(e => e.Id == updatedEvent.Id);
                if (existingEvent != null)
                {
                    existingEvent.Name = updatedEvent.Name;
                    existingEvent.Description = updatedEvent.Description;
                    existingEvent.StartDate = updatedEvent.StartDate;
                    existingEvent.EndDate = updatedEvent.EndDate;
                }
            }
        }
    }

    public class EventModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime eventDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
