using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class NCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCA*y*v*T*8*0h";

		var expected = new NCA_NonconformanceAction()
		{
			AssignedIdentification = "y",
			NonconformanceResultantResponseCode = "v",
			Description = "T",
			Quantity = 8,
			UnitOfMeasurementCode = "0h",
		};

		var actual = Map.MapObject<NCA_NonconformanceAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "T", true)]
	[InlineData("v", "", true)]
	[InlineData("", "T", true)]
	public void Validation_AtLeastOneNonconformanceResultantResponseCode(string nonconformanceResultantResponseCode, string description, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		//Required fields
		//Test Parameters
		subject.NonconformanceResultantResponseCode = nonconformanceResultantResponseCode;
		subject.Description = description;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Quantity = 8;
			subject.UnitOfMeasurementCode = "0h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "0h", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "0h", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.NonconformanceResultantResponseCode = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
