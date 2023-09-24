using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G77Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G77*o*vVAfbq*Eh*NVw7esFRI3orCdDF*CF*w";

		var expected = new G77_RemittanceAdviceIdentification()
		{
			CheckNumber = "o",
			CheckDate = "vVAfbq",
			CheckAmount = "Eh",
			MICRNumber = "NVw7esFRI3orCdDF",
			ReferenceNumberQualifier = "CF",
			ReferenceNumber = "w",
		};

		var actual = Map.MapObject<G77_RemittanceAdviceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckDate = "vVAfbq";
		subject.CheckAmount = "Eh";
		subject.CheckNumber = checkNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CF";
			subject.ReferenceNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vVAfbq", true)]
	public void Validation_RequiredCheckDate(string checkDate, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "o";
		subject.CheckAmount = "Eh";
		subject.CheckDate = checkDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CF";
			subject.ReferenceNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Eh", true)]
	public void Validation_RequiredCheckAmount(string checkAmount, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "o";
		subject.CheckDate = "vVAfbq";
		subject.CheckAmount = checkAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CF";
			subject.ReferenceNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CF", "w", true)]
	[InlineData("CF", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new G77_RemittanceAdviceIdentification();
		subject.CheckNumber = "o";
		subject.CheckDate = "vVAfbq";
		subject.CheckAmount = "Eh";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
