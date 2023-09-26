using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLA*F*yd*mDjOVQTT*dh28*fG";

		var expected = new PLA_PlaceOrLocation()
		{
			ActionCode = "F",
			EntityIdentifierCode = "yd",
			Date = "mDjOVQTT",
			Time = "dh28",
			MaintenanceReasonCode = "fG",
		};

		var actual = Map.MapObject<PLA_PlaceOrLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.EntityIdentifierCode = "yd";
		subject.Date = "mDjOVQTT";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yd", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "F";
		subject.Date = "mDjOVQTT";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mDjOVQTT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "F";
		subject.EntityIdentifierCode = "yd";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
