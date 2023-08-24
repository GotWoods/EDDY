using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*m*e*fy*M*8Eb0CA*Ah*Jl";

		var expected = new CSH_HeaderSaleCondition()
		{
			SalesRequirementCode = "m",
			DoNotExceedActionCode = "e",
			DoNotExceedAmount = "fy",
			AccountNumber = "M",
			RequiredInvoiceDate = "8Eb0CA",
			AssociationQualifierCode = "Ah",
			SpecialServicesCode = "Jl",
		};

		var actual = Map.MapObject<CSH_HeaderSaleCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
