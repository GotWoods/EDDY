using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;
using Eddy.x12.DomainModels.CommunicationsAndControls.v4040._993;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4040;

public class Edi993_SecuredReceiptOrAcknowledgment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public AK1_FunctionalGroupResponseHeader FunctionalGroupResponseHeader { get; set; } = new();
	[SectionPosition(3)] public AK2_TransactionSetResponseHeader? TransactionSetResponseHeader { get; set; }
	[SectionPosition(4)] public SPE_SecurityProtocolError? SecurityProtocolError { get; set; }
	[SectionPosition(5)] public APE_AssuranceProtocolError? AssuranceProtocolError { get; set; }
	[SectionPosition(6)] public List<LS4A> LS4A {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi993_SecuredReceiptOrAcknowledgment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.FunctionalGroupResponseHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LS4A, 0, 2);
		foreach (var item in LS4A) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
