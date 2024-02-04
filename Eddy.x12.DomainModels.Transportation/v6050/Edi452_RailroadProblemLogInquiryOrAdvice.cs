using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Transportation.v6050._452;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi452_RailroadProblemLogInquiryOrAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGP_BeginningSegmentForProblemLogInquiryOrAdvice BeginningSegmentForProblemLogInquiryOrAdvice { get; set; } = new();
	[SectionPosition(3)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi452_RailroadProblemLogInquiryOrAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForProblemLogInquiryOrAdvice);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 999999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
