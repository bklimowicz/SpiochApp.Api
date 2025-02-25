namespace SpiochApp.Api.model.responses;

public class SleepSpanDto
{
    public TimeOnly SleepStart { get; set; }
    public TimeOnly SleepEnd { get; set; }
    public string PersonOnDuty { get; set; }
    public List<string> PeopleWhoSleep { get; set; }
}