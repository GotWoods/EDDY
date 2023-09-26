using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class ITSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITS*Q5*q*m3*O";

		var expected = new ITS_ItemSelection()
		{
			ItemSelectionTypeCode = "Q5",
			Description = "q",
			ItemSelectionTypeCode2 = "m3",
			Description2 = "O",
		};

		var actual = Map.MapObject<ITS_ItemSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q5", true)]
	public void Validation_RequiredItemSelectionTypeCode(string itemSelectionTypeCode, bool isValidExpected)
	{
		var subject = new ITS_ItemSelection();
		//Required fields
		//Test Parameters
		subject.ItemSelectionTypeCode = itemSelectionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "m3", true)]
	[InlineData("O", "", false)]
	[InlineData("", "m3", true)]
	public void Validation_ARequiresBDescription2(string description2, string itemSelectionTypeCode2, bool isValidExpected)
	{
		var subject = new ITS_ItemSelection();
		//Required fields
		subject.ItemSelectionTypeCode = "Q5";
		//Test Parameters
		subject.Description2 = description2;
		subject.ItemSelectionTypeCode2 = itemSelectionTypeCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
