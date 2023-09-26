using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*Ki*x*Ys*o59*Hm*l*n*f*S*B*E*v22fJW*4I713m";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceNumberQualifier = "Ki",
			ReferenceNumber = "x",
			ReferenceUsageCode = "Ys",
			RegulatoryAgencyCode = "o59",
			StandardCarrierAlphaCode = "Hm",
			IssuingCarrierIdentifier = "l",
			ContractSuffix = "n",
			TariffItemNumber = "f",
			TariffSupplementIdentifier = "S",
			TariffSection = "B",
			ContractSuffix2 = "E",
			Date = "v22fJW",
			Date2 = "4I713m",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ki", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceNumber = "x";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceNumberQualifier = "Ki";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
