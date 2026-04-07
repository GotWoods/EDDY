using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;
using Eddy.x12.DomainModels.Finance.v7050._195;

namespace Eddy.x12.DomainModels.Finance.v7050;

public class Edi195_FederalCommunicationsCommissionFCCLicenseApplication {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(5)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(6)] public List<LCRC> LCRC {get;set;} = new();
	[SectionPosition(7)] public List<LAMT> LAMT {get;set;} = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<LPO1> LPO1 {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi195_FederalCommunicationsCommissionFCCLicenseApplication>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Paperwork, 1, 2147483647);
		

		validator.CollectionSize(x => x.LCRC, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LCRC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LPO1, 1, 2147483647);
		foreach (var item in LPO1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
