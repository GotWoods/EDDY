using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.IFTSTA;

public class SegmentGroup14__SegmentGroup15_SegmentGroup16 {
	[SectionPosition(1)] public EFI_ExternalFileLinkIdentification ExternalFileLinkIdentification { get; set; } = new();
	[SectionPosition(2)] public List<CED_ComputerEnvironmentDetails> ComputerEnvironmentDetails { get; set; } = new();
	[SectionPosition(3)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(4)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14__SegmentGroup15_SegmentGroup16>(this);
		validator.Required(x => x.ExternalFileLinkIdentification);
		validator.CollectionSize(x => x.ComputerEnvironmentDetails, 1, 99);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		return validator.Results;
	}
}
