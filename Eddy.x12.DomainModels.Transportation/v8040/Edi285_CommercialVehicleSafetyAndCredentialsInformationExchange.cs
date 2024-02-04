using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;
using Eddy.x12.DomainModels.Transportation.v8040._285;

namespace Eddy.x12.DomainModels.Transportation.v8040;

public class Edi285_CommercialVehicleSafetyAndCredentialsInformationExchange {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();

	//Details
	[SectionPosition(4)] public List<LNX1> LNX1 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi285_CommercialVehicleSafetyAndCredentialsInformationExchange>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
