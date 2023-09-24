using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SIN*3*ca*C*b*3*";

		var expected = new SIN_SubstanceUse()
		{
			InformationStatusCode = "3",
			ControlledSubstanceTypeCode = "ca",
			FreeFormMessageText = "C",
			FrequencyCode = "b",
			Quantity = 3,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<SIN_SubstanceUse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredInformationStatusCode(string informationStatusCode, bool isValidExpected)
	{
		var subject = new SIN_SubstanceUse();
		subject.InformationStatusCode = informationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("ca","C", true)]
	[InlineData("", "C", true)]
	[InlineData("ca", "", true)]
	public void Validation_AtLeastOneControlledSubstanceTypeCode(string controlledSubstanceTypeCode, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new SIN_SubstanceUse();
		subject.InformationStatusCode = "3";
		subject.ControlledSubstanceTypeCode = controlledSubstanceTypeCode;
		subject.FreeFormMessageText = freeFormMessageText;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
