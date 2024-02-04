using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._453;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi453_RailroadServiceCommitmentAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public SSC_BeginningSegmentForServiceCommitmentAdvice BeginningSegmentForServiceCommitmentAdvice { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(5)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(6)] public OD_OriginAndDestination? OriginAndDestination { get; set; }
	[SectionPosition(7)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(8)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(9)] public List<CT_CarType> CarType { get; set; } = new();
	[SectionPosition(10)] public List<APR_AssociationOfAmericanRailroadsPoolCodeRestrictions> AssociationOfAmericanRailroadsPoolCodeRestrictions { get; set; } = new();
	[SectionPosition(11)] public List<SHR_RailroadInterlineServiceSpecialHandlingRestrictions> RailroadInterlineServiceSpecialHandlingRestrictions { get; set; } = new();
	[SectionPosition(12)] public List<LSR> LSR {get;set;} = new();
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi453_RailroadServiceCommitmentAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForServiceCommitmentAdvice);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2);
		validator.CollectionSize(x => x.Name, 0, 999999);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 10);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.CarType, 0, 99);
		validator.CollectionSize(x => x.AssociationOfAmericanRailroadsPoolCodeRestrictions, 0, 99);
		validator.CollectionSize(x => x.RailroadInterlineServiceSpecialHandlingRestrictions, 0, 99);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LSR, 0, 7);
		foreach (var item in LSR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
