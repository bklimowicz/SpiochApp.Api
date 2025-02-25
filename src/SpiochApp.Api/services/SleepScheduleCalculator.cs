using SpiochApp.Api.model.commands;
using SpiochApp.Api.model.responses;

namespace SpiochApp.Api.services;

public class SleepScheduleCalculator : ISleepScheduleCalculator
{
    public List<SleepSpanDto> Calculate(GetSleepSchedule request)
    {
        var people = request.People;
        var sleepStart = request.SleepStart;
        var sleepEnd = request.SleepEnd;

        var sleepDuration = sleepEnd - sleepStart;
        var sleepSpans = people.Count();
        var sleepSpanDuration = sleepDuration / sleepSpans;
        
        var schedule = new List<SleepSpanDto>();
        for (var i = 0; i < sleepSpans; i++)
        {
            var sleepPeriod = new SleepSpanDto
            {
                SleepStart = TimeOnly.FromDateTime(sleepStart + i * sleepSpanDuration),
                SleepEnd = TimeOnly.FromDateTime(sleepStart + (i + 1) * sleepSpanDuration),
                PersonOnDuty = people.ElementAt(i),
                PeopleWhoSleep = people.Where(person => person != people.ElementAt(i)).ToList()
            };
            
            schedule.Add(sleepPeriod);
        }
        
        return schedule;
    }
}

