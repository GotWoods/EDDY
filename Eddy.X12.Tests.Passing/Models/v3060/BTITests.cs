using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*hN*Y*Z*pK*DBY5iI*SPqQ*y*l1*y*2w*8*ui*c3*Fs";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceIdentificationQualifier = "hN",
			ReferenceIdentification = "Y",
			IdentificationCodeQualifier = "Z",
			IdentificationCode = "pK",
			Date = "DBY5iI",
			NameControlIdentifier = "SPqQ",
			IdentificationCodeQualifier2 = "y",
			IdentificationCode2 = "l1",
			IdentificationCodeQualifier3 = "y",
			IdentificationCode3 = "2w",
			IdentificationCodeQualifier4 = "8",
			IdentificationCode4 = "ui",
			TransactionSetPurposeCode = "c3",
			TransactionTypeCode = "Fs",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hN", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "pK";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "pK";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCode = "pK";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pK", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "l1", true)]
	[InlineData("y", "", false)]
	[InlineData("", "l1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "pK";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "2w", true)]
	[InlineData("y", "", false)]
	[InlineData("", "2w", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "pK";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "8";
			subject.IdentificationCode4 = "ui";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "ui", true)]
	[InlineData("8", "", false)]
	[InlineData("", "ui", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "hN";
		subject.ReferenceIdentification = "Y";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "pK";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "l1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "y";
			subject.IdentificationCode3 = "2w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
