using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*aBPtuarb*ayjm*c*kJ";

		var expected = new BAT_Batch()
		{
			Date = "aBPtuarb",
			Time = "ayjm",
			ReferenceIdentification = "c",
			BatchTypeCode = "kJ",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("aBPtuarb", "c", true)]
	[InlineData("aBPtuarb", "", true)]
	[InlineData("", "c", true)]
	public void Validation_AtLeastOneDate(string date, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
