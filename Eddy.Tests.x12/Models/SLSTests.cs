using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLS*u*bLG*be";

		var expected = new SLS_SalesParameters()
		{
			MeasurementQualifier = "u",
			CurrencyCode = "bLG",
			UnitOrBasisForMeasurementCode = "be",
		};

		var actual = Map.MapObject<SLS_SalesParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new SLS_SalesParameters();
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bLG", "be", false)]
	[InlineData("", "be", true)]
	[InlineData("bLG", "", true)]
	public void Validation_OnlyOneOfCurrencyCode(string currencyCode, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SLS_SalesParameters();
		subject.MeasurementQualifier = "u";
		subject.CurrencyCode = currencyCode;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
