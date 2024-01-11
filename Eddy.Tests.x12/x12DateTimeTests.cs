using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddy.x12.Models;

namespace Eddy.x12.Tests
{
    public class x12DateTimeTests
    {
        [Theory]
        [InlineData("2022-01-15 1:00pm", 22)]
        [InlineData("2022-06-15 1:00pm", 21)]
        public void TimeZone2Test(string date, int expectedHour)
        {
            var dateTime = DateTime.Parse(date);
            var timezone2 = new TimeZoneInfo2("Alaskan Standard Time");
            
            var dt2 = timezone2.SetTimezone(dateTime);
            Assert.Equal(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, expectedHour, 00, 00, DateTimeKind.Utc), dt2.ToUniversalTime());
        }

        [Theory]

        // Hawaiian Standard Time
        [InlineData("2023-01-15 1:00pm", "HD", 23)]
        [InlineData("2022-06-15 1:00pm", "HS", 23)] //does not do DST
        [InlineData("2022-01-15 1:00pm", "HT", 23)]
        [InlineData("2022-06-15 1:00pm", "HT", 23)] //does not do DST
        
        // Alaska Standard Time
        [InlineData("2023-01-15 1:00pm", "AD", 22)]
        [InlineData("2022-06-15 1:00pm", "AS", 21)]
        [InlineData("2022-01-15 1:00pm", "AT", 22)]
        [InlineData("2022-06-15 1:00pm", "AT", 21)]
        
        // Pacific Standard Time
        [InlineData("2023-01-15 1:00pm", "PD", 21)]
        [InlineData("2022-06-15 1:00pm", "PS", 20)]
        [InlineData("2022-01-15 1:00pm", "PT", 21)]
        [InlineData("2022-06-15 1:00pm", "PT", 20)]
        
        // Mountain Standard Time
        [InlineData("2023-01-15 1:00pm", "MD", 20)]
        [InlineData("2022-06-15 1:00pm", "MS", 19)]
        [InlineData("2022-01-15 1:00pm", "MT", 20)]
        [InlineData("2022-06-15 1:00pm", "MT", 19)]
        
        // Central Standard Time
        [InlineData("2023-01-15 1:00pm", "CD", 19)]
        [InlineData("2022-06-15 1:00pm", "CS", 18)]
        [InlineData("2022-01-15 1:00pm", "CT", 19)]
        [InlineData("2022-06-15 1:00pm", "CT", 18)]
        
        // Eastern Standard Time
        [InlineData("2023-01-15 1:00pm", "ED", 18)]
        [InlineData("2022-06-15 1:00pm", "ES", 17)]
        [InlineData("2022-01-15 1:00pm", "ET", 18)]
        [InlineData("2022-06-15 1:00pm", "ET", 17)]
        
        
        // Atlantic Standard Time
        [InlineData("2023-01-15 1:00pm", "TD", 17)]
        [InlineData("2022-06-15 1:00pm", "TS", 16)]
        [InlineData("2022-01-15 1:00pm", "TT", 17)]
        [InlineData("2022-06-15 1:00pm", "TT", 16)]
        
        // Newfoundland Standard Time
        [InlineData("2023-01-15 1:00pm", "ND", 16 ,30)]
        [InlineData("2022-06-15 1:00pm", "NS", 15, 30)]
        [InlineData("2022-01-15 1:00pm", "NT", 16, 30)]
        [InlineData("2022-06-15 1:00pm", "NT", 15, 30)]
        
        // GMT Standard Time
        [InlineData("2023-01-15 1:00pm", "GM", 13)]
        // //[InlineData("2023-06-15 1:00pm", "GM", 13)]

        //Pluses
        [InlineData("2023-01-15 1:00pm", "P01", 12)]
        [InlineData("2023-06-15 1:00pm", "P01", 12)]
        [InlineData("2023-01-15 1:00pm", "P04", 9)]
        [InlineData("2023-06-15 1:00pm", "P04", 9)]


        //Minuses
        [InlineData("2023-01-15 1:00pm", "M01", 14)]
        [InlineData("2023-06-15 1:00pm", "M01", 14)]
        [InlineData("2023-01-15 1:00pm", "M04", 17)]
        [InlineData("2023-06-15 1:00pm", "M04", 17)]

        public void ConvertToTimeZone_ShouldReturnCorrectOffset(string dateString, string timeZoneCode, int expectedHours, int expectedMinutes = 0)
        {
            var testDate = DateTime.Parse(dateString);
            ;x12DateTimeParser.Parse("210101", "0730", SupportedDateFormats.SixDigit, SupportedTimeFormats.FourDigit | SupportedTimeFormats.SixDigit)
            var result = x12DateTimeParser.ConvertToTimeZone(testDate, timeZoneCode);
            var expectedDateTime = new DateTime(testDate.Year, testDate.Month, testDate.Day, expectedHours, expectedMinutes, 00, DateTimeKind.Utc);
            Assert.Equal(expectedDateTime.ToUniversalTime(), result.ToUniversalTime());
        }
    }
}
