using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class Schedule
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Color Color { get; set; }
        public string Description { get; set; }

        public Schedule(DateTime date)
        {
            Date = date;
        }
        public Schedule(string title, DateTime date, string startTime, string endTime, Color color, string description)
        {
            Title = title;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Color = color;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Title} / 날짜: {Date.ToShortDateString()} / 시간: {StartTime} ~ {EndTime}";

        }
    }

    
  
}
