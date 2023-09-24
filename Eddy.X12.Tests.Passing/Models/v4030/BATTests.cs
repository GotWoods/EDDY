using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*LRnskbP8*mOvH*o*FJ";

		var expected = new BAT_Batch()
		{
			Date = "LRnskbP8",
			Time = "mOvH",
			ReferenceIdentification = "o",
			BatchTypeCode = "FJ",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("LRnskbP8", "o", true)]
	[InlineData("LRnskbP8", "", true)]
	[InlineData("", "o", true)]
	public void Validation_AtLeastOneDate(string date, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
