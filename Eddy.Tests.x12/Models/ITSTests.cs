using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ITSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITS*ZS*P*dC*V";

		var expected = new ITS_ItemSelection()
		{
			ItemSelectionTypeCode = "ZS",
			Description = "P",
			ItemSelectionTypeCode2 = "dC",
			Description2 = "V",
		};

		var actual = Map.MapObject<ITS_ItemSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZS", true)]
	public void Validation_RequiredItemSelectionTypeCode(string itemSelectionTypeCode, bool isValidExpected)
	{
		var subject = new ITS_ItemSelection();
		subject.ItemSelectionTypeCode = itemSelectionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "dC", true)]
	[InlineData("V", "", false)]
	public void Validation_ARequiresBDescription2(string description2, string itemSelectionTypeCode2, bool isValidExpected)
	{
		var subject = new ITS_ItemSelection();
		subject.ItemSelectionTypeCode = "ZS";
		subject.Description2 = description2;
		subject.ItemSelectionTypeCode2 = itemSelectionTypeCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
