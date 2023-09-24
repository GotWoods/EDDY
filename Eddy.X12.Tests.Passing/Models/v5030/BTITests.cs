using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*nS*u*2*H8*hTxssHyn*N*G*JB*u*YG*z*6B*IP*sN";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceIdentificationQualifier = "nS",
			ReferenceIdentification = "u",
			IdentificationCodeQualifier = "2",
			IdentificationCode = "H8",
			Date = "hTxssHyn",
			NameControlIdentifier = "N",
			IdentificationCodeQualifier2 = "G",
			IdentificationCode2 = "JB",
			IdentificationCodeQualifier3 = "u",
			IdentificationCode3 = "YG",
			IdentificationCodeQualifier4 = "z",
			IdentificationCode4 = "6B",
			TransactionSetPurposeCode = "IP",
			TransactionTypeCode = "sN",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nS", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentification = "u";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = "H8";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = "H8";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.ReferenceIdentification = "u";
		subject.IdentificationCode = "H8";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H8", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.ReferenceIdentification = "u";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "JB", true)]
	[InlineData("G", "", false)]
	[InlineData("", "JB", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.ReferenceIdentification = "u";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = "H8";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "YG", true)]
	[InlineData("u", "", false)]
	[InlineData("", "YG", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.ReferenceIdentification = "u";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = "H8";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "z";
			subject.IdentificationCode4 = "6B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "6B", true)]
	[InlineData("z", "", false)]
	[InlineData("", "6B", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "nS";
		subject.ReferenceIdentification = "u";
		subject.IdentificationCodeQualifier = "2";
		subject.IdentificationCode = "H8";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "G";
			subject.IdentificationCode2 = "JB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "u";
			subject.IdentificationCode3 = "YG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
