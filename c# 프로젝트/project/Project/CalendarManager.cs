using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class CalendarManager
    {
        public event Action ScheduleUpdated; // 일정 업데이트 이벤트
        public event Action ScheduleAdded; // 일정 추가 이벤트
        public event Action ScheduleDeleted; // 일정 삭제 이벤트

        private List<Schedule> schedules = new List<Schedule>(); // 일정 저장 리스트

        public List<Schedule> Schedules => schedules; // 외부에서 일정을 가져올 수 있도록 프로퍼티 제공

        // 일정 추가 메서드
        public void AddSchedule(Schedule schedule)
        {
            schedules.Add(schedule);
            ScheduleAdded?.Invoke(); // 일정 추가 이벤트 발생
        }

        // 일정 수정 메서드
        public void UpdateSchedule(Schedule updatedSchedule)
        {
            var existingSchedule = schedules.Find(s => s.Number == updatedSchedule.Number);
            if (existingSchedule != null)
            {
                existingSchedule.Title = updatedSchedule.Title;
                existingSchedule.Date = updatedSchedule.Date;
                // 다른 속성들 업데이트...
                ScheduleUpdated?.Invoke(); // 일정 업데이트 이벤트 발생
            }
        }

        // 일정 삭제 메서드
        public void DeleteSchedule(int scheduleNumber)
        {
            var scheduleToRemove = schedules.Find(s => s.Number == scheduleNumber);
            if (scheduleToRemove != null)
            {
                schedules.Remove(scheduleToRemove);
                ScheduleDeleted?.Invoke(); // 일정 삭제 이벤트 발생
            }
        }
    }
}