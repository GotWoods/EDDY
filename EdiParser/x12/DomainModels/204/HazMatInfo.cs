using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class HazMatInfo
{
    public LH1_HazardousIdentificationInformation IdentificationInfo { get; set; }
    public List<LH2_HazardousClassificationInformation> Classiciation { get; set; } = new();
    public List<LH3_HazardousMaterialShippingNameInformation> ShippingName { get; set; } = new();
    public List<LFH_FreeFormHazardousMaterialInformation> FreeFormInfo { get; set; } = new();
    public List<LEP_EPARequiredData> EpaData { get; set; } = new();
    public LH4_CanadianDangerousRequirements CanadianRequierments { get; set; }
    public List<LHT_TransborderHazardousRequirements> TransborderRequirements { get; set; } = new();
}