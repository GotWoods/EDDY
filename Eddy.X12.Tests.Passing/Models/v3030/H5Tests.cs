using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class H5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H5*2zN*OF*wn";

		var expected = new H5_CarServiceOrder()
		{
			CarServiceOrderCode = "2zN",
			CityName = "OF",
			StateOrProvinceCode = "wn",
		};

		var actual = Map.MapObject<H5_CarServiceOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2zN", true)]
	public void Validation_RequiredCarServiceOrderCode(string carServiceOrderCode, bool isValidExpected)
	{
		var subject = new H5_CarServiceOrder();
		subject.CarServiceOrderCode = carServiceOrderCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
