using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*x*z*5*i*t*F*4*U*Y*N*E*M";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "x",
			LocationQualifier = "z",
			LocationIdentifier = "5",
			LocationQualifier2 = "i",
			LocationIdentifier2 = "t",
			LocationQualifier3 = "F",
			LocationIdentifier3 = "4",
			LocationQualifier4 = "U",
			LocationIdentifier4 = "Y",
			LocationQualifier5 = "N",
			LocationIdentifier5 = "E",
			TaxExemptCode = "M",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "5", true)]
	[InlineData("x", "", true)]
	[InlineData("", "5", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "i";
			subject.LocationIdentifier2 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "F";
			subject.LocationIdentifier3 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "U";
			subject.LocationIdentifier4 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "5", true)]
	[InlineData("z", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.TaxIdentificationNumber = "x";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "i";
			subject.LocationIdentifier2 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "F";
			subject.LocationIdentifier3 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "U";
			subject.LocationIdentifier4 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "t", true)]
	[InlineData("i", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
			subject.TaxIdentificationNumber = "x";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "F";
			subject.LocationIdentifier3 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "U";
			subject.LocationIdentifier4 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "4", true)]
	[InlineData("F", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;
			subject.TaxIdentificationNumber = "x";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "i";
			subject.LocationIdentifier2 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "U";
			subject.LocationIdentifier4 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "Y", true)]
	[InlineData("U", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;
			subject.TaxIdentificationNumber = "x";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "i";
			subject.LocationIdentifier2 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "F";
			subject.LocationIdentifier3 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationQualifier5) || !string.IsNullOrEmpty(subject.LocationIdentifier5))
		{
			subject.LocationQualifier5 = "N";
			subject.LocationIdentifier5 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "E", true)]
	[InlineData("N", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;
			subject.TaxIdentificationNumber = "x";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "5";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "i";
			subject.LocationIdentifier2 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationQualifier3) || !string.IsNullOrEmpty(subject.LocationIdentifier3))
		{
			subject.LocationQualifier3 = "F";
			subject.LocationIdentifier3 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationQualifier4) || !string.IsNullOrEmpty(subject.LocationIdentifier4))
		{
			subject.LocationQualifier4 = "U";
			subject.LocationIdentifier4 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
