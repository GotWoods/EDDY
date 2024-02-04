using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Transportation.v8030._436;

namespace Eddy.x12.DomainModels.Transportation.v8030;

public class Edi436_LocomotiveInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public LFI_BeginningSegmentForLocomotiveInformation BeginningSegmentForLocomotiveInformation { get; set; } = new();
	[SectionPosition(3)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(4)] public List<K3_FileInformation> FileInformation { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi436_LocomotiveInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForLocomotiveInformation);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.FileInformation, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
