using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLA*L*SK*KrXsOd*Qd4X*PD";

		var expected = new PLA_PlaceOrLocation()
		{
			ActionCode = "L",
			EntityIdentifierCode = "SK",
			Date = "KrXsOd",
			Time = "Qd4X",
			MaintenanceReasonCode = "PD",
		};

		var actual = Map.MapObject<PLA_PlaceOrLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.EntityIdentifierCode = "SK";
		subject.Date = "KrXsOd";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SK", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "L";
		subject.Date = "KrXsOd";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KrXsOd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "L";
		subject.EntityIdentifierCode = "SK";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
