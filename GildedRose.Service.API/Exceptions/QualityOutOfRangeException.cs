namespace GildedRose.Service.API.Exceptions
{
    public class QualityOutOfRangeException : ValidationException
    {
        public QualityOutOfRangeException(string message)
            : base(message)
        {
        }

        public QualityOutOfRangeException(int maximumAllowedQuality)
            : base($"Quality cannot be greater than the maximum allowed of {maximumAllowedQuality}")
        {
        }
    }
}
