using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;

namespace DotNetCore_Concepts.Tests.Questions.LinkList
{
    public class FindCyclesTests
    {
        [Fact]
        public void DetectCycles_NullStart_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FindCycles.DetectCycles(null));
        }

        [Fact]
        public void DetectCycles_SingleNode_NoCycle_ReturnsFalse()
        {
            var node = new Node(1);
            bool result = FindCycles.DetectCycles(node);
            Assert.False(result);
        }

        [Fact]
        public void DetectCycles_SingleNode_SelfCycle_ReturnsTrue()
        {
            var node = new Node(1);
            node.next = node;
            bool result = FindCycles.DetectCycles(node);
            Assert.True(result);
        }

        [Fact]
        public void DetectCycles_MultiNode_NoCycle_ReturnsFalse()
        {
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            n1.next = n2;
            n2.next = n3;
            n3.next = null;

            bool result = FindCycles.DetectCycles(n1);
            Assert.False(result);
        }

        [Fact]
        public void DetectCycles_MultiNode_WithCycle_ReturnsTrue()
        {
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n2; // cycle

            bool result = FindCycles.DetectCycles(n1);
            Assert.True(result);
        }

        [Fact]
        public void DetectCycles_TwoNodeCycle_ReturnsTrue()
        {
            var n1 = new Node(1);
            var n2 = new Node(2);
            n1.next = n2;
            n2.next = n1;

            bool result = FindCycles.DetectCycles(n1);
            Assert.True(result);
        }
    }
}
