using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("T3")]
public class T3_TransitInboundRoute : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string RoutingSequenceCode { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string StandardPointLocationCode { get; set; }

	[Position(06)]
	public string EquipmentInitial { get; set; }

	[Position(07)]
	public string EquipmentNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<T3_TransitInboundRoute>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		return validator.Results;
	}
}
