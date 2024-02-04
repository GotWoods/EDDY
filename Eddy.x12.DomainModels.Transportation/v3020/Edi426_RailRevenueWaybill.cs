using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._426;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi426_RailRevenueWaybill {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZR_WaybillReferenceIdentification WaybillReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(4)] public BX_GeneralShipmentInformation? GeneralShipmentInformation { get; set; }
	[SectionPosition(5)] public List<LBNX> LBNX {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer? TransactionSetTrailer { get; set; }

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi426_RailRevenueWaybill>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.WaybillReferenceIdentification);
		foreach (var item in LBNX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
