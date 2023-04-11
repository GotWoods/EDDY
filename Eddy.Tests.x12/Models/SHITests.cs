using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SHITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHI*I*U*T*zY*uF";

		var expected = new SHI_SecurityHoldingInformation()
		{
			SecurityHoldingTypeCode = "I",
			Name = "U",
			ReferenceIdentification = "T",
			ProductTransferTypeCode = "zY",
			StatusCode = "uF",
		};

		var actual = Map.MapObject<SHI_SecurityHoldingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredSecurityHoldingTypeCode(string securityHoldingTypeCode, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		subject.SecurityHoldingTypeCode = securityHoldingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("U","T", true)]
	[InlineData("", "T", true)]
	[InlineData("U", "", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		subject.SecurityHoldingTypeCode = "I";
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
