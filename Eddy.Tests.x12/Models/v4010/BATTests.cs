using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*6PXgqs8q*1DS3*G*Fo";

		var expected = new BAT_Batch()
		{
			Date = "6PXgqs8q",
			Time = "1DS3",
			ReferenceIdentification = "G",
			BatchTypeCode = "Fo",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6PXgqs8q", "G", true)]
	[InlineData("6PXgqs8q", "", true)]
	[InlineData("", "G", true)]
	public void Validation_AtLeastOneDate(string date, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
