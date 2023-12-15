namespace Lilya.Models
{
    public class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetricName { get; set; }
        public string? MetricDescription { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
