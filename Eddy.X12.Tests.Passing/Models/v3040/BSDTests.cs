using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*YT*g*y*H*M*SH*Xr*eM";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceNumberQualifier = "YT",
			ReferenceNumber = "g",
			Description = "y",
			Level = "H",
			ReferenceNumber2 = "M",
			BreakdownStructureDetailCode = "SH",
			ProgramTypeCode = "Xr",
			SecurityLevelCode = "eM",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YT", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//At Least one
		subject.ReferenceNumber = "g";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("g", "y", true)]
	[InlineData("g", "", true)]
	[InlineData("", "y", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceNumberQualifier = "YT";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
