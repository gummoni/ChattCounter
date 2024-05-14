using ChattCounterLib;

namespace TestChattCounter
{
    [TestClass]
    public class ChattCounterTests
    {
        [TestMethod]
        public void TestChattCounter_InitialValue_True()
        {
            var counter = new ChattCounter(true);
            Assert.IsTrue(counter.Update(true));
            Assert.IsTrue(counter.Update(false));
        }

        [TestMethod]
        public void TestChattCounter_ChangeAfterThreeUpdates_True()
        {
            var counter = new ChattCounter(true);
            Assert.IsTrue(counter.Update(false)); // 1st change
            Assert.IsTrue(counter.Update(false)); // 2nd change
            Assert.IsFalse(counter.Update(false)); // 3rd change, value should change to false
        }

        [TestMethod]
        public void TestChattCounter_NoChangeIfRevertedBeforeThreeUpdates_True()
        {
            var counter = new ChattCounter(true);
            Assert.IsTrue(counter.Update(false)); // 1st change
            Assert.IsTrue(counter.Update(false)); // 2nd change
            Assert.IsTrue(counter.Update(true));  // revert before 3rd change
            Assert.IsTrue(counter.Update(false)); // 1st change again
            Assert.IsTrue(counter.Update(false)); // 2nd change again
            Assert.IsFalse(counter.Update(false)); // 3rd change, value should change to false
        }

        [TestMethod]
        public void TestChattCounter_InitialValue_False()
        {
            var counter = new ChattCounter(false);
            Assert.IsFalse(counter.Update(false));
            Assert.IsFalse(counter.Update(true));
        }

        [TestMethod]
        public void TestChattCounter_ChangeAfterThreeUpdates_False()
        {
            var counter = new ChattCounter(false);
            Assert.IsFalse(counter.Update(true)); // 1st change
            Assert.IsFalse(counter.Update(true)); // 2nd change
            Assert.IsTrue(counter.Update(true)); // 3rd change, value should change to true
        }

        [TestMethod]
        public void TestChattCounter_NoChangeIfRevertedBeforeThreeUpdates_False()
        {
            var counter = new ChattCounter(false);
            Assert.IsFalse(counter.Update(true)); // 1st change
            Assert.IsFalse(counter.Update(true)); // 2nd change
            Assert.IsFalse(counter.Update(false)); // revert before 3rd change
            Assert.IsFalse(counter.Update(true)); // 1st change again
            Assert.IsFalse(counter.Update(true)); // 2nd change again
            Assert.IsTrue(counter.Update(true)); // 3rd change, value should change to true
        }

        [TestMethod]
        public void TestChattCounter_InitialValue_True_ThreeConsecutive()
        {
            var counter = new ChattCounter(true);
            Assert.IsTrue(counter.Update(true)); // 1st same
            Assert.IsTrue(counter.Update(true)); // 2nd same
            Assert.IsTrue(counter.Update(true)); // 3rd same, value should remain true
        }

        [TestMethod]
        public void TestChattCounter_InitialValue_False_ThreeConsecutive()
        {
            var counter = new ChattCounter(false);
            Assert.IsFalse(counter.Update(false)); // 1st same
            Assert.IsFalse(counter.Update(false)); // 2nd same
            Assert.IsFalse(counter.Update(false)); // 3rd same, value should remain false
        }
    }
}