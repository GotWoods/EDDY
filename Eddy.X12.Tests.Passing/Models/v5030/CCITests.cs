using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CCI*eR*8*ma*6*AI*z*i*k*2*f";

		var expected = new CCI_CreditCounselingInformation()
		{
			IdentificationCode = "eR",
			ReferenceIdentification = "8",
			ReferenceIdentificationQualifier = "ma",
			ReferenceIdentification2 = "6",
			DateTimePeriodFormatQualifier = "AI",
			DateTimePeriod = "z",
			DateTimePeriod2 = "i",
			DateTimePeriod3 = "k",
			MonetaryAmount = 2,
			CounselingStatusCode = "f",
		};

		var actual = Map.MapObject<CCI_CreditCounselingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eR", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.DateTimePeriod = "z";
			subject.DateTimePeriod2 = "i";
			subject.DateTimePeriod3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.DateTimePeriod = "z";
			subject.DateTimePeriod2 = "i";
			subject.DateTimePeriod3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ma", "6", true)]
	[InlineData("ma", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.DateTimePeriod = "z";
			subject.DateTimePeriod2 = "i";
			subject.DateTimePeriod3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AI", "f", true)]
	[InlineData("AI", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string counselingStatusCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.CounselingStatusCode = counselingStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}

        if (subject.DateTimePeriodFormatQualifier != "")
            subject.DateTimePeriod = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "AI", true)]
	[InlineData("z", "", false)]
	[InlineData("", "AI", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod2 = "i";
			subject.DateTimePeriod3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "AI", true)]
	[InlineData("i", "", false)]
	[InlineData("", "AI", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod = "z";
			subject.DateTimePeriod3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "AI", true)]
	[InlineData("k", "", false)]
	[InlineData("", "AI", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "eR";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "ma";
			subject.ReferenceIdentification2 = "6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "AI";
			subject.CounselingStatusCode = "f";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriod = "z";
			subject.DateTimePeriod2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
