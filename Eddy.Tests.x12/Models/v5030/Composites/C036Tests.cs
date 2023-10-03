using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5030;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Tests.Models.v5030.Composites;

public class C036Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "g*k*X*8*2";

		var expected = new C036_IndexIdentification()
		{
			ConfigurationTypeCode = "g",
			ReferenceIdentification = "k",
			ReferenceIdentification2 = "X",
			XPeg = 8,
			YPeg = 2,
		};

		var actual = Map.MapObject<C036_IndexIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("k", "X", true)]
	[InlineData("k", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new C036_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(subject.XPeg > 0 || subject.XPeg > 0 || subject.YPeg > 0)
		{
			subject.XPeg = 8;
			subject.YPeg = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal xPeg, bool isValidExpected)
	{
		var subject = new C036_IndexIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		if (xPeg > 0) 
			subject.XPeg = xPeg;
		//If one filled, all required
		if(subject.XPeg > 0 || subject.XPeg > 0 || subject.YPeg > 0)
		{
			subject.XPeg = 8;
			subject.YPeg = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 2, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 2, false)]
	public void Validation_AllAreRequiredXPeg(decimal xPeg, decimal yPeg, bool isValidExpected)
	{
		var subject = new C036_IndexIdentification();
		//Required fields
		//Test Parameters
		if (xPeg > 0) 
			subject.XPeg = xPeg;
		if (yPeg > 0) 
			subject.YPeg = yPeg;
		//At Least one
		subject.ReferenceIdentification = "k";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentification = "k";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
