using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G77Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G77*a*SuUSht*ho*6193911238677697*RZ*T";

		var expected = new G77_RemittanceAdviceIdentification()
		{
			CheckNumber = "a",
			CheckDate = "SuUSht",
			CheckAmount = "ho",
			MICRNumber = 6193911238677697,
			ReferenceNumberQualifier = "RZ",
			ReferenceNumber = "T",
		};

		var actual = Map.MapObject<G77_RemittanceAdviceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckDate = "SuUSht";
		subject.CheckAmount = "ho";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SuUSht", true)]
	public void Validation_RequiredCheckDate(string checkDate, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "a";
		subject.CheckAmount = "ho";
		subject.CheckDate = checkDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ho", true)]
	public void Validation_RequiredCheckAmount(string checkAmount, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "a";
		subject.CheckDate = "SuUSht";
		subject.CheckAmount = checkAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
