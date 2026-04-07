using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._155;

public class L20000__L23000__L23500__L23530_L23531 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500__L23530_L23531>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 2147483647);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 0, 3);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		return validator.Results;
	}
}
