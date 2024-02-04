using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Transportation.v6050._240;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi240_MotorCarrierPackageStatus {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<L1000> L1000 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<L2000> L2000 {get;set;} = new();

	//Summary
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi240_MotorCarrierPackageStatus>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.L1000, 1, 2147483647);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L2000, 1, 2147483647);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
