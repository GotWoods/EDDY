using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLD*3*8*qCm*7*L2";

		var expected = new CLD_LoadDetail()
		{
			NumberOfLoads = 3,
			NumberOfUnitsShipped = 8,
			PackagingCode = "qCm",
			Size = 7,
			UnitOrBasisForMeasurementCode = "L2",
		};

		var actual = Map.MapObject<CLD_LoadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredNumberOfLoads(int numberOfLoads, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfUnitsShipped = 8;
		if (numberOfLoads > 0)
		subject.NumberOfLoads = numberOfLoads;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validatation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 3;
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("L2", 0, false)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal size, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 3;
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (size > 0)
		subject.Size = size;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
