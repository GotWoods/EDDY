using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C036Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "3*0*n*9*7";

		var expected = new C036_IndexIdentification()
		{
			ConfigurationTypeCode = "3",
			ReferenceIdentification = "0",
			ReferenceIdentification2 = "n",
			XPeg = 9,
			YPeg = 7,
		};

		var actual = Map.MapObject<C036_IndexIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	
	[InlineData("0", "n", true)]
	[InlineData("0", "", false)]

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
			subject.XPeg = 9;
			subject.YPeg = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("", 9, true)]
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
			subject.XPeg = 9;
			subject.YPeg = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 7, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 7, false)]
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
		subject.ReferenceIdentification = "0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentification = "0";
			subject.ReferenceIdentification2 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
