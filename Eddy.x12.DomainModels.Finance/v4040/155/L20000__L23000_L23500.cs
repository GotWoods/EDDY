using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._155;

public class L20000__L23000_L23500 {
	[SectionPosition(1)] public API_ActivityOrProcessInformation ActivityOrProcessInformation { get; set; } = new();
	[SectionPosition(2)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public CDS_CaseDescription? CaseDescription { get; set; }
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<BBC_LegalClaims> LegalClaims { get; set; } = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<ASO_AssetOwnership> AssetOwnership { get; set; } = new();
	[SectionPosition(9)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(10)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(11)] public List<L20000__L23000__L23500_L23510> L23510 {get;set;} = new();
	[SectionPosition(12)] public List<L20000__L23000__L23500_L23520> L23520 {get;set;} = new();
	[SectionPosition(13)] public List<L20000__L23000__L23500_L23530> L23530 {get;set;} = new();
	[SectionPosition(14)] public List<L20000__L23000__L23500_L23540> L23540 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000_L23500>(this);
		validator.Required(x => x.ActivityOrProcessInformation);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LegalClaims, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.AssetOwnership, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.L23510, 1, 2147483647);
		validator.CollectionSize(x => x.L23520, 1, 2147483647);
		validator.CollectionSize(x => x.L23530, 1, 2147483647);
		validator.CollectionSize(x => x.L23540, 1, 2147483647);
		foreach (var item in L23510) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23520) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23530) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23540) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
