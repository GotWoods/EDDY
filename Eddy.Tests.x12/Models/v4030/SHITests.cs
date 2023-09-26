using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SHITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHI*o*P*X*Nn*ad";

		var expected = new SHI_SecurityHoldingInformation()
		{
			SecurityHoldingTypeCode = "o",
			Name = "P",
			ReferenceIdentification = "X",
			ProductTransferTypeCode = "Nn",
			StatusCode = "ad",
		};

		var actual = Map.MapObject<SHI_SecurityHoldingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredSecurityHoldingTypeCode(string securityHoldingTypeCode, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		//Test Parameters
		subject.SecurityHoldingTypeCode = securityHoldingTypeCode;
		//At Least one
		subject.Name = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "X", true)]
	[InlineData("P", "", true)]
	[InlineData("", "X", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		subject.SecurityHoldingTypeCode = "o";
		//Test Parameters
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
