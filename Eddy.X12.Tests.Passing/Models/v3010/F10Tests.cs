using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F10*FeGeUb*e*E";

		var expected = new F10_IdentificationOfClaimTracer()
		{
			Date = "FeGeUb",
			ReferenceNumber = "e",
			ReferenceNumber2 = "E",
		};

		var actual = Map.MapObject<F10_IdentificationOfClaimTracer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FeGeUb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.ReferenceNumber = "e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "FeGeUb";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
