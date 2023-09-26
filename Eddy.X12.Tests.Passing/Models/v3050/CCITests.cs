using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CCI*GS*q*VG*t*Tv*i*j*Y*3*A";

		var expected = new CCI_CreditCounselingInformation()
		{
			IdentificationCode = "GS",
			ReferenceNumber = "q",
			ReferenceNumberQualifier = "VG",
			ReferenceNumber2 = "t",
			DateTimePeriodFormatQualifier = "Tv",
			DateTimePeriod = "i",
			DateTimePeriod2 = "j",
			DateTimePeriod3 = "Y",
			MonetaryAmount = 3,
			CounselingStatusCode = "A",
		};

		var actual = Map.MapObject<CCI_CreditCounselingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GS", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.DateTimePeriod = "i";
			subject.DateTimePeriod2 = "j";
			subject.DateTimePeriod3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.DateTimePeriod = "i";
			subject.DateTimePeriod2 = "j";
			subject.DateTimePeriod3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VG", "t", true)]
	[InlineData("VG", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber2, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.DateTimePeriod = "i";
			subject.DateTimePeriod2 = "j";
			subject.DateTimePeriod3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Tv", "A", true)]
	[InlineData("Tv", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string counselingStatusCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.CounselingStatusCode = counselingStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}


        if (subject.DateTimePeriodFormatQualifier != "") 
            subject.DateTimePeriod = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "Tv", true)]
	[InlineData("i", "", false)]
	[InlineData("", "Tv", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod2 = "j";
			subject.DateTimePeriod3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "Tv", true)]
	[InlineData("j", "", false)]
	[InlineData("", "Tv", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriod = "i";
			subject.DateTimePeriod3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "Tv", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "Tv", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		//Required fields
		subject.IdentificationCode = "GS";
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier = "VG";
			subject.ReferenceNumber2 = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.CounselingStatusCode))
		{
			subject.DateTimePeriodFormatQualifier = "Tv";
			subject.CounselingStatusCode = "A";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriod = "i";
			subject.DateTimePeriod2 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
