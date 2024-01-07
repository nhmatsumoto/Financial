namespace nhmatsumoto.financial.domain.ValueObjects
{
    public class CustomDateTime
    {
        private readonly DateTime _dateTime;

        public CustomDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Formato de data inválido, use UTC", nameof(dateTime));
            }

            _dateTime = dateTime;
        }

        public int Hours => _dateTime.Hour;

        public CustomDateTime AddHours(int hours) =>
            new CustomDateTime(_dateTime.AddHours(hours));

        public override string ToString() =>
            _dateTime.ToString("yyyy-MM-dd HH:mm:ss UTC");
    }
}
