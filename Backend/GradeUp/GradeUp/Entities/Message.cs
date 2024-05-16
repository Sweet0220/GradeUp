namespace GradeUp.Entities
{
    public class Message
    {
        public long id { get; set; }
        public string text { get; set; }
        public long id_chat { get; set; }
        public long id_user { get; set; }
        public string hour { get; set; }
        public DateTime send_date { get; set; }
        public Message()
        {
            
        }


    }
}
