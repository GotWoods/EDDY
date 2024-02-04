using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Transportation.v5020._286;

namespace Eddy.x12.DomainModels.Transportation.v5020;

public class Edi286_CommercialVehicleCredentials {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<LNM1> LNM1 {get;set;} = new();

	//Details
	[SectionPosition(5)] public List<LSPI> LSPI {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi286_CommercialVehicleCredentials>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LSPI, 1, 2147483647);
		foreach (var item in LSPI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
