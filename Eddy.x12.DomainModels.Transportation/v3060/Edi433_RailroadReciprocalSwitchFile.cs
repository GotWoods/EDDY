using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._433;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi433_RailroadReciprocalSwitchFile {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public N1_Name Name { get; set; } = new();
	[SectionPosition(4)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(5)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public List<LSMS> LSMS {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi433_RailroadReciprocalSwitchFile>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LSMS, 1, 4);
		foreach (var item in LSMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
