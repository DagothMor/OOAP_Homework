using OOAP_Homework;

namespace OOAP_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class StackUnitTest
        {
            [TestMethod]
            public void FirstTest()
            {
                var list = new List<int>();
                var stack = new BoundedStack<int>();

                Assert.AreEqual(0, stack.Size());
                Assert.AreEqual(0, stack.Peek());

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.AreEqual(3, stack.Peek());
                stack.Pop();
                Assert.AreEqual(2, stack.Peek());
                stack.Pop();
                Assert.AreEqual(1, stack.Peek());
                stack.Pop();
                Assert.AreEqual(0, stack.Size());
                Assert.AreEqual(0, stack.Peek());

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.AreEqual(3, stack.Peek());
                Assert.AreEqual(3, stack.Peek());
                Assert.AreEqual(3, stack.Peek());

                Assert.AreEqual(3, stack.Size());
                Assert.AreEqual(3, stack.Peek());

            }
        }
    }
}