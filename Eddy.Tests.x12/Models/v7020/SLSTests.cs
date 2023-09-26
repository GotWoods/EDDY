using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class SLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLS*e*GKP*Xh";

		var expected = new SLS_SalesParameters()
		{
			MeasurementQualifier = "e",
			CurrencyCode = "GKP",
			UnitOrBasisForMeasurementCode = "Xh",
		};

		var actual = Map.MapObject<SLS_SalesParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new SLS_SalesParameters();
		//Required fields
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GKP", "Xh", false)]
	[InlineData("GKP", "", true)]
	[InlineData("", "Xh", true)]
	public void Validation_OnlyOneOfCurrencyCode(string currencyCode, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SLS_SalesParameters();
		//Required fields
		subject.MeasurementQualifier = "e";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
