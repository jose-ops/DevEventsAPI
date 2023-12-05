﻿using System;

namespace AwesomeDevEventsAPI.Entities
{
    public class DevEvents
    {
        public DevEvents()
        {
            Speakers = new List<DevEventsSpeaker>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventsSpeaker> Speakers { get; set; }
        public bool IsDeleted { get; set; }
        public void Update(string title, string description, DateTime startDate, DateTime dateTime)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = dateTime;
        }

        public void Delete() 
        {
            IsDeleted = true;
        }
    }
}
