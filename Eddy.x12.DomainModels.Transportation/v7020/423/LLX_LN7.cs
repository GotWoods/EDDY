using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._423;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<XD_PlacementPullData> PlacementPullData { get; set; } = new();
	[SectionPosition(5)] public R2_RouteInformation? RouteInformation { get; set; }
	[SectionPosition(6)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(9)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(10)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(11)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(12)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(13)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(14)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(15)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(16)] public List<LLX__LN7_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.PlacementPullData, 0, 5);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 2);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.QuantityInformation, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 1000);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
