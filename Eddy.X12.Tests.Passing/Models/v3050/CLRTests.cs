using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLR*1*Hc*0*2";

		var expected = new CLR_CarLocationRoutingRequest()
		{
			IdentificationCodeQualifier = "1",
			IdentificationCode = "Hc",
			IndustryCode = "0",
			ReferenceNumber = "2",
		};

		var actual = Map.MapObject<CLR_CarLocationRoutingRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new CLR_CarLocationRoutingRequest();
		//Required fields
		subject.IdentificationCode = "Hc";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hc", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CLR_CarLocationRoutingRequest();
		//Required fields
		subject.IdentificationCodeQualifier = "1";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
