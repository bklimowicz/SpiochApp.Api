using SpiochApp.Api.model.commands;
using SpiochApp.Api.model.responses;

namespace SpiochApp.Api.services;

public interface ISleepScheduleCalculator
{
    List<SleepSpanDto> Calculate(GetSleepSchedule request);
}