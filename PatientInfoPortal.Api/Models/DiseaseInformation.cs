using System;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Models;

public partial class DiseaseInformation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
