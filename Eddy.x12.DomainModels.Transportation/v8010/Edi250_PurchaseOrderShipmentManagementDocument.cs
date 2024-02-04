using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;
using Eddy.x12.DomainModels.Transportation.v8010._250;

namespace Eddy.x12.DomainModels.Transportation.v8010;

public class Edi250_PurchaseOrderShipmentManagementDocument {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<SSD_ShipmentSortSegregateData> ShipmentSortSegregateData { get; set; } = new();

	//Details
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi250_PurchaseOrderShipmentManagementDocument>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ShipmentSortSegregateData, 0, 999999);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 2147483647);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
