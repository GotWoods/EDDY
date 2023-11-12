using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("FK")]
public class FK_Factor : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string Rule260JunctionCode { get; set; }

	[Position(06)]
	public string PercentageDivision { get; set; }

	[Position(07)]
	public decimal? FactorAmount { get; set; }

	[Position(08)]
	public decimal? FactorAmount2 { get; set; }

	[Position(09)]
	public decimal? FactorAmount3 { get; set; }

	[Position(10)]
	public decimal? FactorAmount4 { get; set; }

	[Position(11)]
	public decimal? FactorAmount5 { get; set; }

	[Position(12)]
	public decimal? FactorAmount6 { get; set; }

	[Position(13)]
	public decimal? FactorAmount7 { get; set; }

	[Position(14)]
	public decimal? FactorAmount8 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FK_Factor>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.OnlyOneOf(x=>x.StateOrProvinceCode, x=>x.Rule260JunctionCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.PercentageDivision, 1, 5);
		validator.Length(x => x.FactorAmount, 1, 15);
		validator.Length(x => x.FactorAmount2, 1, 15);
		validator.Length(x => x.FactorAmount3, 1, 15);
		validator.Length(x => x.FactorAmount4, 1, 15);
		validator.Length(x => x.FactorAmount5, 1, 15);
		validator.Length(x => x.FactorAmount6, 1, 15);
		validator.Length(x => x.FactorAmount7, 1, 15);
		validator.Length(x => x.FactorAmount8, 1, 15);
		return validator.Results;
	}
}
