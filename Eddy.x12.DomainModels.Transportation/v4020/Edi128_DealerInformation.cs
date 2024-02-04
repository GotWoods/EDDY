using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._128;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi128_DealerInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public N1_Name Name { get; set; } = new();
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<DN_DealerEffectivity> DealerEffectivity { get; set; } = new();
	[SectionPosition(7)] public List<R9_RouteCode> RouteCode { get; set; } = new();
	[SectionPosition(8)] public List<DH_DealerHours> DealerHours { get; set; } = new();
	[SectionPosition(9)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(10)] public K1_Remarks? Remarks { get; set; }
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi128_DealerInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 99);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.DealerEffectivity, 0, 7);
		validator.CollectionSize(x => x.RouteCode, 0, 50);
		validator.CollectionSize(x => x.DealerHours, 0, 28);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
