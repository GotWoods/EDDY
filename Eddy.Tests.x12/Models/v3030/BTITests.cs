using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*5G*4*H*05*gNflFt*v4uK*0*tq*g*jS*l*8E";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceNumberQualifier = "5G",
			ReferenceNumber = "4",
			IdentificationCodeQualifier = "H",
			IdentificationCode = "05",
			Date = "gNflFt",
			NameControlIdentifier = "v4uK",
			IdentificationCodeQualifier2 = "0",
			IdentificationCode2 = "tq",
			IdentificationCodeQualifier3 = "g",
			IdentificationCode3 = "jS",
			IdentificationCodeQualifier4 = "l",
			IdentificationCode4 = "8E",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5G", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumber = "4";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "05";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "05";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.ReferenceNumber = "4";
		subject.IdentificationCode = "05";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.ReferenceNumber = "4";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "tq", true)]
	[InlineData("0", "", false)]
	[InlineData("", "tq", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.ReferenceNumber = "4";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "05";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "jS", true)]
	[InlineData("g", "", false)]
	[InlineData("", "jS", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.ReferenceNumber = "4";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "05";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier4) || !string.IsNullOrEmpty(subject.IdentificationCode4))
		{
			subject.IdentificationCodeQualifier4 = "l";
			subject.IdentificationCode4 = "8E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "8E", true)]
	[InlineData("l", "", false)]
	[InlineData("", "8E", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "5G";
		subject.ReferenceNumber = "4";
		subject.IdentificationCodeQualifier = "H";
		subject.IdentificationCode = "05";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "0";
			subject.IdentificationCode2 = "tq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "g";
			subject.IdentificationCode3 = "jS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
