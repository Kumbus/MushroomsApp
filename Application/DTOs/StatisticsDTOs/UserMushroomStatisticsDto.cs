namespace Application.DTOs.StatisticsDTOs
{
    public class UserMushroomStatisticsDto
    {
        public int TotalMushrooms { get; set; }
        public double TotalWeight { get; set; }
        public List<MushroomStatisticsDto> MushroomsByType { get; set; }
    }
}
