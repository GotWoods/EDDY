using Eddy.Core.Validation;
using Eddy.x12.Models;
using static System.String;

namespace Eddy.Tests.x12;

public static class TestHelper
{
    public static void CheckValidationResults(EdiX12Segment subject, bool isValidExpected, ErrorCodes expectedErrorCode)
    {
        var validationResult = subject.Validate();
        if (isValidExpected)
        {
            Assert.True(validationResult.IsValid, validationResult.ToString());
        }
        else
        {
            Assert.False(validationResult.IsValid, validationResult.ToString());
            // if (validationResult.Errors.Count > 1)
            // {
            //     Assert.Fail(validationResult.ToString());
            //     return;
            // }

            foreach (var error in validationResult.Errors)
            {
                if (error.ErrorCode != expectedErrorCode) //the first non match will fail
                {
                    Assert.Fail("Expected " + expectedErrorCode.Message + " but actual error was: " + Format(error.ErrorCode.Message, error.Data));
                    //Assert.Equal(expectedErrorCode, error.ErrorCode);
                }
            }

            //Assert.Equal(expectedErrorCode, validationResult.Errors[0].ErrorCode);
        }
    }
}
