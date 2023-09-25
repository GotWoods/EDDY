using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class NCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCA*v*X*M*4*8m";

		var expected = new NCA_NonconformanceAction()
		{
			AssignedIdentification = "v",
			NonconformanceResultantResponseCode = "X",
			Description = "M",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "8m",
		};

		var actual = Map.MapObject<NCA_NonconformanceAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("X", "M", true)]
	[InlineData("X", "", true)]
	[InlineData("", "M", true)]
	public void Validation_AtLeastOneNonconformanceResultantResponseCode(string nonconformanceResultantResponseCode, string description, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		//Required fields
		//Test Parameters
		subject.NonconformanceResultantResponseCode = nonconformanceResultantResponseCode;
		subject.Description = description;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 4;
			subject.UnitOrBasisForMeasurementCode = "8m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "8m", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "8m", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.NonconformanceResultantResponseCode = "X";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
