using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi319_TerminalInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BA2_BeginningSegmentForCargoTerminalInformation BeginningSegmentForCargoTerminalInformation { get; set; } = new();
	[SectionPosition(3)] public List<CD1_CargoDetail> CargoDetail { get; set; } = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi319_TerminalInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCargoTerminalInformation);
		validator.CollectionSize(x => x.CargoDetail, 1, 999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
