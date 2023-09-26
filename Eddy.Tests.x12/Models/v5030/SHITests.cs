using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SHITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHI*p*E*T*LX*Ip";

		var expected = new SHI_SecurityHoldingInformation()
		{
			SecurityHoldingTypeCode = "p",
			Name = "E",
			ReferenceIdentification = "T",
			ProductTransferTypeCode = "LX",
			StatusCode = "Ip",
		};

		var actual = Map.MapObject<SHI_SecurityHoldingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSecurityHoldingTypeCode(string securityHoldingTypeCode, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		//Test Parameters
		subject.SecurityHoldingTypeCode = securityHoldingTypeCode;
		//At Least one
		subject.Name = "E";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("E", "T", true)]
	[InlineData("E", "", true)]
	[InlineData("", "T", true)]
	public void Validation_AtLeastOneName(string name, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHI_SecurityHoldingInformation();
		//Required fields
		subject.SecurityHoldingTypeCode = "p";
		//Test Parameters
		subject.Name = name;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
