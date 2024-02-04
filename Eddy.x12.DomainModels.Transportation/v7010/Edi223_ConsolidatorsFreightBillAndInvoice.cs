using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Transportation.v7010._223;

namespace Eddy.x12.DomainModels.Transportation.v7010;

public class Edi223_ConsolidatorsFreightBillAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage? BeginningSegmentForTransportationCarrierShipmentStatusMessage { get; set; }
	[SectionPosition(3)] public B3A_InvoiceType InvoiceType { get; set; } = new();
	[SectionPosition(4)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(7)] public List<L4000> L4000 {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi223_ConsolidatorsFreightBillAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.InvoiceType);
		validator.Required(x => x.SetPurpose);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L4000, 0, 9999);
		foreach (var item in L4000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
