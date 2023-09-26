using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class L7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7A*fN*7BN*uy*G*B*7*bEB5Qr*9PwISK";

		var expected = new L7A_ContractReferenceIdentifier()
		{
			ReferenceIdentificationQualifier = "fN",
			RegulatoryAgencyCode = "7BN",
			StandardCarrierAlphaCode = "uy",
			IssuingCarrierIdentifier = "G",
			ContractNumber = "B",
			ContractSuffix = "7",
			Date = "bEB5Qr",
			Date2 = "9PwISK",
		};

		var actual = Map.MapObject<L7A_ContractReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
