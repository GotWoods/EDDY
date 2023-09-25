using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLA*2*d8*Q1WF3k*OR9f";

		var expected = new PLA_PlaceOrLocation()
		{
			ActionCode = "2",
			EntityIdentifierCode = "d8",
			Date = "Q1WF3k",
			Time = "OR9f",
		};

		var actual = Map.MapObject<PLA_PlaceOrLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.EntityIdentifierCode = "d8";
		subject.Date = "Q1WF3k";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d8", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "2";
		subject.Date = "Q1WF3k";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q1WF3k", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLA_PlaceOrLocation();
		//Required fields
		subject.ActionCode = "2";
		subject.EntityIdentifierCode = "d8";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
