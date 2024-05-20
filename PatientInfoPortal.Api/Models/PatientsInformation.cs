using System;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Models;

public partial class PatientsInformation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AllergiesDetail> AllergiesDetails { get; set; } = new List<AllergiesDetail>();

    public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
}
