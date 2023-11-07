using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._830;

public class CodeInformation
{
    [SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; }
    [SectionPosition(2)] public List<LQ_IndustryCode> IndustryCodeIdentifications { get; set; }
}