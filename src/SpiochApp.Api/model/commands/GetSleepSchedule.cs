namespace SpiochApp.Api.model.commands;

public sealed record GetSleepSchedule(IEnumerable<string> People, DateTime SleepStart, DateTime SleepEnd);