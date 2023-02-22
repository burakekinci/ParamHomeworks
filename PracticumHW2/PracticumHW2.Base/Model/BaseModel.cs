namespace PracticumHW2.Base.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
