using System;
using CheckDigitAlg.Impl;
using Xunit;

namespace CheckDigitAlg.Tests.Impl
{
    public class Mod97Tests
    {
        private readonly Mod97 _mod97 = new Mod97();

        [Theory]
        [InlineData(" 123-321  ", 123321)]
        public void ReplaceChars(string input, long expected)
        {
            var actual = _mod97.ReplaceCharacters(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplaceChars_InvalidValue()
        {
            Assert.Throws<Exception>(() => _mod97.ReplaceCharacters("123abc"));
        }
    }
}