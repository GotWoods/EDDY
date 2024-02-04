using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._423;

namespace Eddy.x12.DomainModels.Transportation.v4010;

public class Edi423_RailIndustrialSwitchList {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public N1_Name Name { get; set; } = new();
	[SectionPosition(4)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(5)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(8)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi423_RailIndustrialSwitchList>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.DateTimeReference);
		validator.Required(x => x.Name);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 150);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
