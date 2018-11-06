using System;
using Xunit;

namespace MainScreen.UnitTests.Services
{
    public class IsScreenNotNull
    {
        public IsScreenNotNull()
        {
            MainScreen m = new MainScreen("Test");
            Assert.True(m != null, "Main screen should not be null");
        }
    }
}

