using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Transportation.v6030._108;

namespace Eddy.x12.DomainModels.Transportation.v6030;

public class Edi108_ResponseToAMotorCarrierRateProposal {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(4)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi108_ResponseToAMotorCarrierRateProposal>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransportationCarrierIdentification);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 10);
		validator.CollectionSize(x => x.L0200, 1, 99999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
