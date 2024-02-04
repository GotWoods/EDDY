using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Transportation.v5030._160;

namespace Eddy.x12.DomainModels.Transportation.v5030;

public class Edi160_TransportationAutomaticEquipmentIdentification {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID { get; set; } = new();
	[SectionPosition(3)] public AES_AutomaticEquipmentIdentificationSiteInformation AutomaticEquipmentIdentificationSiteInformation { get; set; } = new();
	[SectionPosition(4)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<AEI_EquipmentInformationSummary> EquipmentInformationSummary { get; set; } = new();
	[SectionPosition(9)] public List<LEI> LEI {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi160_TransportationAutomaticEquipmentIdentification>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID);
		validator.Required(x => x.AutomaticEquipmentIdentificationSiteInformation);
		validator.Required(x => x.YesNoQuestion);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.EquipmentInformationSummary, 0, 16);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LEI, 1, 500);
		foreach (var item in LEI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
