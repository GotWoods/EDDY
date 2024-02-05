using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v7060;

public class Edi102_AssociatedData {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ORI_ObjectReferenceIdentification ObjectReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<OOI_AssociatedObjectTypeIdentification> AssociatedObjectTypeIdentification { get; set; } = new();
	[SectionPosition(5)] public BDS_BinaryDataStructure BinaryDataStructure { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi102_AssociatedData>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ObjectReferenceIdentification);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AssociatedObjectTypeIdentification, 1, 2147483647);
		validator.Required(x => x.BinaryDataStructure);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
