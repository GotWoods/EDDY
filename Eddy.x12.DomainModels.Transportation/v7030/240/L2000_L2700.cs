using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._240;

public class L2000_L2700 {
	[SectionPosition(1)] public L11_BusinessInstructionsAndReferenceNumber BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(2)] public List<MS2_EquipmentOrContainerOwnerAndType> EquipmentOrContainerOwnerAndType { get; set; } = new();
	[SectionPosition(3)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(4)] public List<L2000__L2700_L2710> L2710 {get;set;} = new();
	[SectionPosition(5)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(6)] public List<L2000__L2700_L2720> L2720 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2700>(this);
		validator.Required(x => x.BusinessInstructionsAndReferenceNumber);
		validator.CollectionSize(x => x.EquipmentOrContainerOwnerAndType, 1, 2147483647);
		validator.CollectionSize(x => x.L2710, 1, 2147483647);
		foreach (var item in L2710) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2720) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
