using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020;

public class Edi131_StudentEducationalRecordTranscriptAcknowledgment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(6)] public SUM_AcademicSummary? AcademicSummary { get; set; }
	[SectionPosition(7)] public IN2_IndividualNameStructureComponents IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi131_StudentEducationalRecordTranscriptAcknowledgment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2);
		validator.Required(x => x.IndividualNameStructureComponents);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
