using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class T1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T1*8*4*kjVxen*yg*ws*9Z*RkoBFF*C*c";

		var expected = new T1_TransitInboundOrigin()
		{
			AssignedNumber = 8,
			WaybillNumber = 4,
			Date = "kjVxen",
			StandardCarrierAlphaCode = "yg",
			CityName = "ws",
			StateOrProvinceCode = "9Z",
			StandardPointLocationCode = "RkoBFF",
			TransitRegistrationNumber = "C",
			TransitLevelCode = "c",
		};

		var actual = Map.MapObject<T1_TransitInboundOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
