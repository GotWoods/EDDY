using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LIN")]
public class LIN_ItemIdentification : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(05)]
	public string ProductServiceID2 { get; set; }

	[Position(06)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(07)]
	public string ProductServiceID3 { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(09)]
	public string ProductServiceID4 { get; set; }

	[Position(10)]
	public string ProductServiceIDQualifier5 { get; set; }

	[Position(11)]
	public string ProductServiceID5 { get; set; }

	[Position(12)]
	public string ProductServiceIDQualifier6 { get; set; }

	[Position(13)]
	public string ProductServiceID6 { get; set; }

	[Position(14)]
	public string ProductServiceIDQualifier7 { get; set; }

	[Position(15)]
	public string ProductServiceID7 { get; set; }

	[Position(16)]
	public string ProductServiceIDQualifier8 { get; set; }

	[Position(17)]
	public string ProductServiceID8 { get; set; }

	[Position(18)]
	public string ProductServiceIDQualifier9 { get; set; }

	[Position(19)]
	public string ProductServiceID9 { get; set; }

	[Position(20)]
	public string ProductServiceIDQualifier10 { get; set; }

	[Position(21)]
	public string ProductServiceID10 { get; set; }

	[Position(22)]
	public string ProductServiceIDQualifier11 { get; set; }

	[Position(23)]
	public string ProductServiceID11 { get; set; }

	[Position(24)]
	public string ProductServiceIDQualifier12 { get; set; }

	[Position(25)]
	public string ProductServiceID12 { get; set; }

	[Position(26)]
	public string ProductServiceIDQualifier13 { get; set; }

	[Position(27)]
	public string ProductServiceID13 { get; set; }

	[Position(28)]
	public string ProductServiceIDQualifier14 { get; set; }

	[Position(29)]
	public string ProductServiceID14 { get; set; }

	[Position(30)]
	public string ProductServiceIDQualifier15 { get; set; }

	[Position(31)]
	public string ProductServiceID15 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LIN_ItemIdentification>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier4, x=>x.ProductServiceID4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier5, x=>x.ProductServiceID5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier6, x=>x.ProductServiceID6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier7, x=>x.ProductServiceID7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier8, x=>x.ProductServiceID8);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier9, x=>x.ProductServiceID9);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier10, x=>x.ProductServiceID10);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier11, x=>x.ProductServiceID11);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier12, x=>x.ProductServiceID12);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier13, x=>x.ProductServiceID13);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier14, x=>x.ProductServiceID14);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier15, x=>x.ProductServiceID15);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier5, 2);
		validator.Length(x => x.ProductServiceID5, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier6, 2);
		validator.Length(x => x.ProductServiceID6, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier7, 2);
		validator.Length(x => x.ProductServiceID7, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier8, 2);
		validator.Length(x => x.ProductServiceID8, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier9, 2);
		validator.Length(x => x.ProductServiceID9, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier10, 2);
		validator.Length(x => x.ProductServiceID10, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier11, 2);
		validator.Length(x => x.ProductServiceID11, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier12, 2);
		validator.Length(x => x.ProductServiceID12, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier13, 2);
		validator.Length(x => x.ProductServiceID13, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier14, 2);
		validator.Length(x => x.ProductServiceID14, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier15, 2);
		validator.Length(x => x.ProductServiceID15, 1, 80);
		return validator.Results;
	}
}
