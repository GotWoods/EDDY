using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*H*h*0*J*Y*z*e*W*v*t*I*3*Y";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "H",
			LocationQualifier = "h",
			LocationIdentifier = "0",
			LocationQualifier2 = "J",
			LocationIdentifier2 = "Y",
			LocationQualifier3 = "z",
			LocationIdentifier3 = "e",
			LocationQualifier4 = "W",
			LocationIdentifier4 = "v",
			LocationQualifier5 = "t",
			LocationIdentifier5 = "I",
			TaxExemptCode = "3",
			CustomsEntryTypeCode = "Y",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("H", "0", true)]
	[InlineData("H", "", true)]
	[InlineData("", "0", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "h";
			subject.LocationIdentifier = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "J";
			subject.LocationIdentifier2 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "z";
			subject.LocationIdentifier3 = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "W";
			subject.LocationIdentifier4 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "t";
			subject.LocationIdentifier5 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "0", true)]
	[InlineData("h", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.TaxIdentificationNumber = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "J";
			subject.LocationIdentifier2 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "z";
			subject.LocationIdentifier3 = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "W";
			subject.LocationIdentifier4 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "t";
			subject.LocationIdentifier5 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "Y", true)]
	[InlineData("J", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
			subject.TaxIdentificationNumber = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "h";
			subject.LocationIdentifier = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "z";
			subject.LocationIdentifier3 = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "W";
			subject.LocationIdentifier4 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "t";
			subject.LocationIdentifier5 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "e", true)]
	[InlineData("z", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;
			subject.TaxIdentificationNumber = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "h";
			subject.LocationIdentifier = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "J";
			subject.LocationIdentifier2 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "W";
			subject.LocationIdentifier4 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "t";
			subject.LocationIdentifier5 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "v", true)]
	[InlineData("W", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;
			subject.TaxIdentificationNumber = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "h";
			subject.LocationIdentifier = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "J";
			subject.LocationIdentifier2 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "z";
			subject.LocationIdentifier3 = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "t";
			subject.LocationIdentifier5 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "I", true)]
	[InlineData("t", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;
			subject.TaxIdentificationNumber = "H";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "h";
			subject.LocationIdentifier = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "J";
			subject.LocationIdentifier2 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "z";
			subject.LocationIdentifier3 = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "W";
			subject.LocationIdentifier4 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
