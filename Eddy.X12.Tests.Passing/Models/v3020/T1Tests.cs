using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class T1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T1*7*4*ZwVahr*d0*Od*fi*Ee21Ot*4*i";

		var expected = new T1_TransitInboundOrigin()
		{
			AssignedNumber = 7,
			WaybillNumber = 4,
			Date = "ZwVahr",
			OriginCarrierCode = "d0",
			OriginStation = "Od",
			StateOrProvinceCode = "fi",
			StandardPointLocationCode = "Ee21Ot",
			TransitRegistrationNumber = "4",
			TransitLevelCode = "i",
		};

		var actual = Map.MapObject<T1_TransitInboundOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
