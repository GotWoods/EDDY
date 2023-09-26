using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class PSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSG*XL*k*V";

		var expected = new PSG_ProgramSpend()
		{
			SpendTypeCode = "XL",
			Description = "k",
			YesNoConditionOrResponseCode = "V",
		};

		var actual = Map.MapObject<PSG_ProgramSpend>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("XL", "k", true)]
	[InlineData("XL", "", true)]
	[InlineData("", "k", true)]
	public void Validation_AtLeastOneSpendTypeCode(string spendTypeCode, string description, bool isValidExpected)
	{
		var subject = new PSG_ProgramSpend();
		//Required fields
		//Test Parameters
		subject.SpendTypeCode = spendTypeCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
