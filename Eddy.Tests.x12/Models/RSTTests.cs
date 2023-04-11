using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RST*B*O";

		var expected = new RST_CarrierRestriction()
		{
			CarrierRestrictionCode = "B",
			Description = "O",
		};

		var actual = Map.MapObject<RST_CarrierRestriction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "O", false)]
	[InlineData("", "O", true)]
	[InlineData("B", "", true)]
	public void Validation_OnlyOneOfCarrierRestrictionCode(string carrierRestrictionCode, string description, bool isValidExpected)
	{
		var subject = new RST_CarrierRestriction();
		subject.CarrierRestrictionCode = carrierRestrictionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
