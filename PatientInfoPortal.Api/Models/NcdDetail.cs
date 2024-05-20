using System;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Models;

public partial class NcdDetail
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int Ncdid { get; set; }

    public virtual Ncd Ncd { get; set; } = null!;

    public virtual PatientsInformation Patient { get; set; } = null!;
}
