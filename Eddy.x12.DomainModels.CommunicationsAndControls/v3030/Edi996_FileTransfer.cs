using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3030;

public class Edi996_FileTransfer {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGF_BeginningSegmentForFileTransferInformation BeginningSegmentForFileTransferInformation { get; set; } = new();
	[SectionPosition(3)] public List<K3_FileInformation> FileInformation { get; set; } = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi996_FileTransfer>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForFileTransferInformation);
		validator.CollectionSize(x => x.FileInformation, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
