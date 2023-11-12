using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SHITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHI*Q*e*X*Wc*Pi";

		var expected = new SHI_SecurityHoldingInformation()
		{
			SecurityHoldingTypeCode = "Q",
			Name = "e",
			ReferenceIdentification = "X",
			ProductTransferTypeCode = "Wc",
			StatusCode = "Pi",
		};

		var actual = Map.MapObject<SHI_SecurityHoldingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredSecurityHoldingTypeCode(string securityHoldingTypeCode, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		//Test Parameters
		subject.SecurityHoldingTypeCode = securityHoldingTypeCode;
		//At Least one
		subject.Name = "e";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("e", "X", true)]
	[InlineData("e", "", true)]
	[InlineData("", "X", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		subject.SecurityHoldingTypeCode = "Q";
		//Test Parameters
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
