using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._423;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public XD_PlacementPullData? PlacementPullData { get; set; }
	[SectionPosition(3)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	[SectionPosition(4)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(6)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(9)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(10)] public List<LLX__LN7_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 2);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
