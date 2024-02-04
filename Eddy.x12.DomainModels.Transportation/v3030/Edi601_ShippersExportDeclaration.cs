using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._601;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi601_ShippersExportDeclaration {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BA1_BeginningSegmentForShippersExportDeclaration BeginningSegmentForShippersExportDeclaration { get; set; } = new();
	[SectionPosition(3)] public V5_VesselCode? VesselCode { get; set; }
	[SectionPosition(4)] public DTM_DateTimeReference DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<P5_PortInformation> PortInformation { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(7)] public List<L13_CommodityDetails> CommodityDetails { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi601_ShippersExportDeclaration>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShippersExportDeclaration);
		validator.Required(x => x.DateTimeReference);
		validator.CollectionSize(x => x.PortInformation, 1, 2);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 9);
		validator.CollectionSize(x => x.CommodityDetails, 1, 999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
