namespace GradeUp.Entities
{
    public class Review
    {
        public long id { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public long id_user { get; set; }
        public Review()
        {
            
        }
    }
}
