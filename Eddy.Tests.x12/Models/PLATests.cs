using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLA*J*6V*lhi6Tl5F*xhYS*sa";

		var expected = new PLA_PlaceOrLocation()
		{
			ActionCode = "J",
			EntityIdentifierCode = "6V",
			Date = "lhi6Tl5F",
			Time = "xhYS",
			MaintenanceReasonCode = "sa",
		};

		var actual = Map.MapObject<PLA_PlaceOrLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		subject.EntityIdentifierCode = "6V";
		subject.Date = "lhi6Tl5F";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6V", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		subject.ActionCode = "J";
		subject.Date = "lhi6Tl5F";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lhi6Tl5F", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		subject.ActionCode = "J";
		subject.EntityIdentifierCode = "6V";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
