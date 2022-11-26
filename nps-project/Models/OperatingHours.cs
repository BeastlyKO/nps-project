namespace nps_project.Models
{
    public class OperatingHours
    {
#pragma warning disable CS8618 // Non-nullable property 'exceptions' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        List<ExceptionHour> exceptions { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'exceptions' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'standardHours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Hours standardHours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'standardHours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
