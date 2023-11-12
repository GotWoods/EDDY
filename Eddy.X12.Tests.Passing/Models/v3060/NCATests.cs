using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class NCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCA*n*o*X*9*";

		var expected = new NCA_NonconformanceAction()
		{
			AssignedIdentification = "n",
			NonconformanceResultantResponseCode = "o",
			Description = "X",
			Quantity = 9,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<NCA_NonconformanceAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("o", "X", true)]
	[InlineData("o", "", true)]
	[InlineData("", "X", true)]
	public void Validation_AtLeastOneNonconformanceResultantResponseCode(string nonconformanceResultantResponseCode, string description, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		//Required fields
		//Test Parameters
		subject.NonconformanceResultantResponseCode = nonconformanceResultantResponseCode;
		subject.Description = description;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 9;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
