using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*Q*g*u*3*b*z*O*C*7*i*N*1";

		var expected = new TAX_TaxReference()
		{
			TaxIdentificationNumber = "Q",
			LocationQualifier = "g",
			LocationIdentifier = "u",
			LocationQualifier2 = "3",
			LocationIdentifier2 = "b",
			LocationQualifier3 = "z",
			LocationIdentifier3 = "O",
			LocationQualifier4 = "C",
			LocationIdentifier4 = "7",
			LocationQualifier5 = "i",
			LocationIdentifier5 = "N",
			TaxExemptCode = "1",
		};

		var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Q", "g", true)]
	[InlineData("Q", "", true)]
	[InlineData("", "g", true)]
	public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationQualifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.TaxIdentificationNumber = taxIdentificationNumber;
		subject.LocationQualifier = locationQualifier;
		if (locationQualifier != "")
			subject.LocationIdentifier = "u";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "u", true)]
	[InlineData("g", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.TaxIdentificationNumber = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "b", true)]
	[InlineData("3", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
			subject.TaxIdentificationNumber = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "O", true)]
	[InlineData("z", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier3 = locationQualifier3;
		subject.LocationIdentifier3 = locationIdentifier3;
			subject.TaxIdentificationNumber = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "7", true)]
	[InlineData("C", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier4 = locationQualifier4;
		subject.LocationIdentifier4 = locationIdentifier4;
			subject.TaxIdentificationNumber = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "N", true)]
	[InlineData("i", "", false)]
	[InlineData("", "N", true)]
	public void Validation_ARequiresBLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
	{
		var subject = new TAX_TaxReference();
		subject.LocationQualifier5 = locationQualifier5;
		subject.LocationIdentifier5 = locationIdentifier5;
			subject.TaxIdentificationNumber = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
