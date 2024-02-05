using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3060._868;

public class LE40 {
	[SectionPosition(1)] public E40_EDIStandardsNoteReference EDIStandardsNoteReference { get; set; } = new();
	[SectionPosition(2)] public List<DMI_DataMaintenanceInformation> DataMaintenanceInformation { get; set; } = new();
	[SectionPosition(3)] public List<DDI_Description> Description { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE40>(this);
		validator.Required(x => x.EDIStandardsNoteReference);
		validator.CollectionSize(x => x.DataMaintenanceInformation, 0, 100);
		validator.CollectionSize(x => x.Description, 0, 1000);
		return validator.Results;
	}
}
