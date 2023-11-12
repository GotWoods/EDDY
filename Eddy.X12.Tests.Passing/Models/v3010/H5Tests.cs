using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class H5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H5*ZDo*RF*CK";

		var expected = new H5_CarServiceOrder()
		{
			CarServiceOrderCode = "ZDo",
			CityName = "RF",
			StateOrProvinceCode = "CK",
		};

		var actual = Map.MapObject<H5_CarServiceOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZDo", true)]
	public void Validation_RequiredCarServiceOrderCode(string carServiceOrderCode, bool isValidExpected)
	{
		var subject = new H5_CarServiceOrder();
		subject.CarServiceOrderCode = carServiceOrderCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
