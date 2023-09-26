using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SIN*H*aN*V*b*8*";

		var expected = new SIN_SubstanceUse()
		{
			InformationStatusCode = "H",
			ControlledSubstanceTypeCode = "aN",
			FreeFormMessageText = "V",
			FrequencyCode = "b",
			Quantity = 8,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<SIN_SubstanceUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredInformationStatusCode(string informationStatusCode, bool isValidExpected)
	{
		var subject = new SIN_SubstanceUse();
		//Required fields
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		//At Least one
		subject.ControlledSubstanceTypeCode = "aN";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("aN", "V", true)]
	[InlineData("aN", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneControlledSubstanceTypeCode(string controlledSubstanceTypeCode, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new SIN_SubstanceUse();
		//Required fields
		subject.InformationStatusCode = "H";
		//Test Parameters
		subject.ControlledSubstanceTypeCode = controlledSubstanceTypeCode;
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
