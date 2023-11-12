using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*7*F*ml*3*vudgQf*qR*cM";

		var expected = new CSH_HeaderSaleCondition()
		{
			SalesRequirementCode = "7",
			DoNotExceedActionCode = "F",
			DoNotExceedAmount = "ml",
			AccountNumber = "3",
			RequiredInvoiceDate = "vudgQf",
			AssociationQualifierCode = "qR",
			SpecialServicesCode = "cM",
		};

		var actual = Map.MapObject<CSH_HeaderSaleCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
