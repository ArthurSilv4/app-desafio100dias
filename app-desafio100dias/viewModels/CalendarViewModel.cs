﻿using Plugin.Maui.Calendar.Models;
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
    }

    internal class EventModel
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime eventDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}