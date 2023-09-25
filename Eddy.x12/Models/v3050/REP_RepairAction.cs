using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("REP")]
public class REP_RepairAction : EdiX12Segment
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
	public string AgencyQualifierCode { get; set; }

	[Position(07)]
	public string SourceSubqualifier { get; set; }

	[Position(08)]
	public string RepairActionCode { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string AgencyQualifierCode2 { get; set; }

	[Position(11)]
	public string SourceSubqualifier2 { get; set; }

	[Position(12)]
	public string RepairComplexityCode { get; set; }

	[Position(13)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(14)]
	public string ProductServiceID3 { get; set; }

	[Position(15)]
	public string RepairActionCode2 { get; set; }

	[Position(16)]
	public string Description2 { get; set; }

	[Position(17)]
	public string AgencyQualifierCode3 { get; set; }

	[Position(18)]
	public string SourceSubqualifier3 { get; set; }

	[Position(19)]
	public string ReferenceNumber { get; set; }

	[Position(20)]
	public string AuthorizationIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REP_RepairAction>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.ARequiresB(x=>x.ProductServiceID2, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.RepairActionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.AgencyQualifierCode2, x=>x.RepairComplexityCode);
		validator.ARequiresB(x=>x.SourceSubqualifier2, x=>x.AgencyQualifierCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ProductServiceID3, x=>x.RepairActionCode2, x=>x.Description2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RepairActionCode2, x=>x.ProductServiceID3);
		validator.ARequiresB(x=>x.AgencyQualifierCode3, x=>x.ReferenceNumber);
		validator.ARequiresB(x=>x.SourceSubqualifier3, x=>x.AgencyQualifierCode3);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.RepairActionCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.AgencyQualifierCode2, 2);
		validator.Length(x => x.SourceSubqualifier2, 1, 15);
		validator.Length(x => x.RepairComplexityCode, 1, 3);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 40);
		validator.Length(x => x.RepairActionCode2, 1, 4);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.AgencyQualifierCode3, 2);
		validator.Length(x => x.SourceSubqualifier3, 1, 15);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.AuthorizationIdentification, 1, 4);
		return validator.Results;
	}
}
