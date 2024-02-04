using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060;

public class Edi924_LossOrDamageClaimMotorVehicle {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public F01_IdentificationOfClaimClaimantOriginated IdentificationOfClaimClaimantOriginated { get; set; } = new();
	[SectionPosition(3)] public F6X_IdentificationAutomotive IdentificationAutomotive { get; set; } = new();
	[SectionPosition(4)] public F02_IdentificationOfShipment? IdentificationOfShipment { get; set; }
	[SectionPosition(5)] public F12_BasicClaimInformationAutomotive? BasicClaimInformationAutomotive { get; set; }
	[SectionPosition(6)] public List<F07_AutoClaimDetail> AutoClaimDetail { get; set; } = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi924_LossOrDamageClaimMotorVehicle>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.IdentificationOfClaimClaimantOriginated);
		validator.Required(x => x.IdentificationAutomotive);
		validator.CollectionSize(x => x.AutoClaimDetail, 1, 99);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
