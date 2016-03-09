using System;

namespace AssociateRecords.Domain
{
    public interface IAmHistorical
    {
        DateTime FromDateTime { get; set; }

        DateTime? ToDateTime { get; set; }
    }
}