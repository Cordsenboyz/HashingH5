namespace HashingH5Test
{
    public class UnitTest1
    {
        [Fact]
        public void HashingTest()
        {
            Program program = new Program();

            Assert.Equal("20", program.Hash("RasmusErSej"));
        }

        [Fact]
        public void LoginTest()
        {
            Program program = new Program();

            Assert.True(program.Login("Kevin", "RasmusErSej"));
            Assert.False(program.Login("Kevin", "KevinErSej"));
        }
    }
}