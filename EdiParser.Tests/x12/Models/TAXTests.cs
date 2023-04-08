using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*p*X*A*k*s*o*e*I*0*0*t*a*I";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "p",
			LocationQualifier = "X",
			LocationIdentifier = "A",
			LocationQualifier2 = "k",
			LocationIdentifier2 = "s",
			LocationQualifier3 = "o",
			LocationIdentifier3 = "e",
			LocationQualifier4 = "I",
			LocationIdentifier4 = "0",
			LocationQualifier5 = "0",
			LocationIdentifier5 = "t",
			TaxExemptCode = "a",
			CustomsEntryTypeGroupCode = "I",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}
	[Theory]
	[InlineData("", "", false)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", true)]
	[InlineData("p", "", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
}
