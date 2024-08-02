namespace BirdApi.Models
{
    public class birdDataModel
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
    //View Model  //to Clinet 
    //Client Model
    public class birdViewModel
    {
        public int BirdId { get; set; }
        public string BirdName { get; set; }
        public string Desc { get; set; }
        public string PhotoUrl { get; set; }
    }

}
