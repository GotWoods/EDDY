using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8010;
using Eddy.x12.Models.v8010.Composites;

namespace Eddy.x12.Tests.Models.v8010.Composites;

public class C074Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "8*R*P*n*M";

		var expected = new C074_CompositeDateTimePeriod()
		{
			DateTimePeriod = "8",
			DateTimePeriod2 = "R",
			DateTimePeriod3 = "P",
			DateTimePeriod4 = "n",
			DateTimePeriod5 = "M",
		};

		var actual = Map.MapObject<C074_CompositeDateTimePeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new C074_CompositeDateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "R", true)]
	[InlineData("P", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new C074_CompositeDateTimePeriod();
		//Required fields
		subject.DateTimePeriod = "8";
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod2 = dateTimePeriod2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "P", true)]
	[InlineData("n", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new C074_CompositeDateTimePeriod();
		//Required fields
		subject.DateTimePeriod = "8";
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//A Requires B
		if (dateTimePeriod3 != "")
			subject.DateTimePeriod2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "", false)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new C074_CompositeDateTimePeriod();
		//Required fields
		subject.DateTimePeriod = "8";
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//A Requires B
		if (dateTimePeriod4 != "")
			subject.DateTimePeriod3 = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
