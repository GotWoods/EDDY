using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L7A*j4*jXi*Mf*x*M*j*xQ4Rfy*l0ifyl";

		var expected = new L7A_ContractReferenceIdentifier()
		{
			ReferenceNumberQualifier = "j4",
			RegulatoryAgencyCode = "jXi",
			StandardCarrierAlphaCode = "Mf",
			IssuingCarrierIdentifier = "x",
			ContractNumber = "M",
			ContractSuffix = "j",
			Date = "xQ4Rfy",
			Date2 = "l0ifyl",
		};

		var actual = Map.MapObject<L7A_ContractReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
