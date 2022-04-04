using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Repository repository;  // ���������� ���������� - ������ ���������.

        // ��������������� ������������ � �������������� ������ ��� ��������:
        public WeatherForecastController(Repository repository) => this.repository = repository;  

        // ����� ��� ������������ ������ - ���������:
        [HttpPost("create")]
        public string CreateWeatherForecast()
        {
            WeatherForecast weatherForecast = new();  // ��������� � �������� ���������� ������ WeatherForecast.

            repository.holder.Add(weatherForecast);  // ���������� �������� � ���������.

            return "Creation was successful!";  // ����������� ���������� ������������.
        }

        // ����� ��� �������� ��������� �����������, ����������� (�����, �� �������� ����������� ���������; ����� ��������):
        [HttpPut("update")]
        public string UpdateValue([FromQuery] string time, [FromQuery] int newTemperature)
        {
            foreach (WeatherForecast forecast in repository.holder)
            {
                if (TimeOnly.Parse(forecast.Time) == TimeOnly.Parse(time))
                {
                    forecast.Temperature = newTemperature;
                    return "Value was updated.";
                }
            }
            return "No such forecast exist...";
        }

        // ����� ������� �������� ����������� �� ���������� �������:
        [HttpDelete("delete")]
        public string DeleteValue([FromQuery] string time)
        {

            foreach (WeatherForecast forecast in repository.holder)
            {
                if (TimeOnly.Parse(forecast.Time) == TimeOnly.Parse(time))
                {
                    forecast.Temperature = default;
                    return "Value was change to zero.";
                }
            }
            return "No such forecast exist...";
        }

        // ����� ��� ������ ��������� � ���������� �������, �� ��������� �����:
        [HttpGet("read")]
        public List<WeatherForecast> GetValues([FromQuery] string startTime, [FromQuery] string endTime)
        {
            List<WeatherForecast> timeToTimeForecasts = new();  // ������ ��� ���������� ���������.

            foreach (WeatherForecast forecast in repository.holder)  // ���� �� ������� �� ��������� � ���������:
            {
                // ����� ���������� �� ���������� ���������� ���������:
                if (TimeOnly.Parse(forecast.Time) >= TimeOnly.Parse(startTime) && TimeOnly.Parse(forecast.Time) <= TimeOnly.Parse(endTime))
                {
                    timeToTimeForecasts.Add(forecast);  // ���������� ���������� ��������� � ����� ������.
                }
            }
            return timeToTimeForecasts;  // ������� ���������� ������.
        }

        // ����� ��� ������ ���� ��������� �� ���������:
        [HttpGet("readAll")]
        public List<WeatherForecast> GetAllValues()
        {
            return repository.holder;
        }
    }
}