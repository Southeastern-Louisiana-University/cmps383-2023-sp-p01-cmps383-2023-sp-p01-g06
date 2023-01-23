namespace SP23.P01.Web
{
    public class TrainStation
    {
        public int id { get;set; }
        public string Name { get;set; }
        public string Address { get; set; }

    }

    public class TrainStationUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class TrainStationCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set;}
    }
}
