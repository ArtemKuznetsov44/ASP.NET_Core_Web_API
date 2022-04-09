namespace Lesson_1
{
    // DTO �����.
    public class WeatherForecast
    {
        // ��������� ����� ������: 
        private static readonly string[] Summaries = new string[]
        { "Freezing", "Bracing",
            "Chilly", "Cool",
            "Mild", "Warm",
            "Balmy", "Hot",
            "Sweltering", "Scorching" };

        private string? _currentTime;
        private int _tempereture;
        private string? _summary;

        // �������������� ������������ �� ���������:
        public WeatherForecast()
        {
            // ������� ������ -> ���������� ������������� �����:
            SetTemperature();
            SetCurrentTime();
            SetSummary();
        }

        // ������ ������:
        private void SetTemperature() => _tempereture = new Random().Next(-55, 55);  // ��������� �����������.

        private void SetCurrentTime() => _currentTime = DateTime.Now.ToLongTimeString();  // ��������� �������.  

        private void SetSummary() => _summary = Summaries[new Random().Next(0, Summaries.Length - 1)];  // ��������� ��������.

        // ������� ������ ��� ��������� � ��������� �����:
        public string Time => _currentTime ?? String.Empty;  // ������� �������.
        public int Temperature  // ��������� � �������� �����������:
        {
            get => _tempereture;  // ������� ��������.
            set => _tempereture = value;  // ��������� ��������.
        }
        public string Summary => _summary ?? String.Empty;  // ������� ��������.
    }
}