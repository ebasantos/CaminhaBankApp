namespace Model
{
    public class Applicant : People
    {
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
