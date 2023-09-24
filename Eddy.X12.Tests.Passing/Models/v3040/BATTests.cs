using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*cOto22*3QHK*b*au";

		var expected = new BAT_Batch()
		{
			Date = "cOto22",
			Time = "3QHK",
			ReferenceNumber = "b",
			BatchTypeCode = "au",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("cOto22", "b", true)]
	[InlineData("cOto22", "", true)]
	[InlineData("", "b", true)]
	public void Validation_AtLeastOneDate(string date, string referenceNumber, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
