using System.Collections;

namespace StackQueue
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void CreateAnEmptyQueue()
        {   //Arrange
            Queue<int> newQueue = new Queue<int>();

            //Assert
            Assert.IsNotNull(newQueue);
            Assert.AreEqual(0, newQueue.Count());
        }
        [TestMethod]
        public void TestEnqueueQueue()
        {   //Arrange
            Queue<int> newQueue = new Queue<int>();

            //Action
            newQueue.Enqueue(1);
            newQueue.Enqueue(2);

            //Assert
            Assert.AreEqual(2, newQueue.Count());
            Assert.AreNotEqual(3, newQueue.Count());

        }

        [TestMethod]
        public void TestDequeueQueue()
        {   //Arrange
            Queue<int> newQueue = new Queue<int>();
            newQueue.Enqueue(1);
            newQueue.Enqueue(2);
            //Action
            newQueue.Dequeue();

            //Assert

            Assert.AreEqual(1, newQueue.Count());
        }

        [TestMethod]
        public void TestPeekQueue()
        {   //Arrange
            Queue<int> newQueue = new Queue<int>();

            newQueue.Enqueue(1);
            newQueue.Enqueue(2);
            newQueue.Enqueue(4);

            //Assert
            Assert.AreEqual(1, newQueue.Peek());
            Assert.AreNotEqual(4, newQueue.Peek());
        }

        [TestMethod]
        public void TestClearQueue()
        {   //Arrange
            Queue<int> newQueue = new Queue<int>();

            newQueue.Enqueue(1);
            newQueue.Enqueue(2);
            newQueue.Enqueue(4);

            //Action
            newQueue.Clear();

            //Assert
            Assert.AreEqual(0, newQueue.Count());
        }

    }
}