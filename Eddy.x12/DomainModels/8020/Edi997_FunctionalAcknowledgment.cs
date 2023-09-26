using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._8020._997;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels._8020;

public class Edi997_FunctionalAcknowledgment
{
    [SectionPosition(1)]
    public AK1_FunctionalGroupResponseHeader FunctionalGroupResponseHeader { get; set; }

    [SectionPosition(2)]
    public List<TransactionSetResponseHeader> TransactionSetResponses { get; set; } = new();

    [SectionPosition(3)]
    public AK9_FunctionalGroupResponseTrailer FunctionalGroupResponseTrailer { get; set; }

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "997";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }

}