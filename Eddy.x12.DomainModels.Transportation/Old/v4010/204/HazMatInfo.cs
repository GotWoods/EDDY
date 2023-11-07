using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._204;

public class HazMatInfo
{
    [SectionPosition(1)] public LH1_HazardousIdentificationInformation IdentificationInfo { get; set; }
    [SectionPosition(2)] public List<LH2_HazardousClassificationInformation> Classification { get; set; } = new();
    [SectionPosition(3)] public List<LH3_HazardousMaterialShippingName> ShippingName { get; set; } = new();
    [SectionPosition(4)] public List<LFH_FreeformHazardousMaterialInformation> FreeFormInfo { get; set; } = new();
    [SectionPosition(5)] public List<LEP_EPARequiredData> EpaData { get; set; } = new();
    [SectionPosition(6)] public LH4_CanadianDangerousRequirements CanadianRequierments { get; set; }
    [SectionPosition(7)] public List<LHT_TransborderHazardousRequirements> TransborderRequirements { get; set; } = new();
}