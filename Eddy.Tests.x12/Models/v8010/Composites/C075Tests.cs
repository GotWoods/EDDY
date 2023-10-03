using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8010;
using Eddy.x12.Models.v8010.Composites;

namespace Eddy.x12.Tests.Models.v8010.Composites;

public class C075Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "uc*n6*jV";

		var expected = new C075_CompositeAddedFlavor()
		{
			AddedFlavor = "uc",
			AddedFlavor2 = "n6",
			AddedFlavor3 = "jV",
		};

		var actual = Map.MapObject<C075_CompositeAddedFlavor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uc", true)]
	public void Validation_RequiredAddedFlavor(string addedFlavor, bool isValidExpected)
	{
		var subject = new C075_CompositeAddedFlavor();
		//Required fields
		//Test Parameters
		subject.AddedFlavor = addedFlavor;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jV", "n6", true)]
	[InlineData("jV", "", false)]
	[InlineData("", "n6", true)]
	public void Validation_ARequiresBAddedFlavor3(string addedFlavor3, string addedFlavor2, bool isValidExpected)
	{
		var subject = new C075_CompositeAddedFlavor();
		//Required fields
		subject.AddedFlavor = "uc";
		//Test Parameters
		subject.AddedFlavor3 = addedFlavor3;
		subject.AddedFlavor2 = addedFlavor2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
