namespace Application.DTOs.StatisticsDTOs
{
    public class UserMushroomingStatisticsDto
    {
        public int TotalMushroomings { get; set; }
        public List<MushroomingStatisticsDto> MushroomingsByLocation { get; set; }
    }
}
