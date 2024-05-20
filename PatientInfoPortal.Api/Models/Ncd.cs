using System;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Models;

public partial class Ncd
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
}
