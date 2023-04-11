using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class H5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H5*4f1*M6*1I";

		var expected = new H5_CarServiceOrder()
		{
			CarServiceOrderCode = "4f1",
			CityName = "M6",
			StateOrProvinceCode = "1I",
		};

		var actual = Map.MapObject<H5_CarServiceOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4f1", true)]
	public void Validation_RequiredCarServiceOrderCode(string carServiceOrderCode, bool isValidExpected)
	{
		var subject = new H5_CarServiceOrder();
		subject.CarServiceOrderCode = carServiceOrderCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
