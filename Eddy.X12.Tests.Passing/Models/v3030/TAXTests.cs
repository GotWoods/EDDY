using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*5*7*I*9*d*V*P*J*G*U*F*f";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "5",
			LocationQualifier = "7",
			LocationIdentifier = "I",
			LocationQualifier2 = "9",
			LocationIdentifier2 = "d",
			LocationQualifier3 = "V",
			LocationIdentifier3 = "P",
			LocationQualifier4 = "J",
			LocationIdentifier4 = "G",
			LocationQualifier5 = "U",
			LocationIdentifier5 = "F",
			TaxExemptCode = "f",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("5", "I", true)]
	[InlineData("5", "", true)]
	[InlineData("", "I", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "7";
			subject.LocationIdentifier = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "9";
			subject.LocationIdentifier2 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "V";
			subject.LocationIdentifier3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "J";
			subject.LocationIdentifier4 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "U";
			subject.LocationIdentifier5 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "I", true)]
	[InlineData("7", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.TaxIdentificationNumber = "5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "9";
			subject.LocationIdentifier2 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "V";
			subject.LocationIdentifier3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "J";
			subject.LocationIdentifier4 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "U";
			subject.LocationIdentifier5 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "d", true)]
	[InlineData("9", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
			subject.TaxIdentificationNumber = "5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "7";
			subject.LocationIdentifier = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "V";
			subject.LocationIdentifier3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "J";
			subject.LocationIdentifier4 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "U";
			subject.LocationIdentifier5 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "P", true)]
	[InlineData("V", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;
			subject.TaxIdentificationNumber = "5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "7";
			subject.LocationIdentifier = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "9";
			subject.LocationIdentifier2 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "J";
			subject.LocationIdentifier4 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "U";
			subject.LocationIdentifier5 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "G", true)]
	[InlineData("J", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;
			subject.TaxIdentificationNumber = "5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "7";
			subject.LocationIdentifier = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "9";
			subject.LocationIdentifier2 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "V";
			subject.LocationIdentifier3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "U";
			subject.LocationIdentifier5 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "F", true)]
	[InlineData("U", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;
			subject.TaxIdentificationNumber = "5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "7";
			subject.LocationIdentifier = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "9";
			subject.LocationIdentifier2 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "V";
			subject.LocationIdentifier3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "J";
			subject.LocationIdentifier4 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
