using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLR*s*8O*a*t";

		var expected = new CLR_CarLocationRoutingRequest()
		{
			IdentificationCodeQualifier = "s",
			IdentificationCode = "8O",
			IndustryCode = "a",
			ReferenceIdentification = "t",
		};

		var actual = Map.MapObject<CLR_CarLocationRoutingRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new CLR_CarLocationRoutingRequest();
		//Required fields
		subject.IdentificationCode = "8O";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8O", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CLR_CarLocationRoutingRequest();
		//Required fields
		subject.IdentificationCodeQualifier = "s";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
