namespace Lesson_1
{
    // DTO класс.
    public class WeatherForecast
    {
        // Объвление полей класса: 
        private static readonly string[] Summaries = new string[]
        { "Freezing", "Bracing",
            "Chilly", "Cool",
            "Mild", "Warm",
            "Balmy", "Hot",
            "Sweltering", "Scorching" };

        private string? _currentTime;
        private int _tempereture;
        private string? _summary;

        // Переопредление конструктора по умолчанию:
        public WeatherForecast()
        {
            // Вызывем методы -> производим инициализацию полей:
            SetTemperature();
            SetCurrentTime();
            SetSummary();
        }

        // Методы класса:
        private void SetTemperature() => _tempereture = new Random().Next(-55, 55);  // Получения температуры.

        private void SetCurrentTime() => _currentTime = DateTime.Now.ToLongTimeString();  // Получения времени.  

        private void SetSummary() => _summary = Summaries[new Random().Next(0, Summaries.Length - 1)];  // Получение описания.

        // Своства класса для обращения к значениям полей:
        public string Time => _currentTime ?? String.Empty;  // Возврат времени.
        public int Temperature  // Обращение к значению температуры:
        {
            get => _tempereture;  // Возврат значения.
            set => _tempereture = value;  // Установка значения.
        }
        public string Summary => _summary ?? String.Empty;  // Возврат описания.
    }
}