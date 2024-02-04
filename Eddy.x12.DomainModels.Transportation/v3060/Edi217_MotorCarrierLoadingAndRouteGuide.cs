using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._217;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi217_MotorCarrierLoadingAndRouteGuide {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BLR_TransportationCarrierIdentification TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(3)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(4)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(5)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(6)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(7)] public List<L0300> L0300 {get;set;} = new();

	//Summary
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi217_MotorCarrierLoadingAndRouteGuide>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransportationCarrierIdentification);
		

		validator.CollectionSize(x => x.L0100, 0, 999999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0200, 0, 999999);
		validator.CollectionSize(x => x.L0300, 0, 999999);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
