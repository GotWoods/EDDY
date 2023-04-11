using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E20*J*xv*P*9";

		var expected = new E20_SegmentHeaderInformation()
		{
			MaintenanceOperationCode = "J",
			SegmentIDCode = "xv",
			Description = "P",
			NoteIdentificationNumber = 9,
		};

		var actual = Map.MapObject<E20_SegmentHeaderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E20_SegmentHeaderInformation();
		subject.SegmentIDCode = "xv";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xv", true)]
	public void Validatation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new E20_SegmentHeaderInformation();
		subject.MaintenanceOperationCode = "J";
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
