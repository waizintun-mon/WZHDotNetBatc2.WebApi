namespace WZHDotNetBatc2.WebApi.Model
{
    public class MovieModel
    {
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public decimal Rating { get; set; }
    }
}
