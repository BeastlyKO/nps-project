namespace nps_project.Models
{
    public class ExceptionHour
    {
#pragma warning disable CS8618 // Non-nullable property 'exceptionHours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Hours exceptionHours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'exceptionHours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'startDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string startDate { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'startDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'endDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string endDate { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'endDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
