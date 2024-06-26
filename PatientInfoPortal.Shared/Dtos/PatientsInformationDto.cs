﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfoPortal.Shared.Dtos
{
    public class PatientsInformationDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public bool Epilepsy {  get; set; }
        public DiseaseInformationDto Disease { get; set; } = null!;
        public List<NcdDto> NCDs { get; set; } = null!;
        public List<AllergyDto> Allergies { get; set; } = null!;
        
    }

    public class PatientCreateDto 
    {
        public string PatientName { get; set; } = null!;
        public int DiseaseId { get; set; }
        public bool Epilepsy { get; set; }

        public List<int>? NcdIds { get; set; } = new List<int>();
        public List<int>? AllergyIds { get; set; } = new List<int>();
    }

    public class PatientUpdateDto : PatientCreateDto
    {
        public int PatientId { get; set; }
    }
}
