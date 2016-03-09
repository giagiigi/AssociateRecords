using System;

namespace AssociateRecords.Domain
{
    public class AssignmentHistory : IAmHistorical
    {
        public virtual DateTime FromDateTime { get; set; }

        public virtual DateTime? ToDateTime { get; set; }

        public string AssignmentName { get; set; }

        public PerformanceRating PerformanceRating { get; set; }
    }
}