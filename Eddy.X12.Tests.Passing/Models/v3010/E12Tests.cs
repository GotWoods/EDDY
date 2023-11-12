using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E12*Z*5*g*L";

		var expected = new E12_SectionIndicator()
		{
			MaintenanceOperationCode = "Z",
			PositionInSet = 5,
			SectionDesignator = "g",
			Description = "L",
		};

		var actual = Map.MapObject<E12_SectionIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E12_SectionIndicator();
		subject.PositionInSet = 5;
		subject.SectionDesignator = "g";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredPositionInSet(int positionInSet, bool isValidExpected)
	{
		var subject = new E12_SectionIndicator();
		subject.MaintenanceOperationCode = "Z";
		subject.SectionDesignator = "g";
		if (positionInSet > 0)
			subject.PositionInSet = positionInSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredSectionDesignator(string sectionDesignator, bool isValidExpected)
	{
		var subject = new E12_SectionIndicator();
		subject.MaintenanceOperationCode = "Z";
		subject.PositionInSet = 5;
		subject.SectionDesignator = sectionDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
