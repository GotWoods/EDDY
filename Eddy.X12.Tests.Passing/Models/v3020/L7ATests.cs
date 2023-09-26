using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7A*7A*G2r*9G*Bqn*j*7";

		var expected = new L7A_ContractReferenceIdentifier()
		{
			ReferenceNumberQualifier = "7A",
			RegulatoryAgencyCode = "G2r",
			StandardCarrierAlphaCode = "9G",
			IssuingCarrierIdentifier = "Bqn",
			ContractNumber = "j",
			ContractSuffix = "7",
		};

		var actual = Map.MapObject<L7A_ContractReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
