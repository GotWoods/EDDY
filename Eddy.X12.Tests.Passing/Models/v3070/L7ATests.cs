using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class L7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7A*Dj*FSs*KG*n*u*b*9D05LG*wAH1io";

		var expected = new L7A_ContractReferenceIdentifier()
		{
			ReferenceIdentificationQualifier = "Dj",
			RegulatoryAgencyCode = "FSs",
			StandardCarrierAlphaCode = "KG",
			IssuingCarrierIdentifier = "n",
			ContractNumber = "u",
			ContractSuffix = "b",
			Date = "9D05LG",
			Date2 = "wAH1io",
		};

		var actual = Map.MapObject<L7A_ContractReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
