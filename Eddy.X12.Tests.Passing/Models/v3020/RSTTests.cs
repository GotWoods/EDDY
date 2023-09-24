using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RST*S*F";

		var expected = new RST_CarrierRestriction()
		{
			CarrierRestrictionCode = "S",
			Description = "F",
		};

		var actual = Map.MapObject<RST_CarrierRestriction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "F", false)]
	[InlineData("S", "", true)]
	[InlineData("", "F", true)]
	public void Validation_OnlyOneOfCarrierRestrictionCode(string carrierRestrictionCode, string description, bool isValidExpected)
	{
		var subject = new RST_CarrierRestriction();
		subject.CarrierRestrictionCode = carrierRestrictionCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
