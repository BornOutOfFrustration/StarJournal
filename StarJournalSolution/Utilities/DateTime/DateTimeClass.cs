namespace Utilities.DateTime
{
    using System;

    public sealed class DateTimeClass : IDateTime
    {
        DateTime IDateTime.Current
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public interface IDateTime
    {
        DateTime Current { get; }
    }
}
