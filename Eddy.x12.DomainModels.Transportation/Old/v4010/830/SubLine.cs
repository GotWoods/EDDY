using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._830;

public class SubLine
{
    [SectionPosition(1)] public SLN_SublineItemDetail Detail { get; set; }
    [SectionPosition(2)] public List<PID_ProductItemDescription> ProductItemDescriptions { get; set; } = new();
    [SectionPosition(3)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalNames{ get; set; } = new();
}