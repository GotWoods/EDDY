using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*ipzTPm*GFsJ*T*If";

		var expected = new BAT_Batch()
		{
			Date = "ipzTPm",
			Time = "GFsJ",
			ReferenceIdentification = "T",
			BatchTypeCode = "If",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ipzTPm", "T", true)]
	[InlineData("ipzTPm", "", true)]
	[InlineData("", "T", true)]
	public void Validation_AtLeastOneDate(string date, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BAT_Batch();
		subject.Date = date;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
