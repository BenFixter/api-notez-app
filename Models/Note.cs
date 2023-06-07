namespace api_notez_app.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set;}
        public bool deleteMode { get; set; }
    }
}
