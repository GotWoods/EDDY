using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TF*R*A*Q*y";

		var expected = new TF_TariffInformation()
		{
			TariffAgencyCode = "R",
			TariffNumber = "A",
			TariffNumberSuffix = "Q",
			TariffSupplementIdentifier = "y",
		};

		var actual = Map.MapObject<TF_TariffInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new TF_TariffInformation();
		subject.TariffNumber = "A";
		subject.TariffAgencyCode = tariffAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new TF_TariffInformation();
		subject.TariffAgencyCode = "R";
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
