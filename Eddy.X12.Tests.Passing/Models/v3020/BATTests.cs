using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*txWUUX*RveT*A*Hh";

		var expected = new BAT_Batch()
		{
			Date = "txWUUX",
			Time = "RveT",
			ReferenceNumber = "A",
			BatchTypeCode = "Hh",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("txWUUX", "A", true)]
	[InlineData("txWUUX", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneDate(string date, string referenceNumber, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
