using System;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Models;

public partial class AllergiesDetail
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int AllergiesId { get; set; }

    public virtual Allergy Allergies { get; set; } = null!;

    public virtual PatientsInformation Patient { get; set; } = null!;
}
