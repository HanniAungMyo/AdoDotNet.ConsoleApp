namespace DotNetTraningSnakesApi.Models
{


    public class SnakeDataModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string MMName { get; set; }
        public string EngName { get; set; }
        public string Detail { get; set; }
        public string IsPoison { get; set; }
        public string IsDanger { get; set; }
    }

    public class SnakeViewModel
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }
        public string MyanmarName { get; set; }
        public string EnglishName{ get; set; }
        public string Detail { get; set; }
        public string IsPoison { get; set; }
        public string IsDanger { get; set; }
    }

}



