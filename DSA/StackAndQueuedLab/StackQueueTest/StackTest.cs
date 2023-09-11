using System.Collections;

namespace StackQueue
{
    [TestClass]
    public class AlexStackTest
    {
        

        [TestMethod]
        public void CreateAnEmptyStack()
        {   //Arrange
            AlexStack<int> newStack = new AlexStack<int>();


            //Assert
            Assert.IsNotNull(newStack);
            Assert.AreEqual(0, newStack.Count);
        }
        [TestMethod]
        public void TestPushStack()
        {   //Arrange
            AlexStack<int> newStack = new AlexStack<int>();


            //Action
            newStack.Push(1);
            newStack.Push(2);
            
            //Assert
            Assert.AreEqual(2, newStack.Count);
            Assert.AreNotEqual(3, newStack.Count);
            
        }

        [TestMethod]
        public void TestPopStack()
        {   //Arrange
            AlexStack<int> newStack = new AlexStack<int>();

            newStack.Push(1);
            newStack.Push(2);
            //Action
            newStack.Pop();

            //Assert
            
            Assert.AreEqual(1, newStack.Count);
        }

        [TestMethod]
        public void TestPeekStack()
        {   //Arrange
            AlexStack<int> newStack = new AlexStack<int>();


            newStack.Push(1);
            newStack.Push(2);
            newStack.Push(4);

            //Assert
            Assert.AreEqual(4, newStack.Peek());
            Assert.AreNotEqual(1, newStack.Peek());
        }

        [TestMethod]
        public void TestClearStack()
        {   //Arrange
            AlexStack<int> newStack = new AlexStack<int>();


            newStack.Push(1);
            newStack.Push(2);
            newStack.Push(4);

            //Action
            newStack.ClearStack();

            //Assert
            Assert.AreEqual(0, newStack.Count);
        }

    }
}