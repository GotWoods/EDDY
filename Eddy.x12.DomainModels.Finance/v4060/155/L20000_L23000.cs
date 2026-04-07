using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._155;

public class L20000_L23000 {
	[SectionPosition(1)] public INR_InformationRequest InformationRequest { get; set; } = new();
	[SectionPosition(2)] public NX1_PropertyOrEntityIdentification? PropertyOrEntityIdentification { get; set; }
	[SectionPosition(3)] public List<ITC_InformationTypeAndCommentResults> InformationTypeAndCommentResults { get; set; } = new();
	[SectionPosition(4)] public C3_Currency? CurrencyIdentifier { get; set; }
	[SectionPosition(5)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(6)] public List<ASO_AssetOwnership> AssetOwnership { get; set; } = new();
	[SectionPosition(7)] public List<SPR_SupplierRating> SupplierRating { get; set; } = new();
	[SectionPosition(8)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(9)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(10)] public List<TER_Territory> Territory { get; set; } = new();
	[SectionPosition(11)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(12)] public ASI_ActionOrStatusIndicator? ActionOrStatusIndicator { get; set; }
	[SectionPosition(13)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(14)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(15)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(16)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(17)] public List<L20000__L23000_L23100> L23100 {get;set;} = new();
	[SectionPosition(18)] public List<L20000__L23000_L23200> L23200 {get;set;} = new();
	[SectionPosition(19)] public List<L20000__L23000_L23300> L23300 {get;set;} = new();
	[SectionPosition(20)] public List<L20000__L23000_L23400> L23400 {get;set;} = new();
	[SectionPosition(21)] public List<L20000__L23000_L23500> L23500 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000_L23000>(this);
		validator.Required(x => x.InformationRequest);
		validator.CollectionSize(x => x.InformationTypeAndCommentResults, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AssetOwnership, 1, 2147483647);
		validator.CollectionSize(x => x.SupplierRating, 1, 2147483647);
		validator.CollectionSize(x => x.Territory, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.L23100, 1, 2147483647);
		validator.CollectionSize(x => x.L23200, 1, 2147483647);
		validator.CollectionSize(x => x.L23300, 1, 2147483647);
		validator.CollectionSize(x => x.L23400, 1, 2147483647);
		validator.CollectionSize(x => x.L23500, 1, 2147483647);
		foreach (var item in L23100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23400) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23500) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
