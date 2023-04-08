using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*RpnKaD7K*UHEh*3*Ci";

		var expected = new BAT_Batch()
		{
			Date = "RpnKaD7K",
			Time = "UHEh",
			ReferenceIdentification = "3",
			BatchTypeCode = "Ci",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("RpnKaD7K","3", true)]
	[InlineData("", "3", true)]
	[InlineData("RpnKaD7K", "", true)]
	public void Validation_AtLeastOneDate(string date, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
