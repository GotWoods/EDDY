using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010._830;

public class CodeInformation
{
    [SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; }
    [SectionPosition(2)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentifications { get; set; }
}