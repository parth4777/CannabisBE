namespace cannabis_entities.Models
{
    public class PenaltyData
    {
        public int? Fine { get; set; } // Nullable int to allow for categories that don't use this penalty
        public int Misdemeanor { get; set; }
        public int Fourth_Degree_Felony { get; set; }
        public int? Community_Service { get; set; } // Nullable for the same reason
    }
}