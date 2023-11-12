using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*3*0*J*R*Z*B*n*i*m*N*W*Y*6";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "3",
			LocationQualifier = "0",
			LocationIdentifier = "J",
			LocationQualifier2 = "R",
			LocationIdentifier2 = "Z",
			LocationQualifier3 = "B",
			LocationIdentifier3 = "n",
			LocationQualifier4 = "i",
			LocationIdentifier4 = "m",
			LocationQualifier5 = "N",
			LocationIdentifier5 = "W",
			TaxExemptCode = "Y",
			CustomsEntryTypeGroupCode = "6",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("3", "J", true)]
	[InlineData("3", "", true)]
	[InlineData("", "J", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier2 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "B";
			subject.LocationIdentifier3 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "i";
			subject.LocationIdentifier4 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "J", true)]
	[InlineData("0", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.TaxIdentificationNumber = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier2 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "B";
			subject.LocationIdentifier3 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "i";
			subject.LocationIdentifier4 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "Z", true)]
	[InlineData("R", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
			subject.TaxIdentificationNumber = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "B";
			subject.LocationIdentifier3 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "i";
			subject.LocationIdentifier4 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "n", true)]
	[InlineData("B", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;
			subject.TaxIdentificationNumber = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier2 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "i";
			subject.LocationIdentifier4 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "m", true)]
	[InlineData("i", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;
			subject.TaxIdentificationNumber = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier2 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "B";
			subject.LocationIdentifier3 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "W", true)]
	[InlineData("N", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;
			subject.TaxIdentificationNumber = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "R";
			subject.LocationIdentifier2 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "B";
			subject.LocationIdentifier3 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "i";
			subject.LocationIdentifier4 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
