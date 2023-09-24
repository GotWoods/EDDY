using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class S5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S5*4*sn*9*u*5*jr*2*Z*Q*TpMhVC*e";

		var expected = new S5_StopOffDetails()
		{
			StopSequenceNumber = 4,
			StopReasonCode = "sn",
			Weight = 9,
			WeightUnitQualifier = "u",
			NumberOfUnitsShipped = 5,
			UnitOfMeasurementCode = "jr",
			Volume = 2,
			VolumeUnitQualifier = "Z",
			Description = "Q",
			StandardPointLocationCode = "TpMhVC",
			AccomplishCode = "e",
		};

		var actual = Map.MapObject<S5_StopOffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopReasonCode = "sn";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sn", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 4;
		subject.StopReasonCode = stopReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
