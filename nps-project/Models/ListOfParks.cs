namespace nps_project.Models
{
    public class ListOfParks
    {
#pragma warning disable CS8618 // Non-nullable property 'total' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string total { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'total' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        
#pragma warning disable CS8618 // Non-nullable property 'data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<Park> data { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'limit' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string limit { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'limit' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'start' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string start { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'start' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

    }
}
