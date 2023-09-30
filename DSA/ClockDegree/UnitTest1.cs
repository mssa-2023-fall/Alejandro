namespace Clock
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateClockDegreeGiveTime()
        {
            //Arrange
            ClockDegree clock = new ClockDegree();
            

            //Action
            var degree = clock.GetDegreeGivenTime(12, 20);
            var degree2 = clock.GetDegreeGivenTime(12, 25);
            var degree3 = clock.GetDegreeGivenTime(12, 30);
            var degree4 = clock.GetDegreeGivenTime(11, 05);
            

            //Assert
            Assert.AreEqual(120, degree );
            Assert.AreEqual(150, degree2 );
            Assert.AreEqual(180, degree3 );
            Assert.AreEqual(60, degree4);
        }
    }
}