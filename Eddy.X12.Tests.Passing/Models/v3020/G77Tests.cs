using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G77Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G77*k*ZpWsxN*mF*2376825716811766*jK*7";

		var expected = new G77_RemittanceAdviceIdentification()
		{
			CheckNumber = "k",
			CheckDate = "ZpWsxN",
			CheckAmount = "mF",
			MICRNumber = 2376825716811766,
			ReferenceNumberQualifier = "jK",
			ReferenceNumber = "7",
		};

		var actual = Map.MapObject<G77_RemittanceAdviceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckDate = "ZpWsxN";
		subject.CheckAmount = "mF";
		subject.CheckNumber = checkNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "jK";
			subject.ReferenceNumber = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZpWsxN", true)]
	public void Validation_RequiredCheckDate(string checkDate, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "k";
		subject.CheckAmount = "mF";
		subject.CheckDate = checkDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "jK";
			subject.ReferenceNumber = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mF", true)]
	public void Validation_RequiredCheckAmount(string checkAmount, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "k";
		subject.CheckDate = "ZpWsxN";
		subject.CheckAmount = checkAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "jK";
			subject.ReferenceNumber = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jK", "7", true)]
	[InlineData("jK", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "k";
		subject.CheckDate = "ZpWsxN";
		subject.CheckAmount = "mF";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
