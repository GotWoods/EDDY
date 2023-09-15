using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*OH*i*L*rW*BykF2DPp*A*8*B0*5*Lm*C*VU*Jf*sr";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceIdentificationQualifier = "OH",
			ReferenceIdentification = "i",
			IdentificationCodeQualifier = "L",
			IdentificationCode = "rW",
			Date = "BykF2DPp",
			NameControlIdentifier = "A",
			IdentificationCodeQualifier2 = "8",
			IdentificationCode2 = "B0",
			IdentificationCodeQualifier3 = "5",
			IdentificationCode3 = "Lm",
			IdentificationCodeQualifier4 = "C",
			IdentificationCode4 = "VU",
			TransactionSetPurposeCode = "Jf",
			TransactionTypeCode = "sr",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OH", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentification = "i";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = "rW";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = "rW";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.ReferenceIdentification = "i";
		subject.IdentificationCode = "rW";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rW", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.ReferenceIdentification = "i";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "B0", true)]
	[InlineData("8", "", false)]
	[InlineData("", "B0", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.ReferenceIdentification = "i";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = "rW";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "Lm", true)]
	[InlineData("5", "", false)]
	[InlineData("", "Lm", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.ReferenceIdentification = "i";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = "rW";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "C";
			subject.IdentificationCode4 = "VU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "VU", true)]
	[InlineData("C", "", false)]
	[InlineData("", "VU", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "OH";
		subject.ReferenceIdentification = "i";
		subject.IdentificationCodeQualifier = "L";
		subject.IdentificationCode = "rW";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "B0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "5";
			subject.IdentificationCode3 = "Lm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
