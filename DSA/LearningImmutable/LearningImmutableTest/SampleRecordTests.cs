using LearnImmutable;


namespace LearnImmutableTest
{
    [TestClass]
    public class SampleRecordTest
    {
        SampleRecord record1=null;
        [TestInitialize]
        public void TestSetup()
        {
            record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
        }
        
        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeInEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParameters()
        {
            //arrange
            
            SampleRecord record2 = record1;

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //Arrange
            

            //Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);
        }
        [TestMethod]
        public void TestRecordMutableProperties()
        {
            //Assign
            string expected = "NewString";
            
            
            //Action
            record1.MutableProperty = expected;

            //Assert
            Assert.AreEqual(record1.MutableProperty, expected);
           
        }

        [TestMethod]
        public void TestRecordTypeHaveDestructMethodWithOutParam()
        {
            //Arrange
            
            string outString = String.Empty;
            int outInt = 0;
            DateTime outDateTime = new DateTime();

            //Act
            record1.Deconstruct(out outString, out outInt, out outDateTime);
            //Assert
            Assert.AreEqual(outString, "Test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDateTime, new DateTime(2023,9, 5));
        }

        [TestMethod]
        public void NonDestructionPropertyInfo()
        {
            //Arrange
            
            //Action
            SampleRecord record2 = record1 with { ParamInt = 2 };
            //record.ParamInt = 5;// this is not allow per compiler
            //Assert
            Assert.AreNotEqual(record1, record2);//There are 2 different objects
            Assert.AreNotSame(record1, record2);//record2 points to different instance than record1 - reference comparison
            Assert.AreEqual(record2.ParamInt, 2);//record2 has updated ParamInt
            Assert.AreEqual(record1.ParamInt, 1);//record1 is immutable
            Assert.AreEqual(record2.ParamString, "Test");//the record2 has the same properties as record1 if the property has not been modified



        }







    }
}