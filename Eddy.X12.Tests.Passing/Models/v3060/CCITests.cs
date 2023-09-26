using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CCI*K6*k*X9*X*my*J*e*d*7*1";

		var expected = new CCI_CreditCounselingInformation()
		{
			IdentificationCode = "K6",
			ReferenceIdentification = "k",
			ReferenceIdentificationQualifier = "X9",
			ReferenceIdentification2 = "X",
			DateTimePeriodFormatQualifier = "my",
			DateTimePeriod = "J",
			DateTimePeriod2 = "e",
			DateTimePeriod3 = "d",
			MonetaryAmount = 7,
			CounselingStatusCode = "1",
		};

		var actual = Map.MapObject<CCI_CreditCounselingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K6", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.DateTimePeriod = "J";
			subject.DateTimePeriod2 = "e";
			subject.DateTimePeriod3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.DateTimePeriod = "J";
			subject.DateTimePeriod2 = "e";
			subject.DateTimePeriod3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X9", "X", true)]
	[InlineData("X9", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.DateTimePeriod = "J";
			subject.DateTimePeriod2 = "e";
			subject.DateTimePeriod3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("my", "1", true)]
	[InlineData("my", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string counselingStatusCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.CounselingStatusCode = counselingStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}

        if (subject.DateTimePeriodFormatQualifier != "")
            subject.DateTimePeriod = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "my", true)]
	[InlineData("J", "", false)]
	[InlineData("", "my", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod2 = "e";
			subject.DateTimePeriod3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "my", true)]
	[InlineData("e", "", false)]
	[InlineData("", "my", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod = "J";
			subject.DateTimePeriod3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "my", true)]
	[InlineData("d", "", false)]
	[InlineData("", "my", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "K6";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "X9";
			subject.ReferenceIdentification2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "my";
			subject.CounselingStatusCode = "1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriod = "J";
			subject.DateTimePeriod2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
