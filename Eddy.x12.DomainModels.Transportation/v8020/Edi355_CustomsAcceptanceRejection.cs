using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._355;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi355_CustomsAcceptanceRejection {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(4)] public List<LVEH> LVEH {get;set;} = new();
	[SectionPosition(5)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(6)] public List<LP4> LP4 {get;set;} = new();

	//Details
	[SectionPosition(7)] public K3_FileInformation FileInformation { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi355_CustomsAcceptanceRejection>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.LNM1, 0, 999);
		validator.CollectionSize(x => x.LP4, 1, 20);
		foreach (var item in LVEH) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LP4) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.FileInformation);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
