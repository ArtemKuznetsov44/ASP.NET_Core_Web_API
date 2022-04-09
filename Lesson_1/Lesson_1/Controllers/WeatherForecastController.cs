using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Repository repository;  // Объявление переменной - класса хранилища.

        // Переопределения конструктора с инициализацией класса для хранения:
        public WeatherForecastController(Repository repository) => this.repository = repository;  

        // Метод для формирование данных - прогнозов:
        [HttpPost("create")]
        public string CreateWeatherForecast()
        {
            WeatherForecast weatherForecast = new();  // Объвление и создание экземпляра класса WeatherForecast.

            repository.holder.Add(weatherForecast);  // Добавления значения в хранилище.

            return "Creation was successful!";  // Отображение информации пользователю.
        }

        // Метод для иземения заначения темперетуры, принимающий (время, по которому производить изменение; новое значение):
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

        // Метод страния значения температуры по указанному времени:
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

        // Метод для чтения показаний с указанного времени, по указанное время:
        [HttpGet("read")]
        public List<WeatherForecast> GetValues([FromQuery] string startTime, [FromQuery] string endTime)
        {
            List<WeatherForecast> timeToTimeForecasts = new();  // Список для подходящий показаний.

            foreach (WeatherForecast forecast in repository.holder)  // Цикл по каждому из элементов в хранилище:
            {
                // Отбор подходящий по временному промежутку показаний:
                if (TimeOnly.Parse(forecast.Time) >= TimeOnly.Parse(startTime) && TimeOnly.Parse(forecast.Time) <= TimeOnly.Parse(endTime))
                {
                    timeToTimeForecasts.Add(forecast);  // Добавление подходящий показаний в новый список.
                }
            }
            return timeToTimeForecasts;  // Вовзрат созданного списка.
        }

        // Метод для чтения всех показаний из хранилища:
        [HttpGet("readAll")]
        public List<WeatherForecast> GetAllValues()
        {
            return repository.holder;
        }
    }
}