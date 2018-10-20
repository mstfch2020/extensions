﻿using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Xunit;

namespace ExtensionsTest
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData( "سلام !# بر همه <شما دوستان>")]
        public void ToUrlTitle_Test(string url)
        {
            Assert.True(url.ToUrlTitle() == "سلام-بر-همه-شما-دوستان-");
        }

        [Theory]
        [InlineData("sallary")]
        [InlineData("Sallary")]
        public void UpperFirstCharacter_Test(string word)
        {
            Assert.True(word.UpperFirstCharacter() == "Sallary");   
        }

        [Theory]
        [InlineData("Sallary")]
        public void ReverseString_Test(string word)
        {
            Assert.True(word.ReverseString() == "yrallaS");
            Assert.False(word.ReverseString() == "yrallas");
        }

        [Theory]
        [InlineData("salam")]
        public void ToByteArray_Test(string word)
        {
            var Byted = word.ToByteArray();

            Assert.True(Byted[0] == 115);
        }

        [Theory]
        [InlineData("salam")]
        public void Left_Test(string word)
        {
            var Lefted = word.Left(2, false);

            Assert.True(Lefted == "sa");
        }

        [Theory]
        [InlineData("how are you?")]
        public void Left_Complete_Test(string word)
        {
            var Lefted = word.Left(5, true);
            Assert.True(Lefted == "how");
        }

        [Theory]
        [InlineData("salam")]
        public void Left_AotOfRangeException_Test(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => word.Left(5, true));
        }

        [Theory]
        [InlineData("salam")]
        public void Right_Test(string word)
        {
            var Lefted = word.Right(2);

            Assert.True(Lefted == "am");
        }

        [Theory]
        [InlineData("salam")]
        public void ShouldNotPass_ToIntArray_Test(string word)
        {
            Assert.Throws<FormatException>(() => word.ToIntArray());
        }

        [Theory]
        [InlineData("12,13")]
        public void ShouldPass_ToIntArray_Test(string word)
        {
            var x = word.ToIntArray();

            Assert.True(word.ToIntArray()[0] == 12);
        }

        [Theory]
        [InlineData("~6s&^dg+=")]
        public void ShouldPass_UrlGuidEncode_Test(string word)
        {
            Assert.True(word.RemoveSpecialCharacters("-") == "-6s-dg-");
        }

    }
}
