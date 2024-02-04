using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._418;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi418_RailAdvanceInterchangeConsist {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID { get; set; } = new();
	[SectionPosition(3)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(4)] public List<LW1> LW1 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi418_RailAdvanceInterchangeConsist>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNM1, 0, 999);
		validator.CollectionSize(x => x.LW1, 0, 30);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LW1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
