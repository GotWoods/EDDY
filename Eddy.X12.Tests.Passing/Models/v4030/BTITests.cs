using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*Iv*j*y*XI*z6pB4aip*u*8*tO*T*W0*B*nh*uk*00";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceIdentificationQualifier = "Iv",
			ReferenceIdentification = "j",
			IdentificationCodeQualifier = "y",
			IdentificationCode = "XI",
			Date = "z6pB4aip",
			NameControlIdentifier = "u",
			IdentificationCodeQualifier2 = "8",
			IdentificationCode2 = "tO",
			IdentificationCodeQualifier3 = "T",
			IdentificationCode3 = "W0",
			IdentificationCodeQualifier4 = "B",
			IdentificationCode4 = "nh",
			TransactionSetPurposeCode = "uk",
			TransactionTypeCode = "00",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iv", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentification = "j";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = "XI";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = "XI";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.ReferenceIdentification = "j";
		subject.IdentificationCode = "XI";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XI", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.ReferenceIdentification = "j";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "tO", true)]
	[InlineData("8", "", false)]
	[InlineData("", "tO", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.ReferenceIdentification = "j";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = "XI";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "W0", true)]
	[InlineData("T", "", false)]
	[InlineData("", "W0", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.ReferenceIdentification = "j";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = "XI";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "B";
			subject.IdentificationCode4 = "nh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "nh", true)]
	[InlineData("B", "", false)]
	[InlineData("", "nh", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "Iv";
		subject.ReferenceIdentification = "j";
		subject.IdentificationCodeQualifier = "y";
		subject.IdentificationCode = "XI";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "8";
			subject.IdentificationCode2 = "tO";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "T";
			subject.IdentificationCode3 = "W0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
