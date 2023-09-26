using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class L7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7A*Q5*Gk6*Rd*u*p*q*sogfqQKS*vCHEgjiD";

		var expected = new L7A_ContractReferenceIdentifier()
		{
			ReferenceIdentificationQualifier = "Q5",
			RegulatoryAgencyCode = "Gk6",
			StandardCarrierAlphaCode = "Rd",
			IssuingCarrierIdentifier = "u",
			ContractNumber = "p",
			ContractSuffix = "q",
			Date = "sogfqQKS",
			Date2 = "vCHEgjiD",
		};

		var actual = Map.MapObject<L7A_ContractReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
