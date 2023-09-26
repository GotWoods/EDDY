using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLA*o*eC*tyGsrc*gAlP*72";

		var expected = new PLA_PlaceOrLocation()
		{
			ActionCode = "o",
			EntityIdentifierCode = "eC",
			Date = "tyGsrc",
			Time = "gAlP",
			MaintenanceReasonCode = "72",
		};

		var actual = Map.MapObject<PLA_PlaceOrLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.EntityIdentifierCode = "eC";
		subject.Date = "tyGsrc";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eC", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "o";
		subject.Date = "tyGsrc";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tyGsrc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "o";
		subject.EntityIdentifierCode = "eC";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
