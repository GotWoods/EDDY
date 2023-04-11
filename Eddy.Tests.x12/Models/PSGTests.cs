using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSG*9Z*y*H";

		var expected = new PSG_ProgramSpend()
		{
			SpendTypeCode = "9Z",
			Description = "y",
			YesNoConditionOrResponseCode = "H",
		};

		var actual = Map.MapObject<PSG_ProgramSpend>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("9Z","y", true)]
	[InlineData("", "y", true)]
	[InlineData("9Z", "", true)]
	public void Validation_AtLeastOneSpendTypeCode(string spendTypeCode, string description, bool isValidExpected)
	{
		var subject = new PSG_ProgramSpend();
		subject.SpendTypeCode = spendTypeCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
