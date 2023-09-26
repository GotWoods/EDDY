using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("FU5")]
public class FU5_CoProductInformation : EdiX12Segment
{
	[Position(01)]
	public string CoProductTypeCode { get; set; }

	[Position(02)]
	public string ProductName { get; set; }

	[Position(03)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(06)]
	public string ProductServiceID2 { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(08)]
	public string ProductServiceID3 { get; set; }

	[Position(09)]
	public string BrandName { get; set; }

	[Position(10)]
	public string ProductLabel { get; set; }

	[Position(11)]
	public string Description { get; set; }

	[Position(12)]
	public string EntityIdentifierCode { get; set; }

	[Position(13)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FU5_CoProductInformation>(this);
		validator.Required(x=>x.CoProductTypeCode);
		validator.Required(x=>x.ProductName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EntityIdentifierCode, x=>x.Name);
		validator.Length(x => x.CoProductTypeCode, 2);
		validator.Length(x => x.ProductName, 1, 60);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.BrandName, 1, 60);
		validator.Length(x => x.ProductLabel, 1, 60);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
