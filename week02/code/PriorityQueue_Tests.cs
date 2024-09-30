using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test to see if the Dequeue() method will correctly prioritize the dequeueing.
    // Expected Result: "Steve" is dequeued when we dequeue once since he has the highest priority.
    // Defect(s) Found: The Dequeue() method had some issues with the for loop since it was off by one value. No actual dequeue (RemoveAt) option which had to be added in.
    public void TestPriorityQueue_CorrectDequeueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jon",1);
        priorityQueue.Enqueue("Steve",3);
        priorityQueue.Enqueue("Rick",2);
        string result = priorityQueue.Dequeue();
        Assert.AreEqual(result,"Steve");
    }

    [TestMethod]
    // Scenario: Test to see if the first item added of same priority will be dequeued first.
    // Expected Result: "Steve" and "Susan" should end up in a list in that order.
    // Defect(s) Found: Issues with the Dequeue() method. loop was off by one value and there was no dequeue option to actually remove them from the list. The comparison to determine what the highest priority index was also flawed because it was >= instead of simply > which would have preserved FIFO behavior while >= would not have.
    public void TestPriorityQueue_SameValuePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jon",1);
        priorityQueue.Enqueue("Steve",3);
        priorityQueue.Enqueue("Rick",2);        
        priorityQueue.Enqueue("Susan",3);
        string[] results = new string[2];
        results[0] = priorityQueue.Dequeue();
        results[1] = priorityQueue.Dequeue();
        // Expected results
        string[] expectedResults = new string[] {"Steve", "Susan"};
        // Assert arrays match
        CollectionAssert.AreEqual(expectedResults, results);
    }

    [TestMethod]
    // Scenario: Test if the last item of the list _queue is the last item added via the Enqueue() method
    // Expected Result: The strings match
    // Defect(s) Found: None. However, I did add a method in the PriorityQue class that will return the last item of the _queue list.
    public void TestPriorityQueue_Enqueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jon",1);
        priorityQueue.Enqueue("Steve",3);
        priorityQueue.Enqueue("Rick",2);        
        priorityQueue.Enqueue("Susan",3);
        string endOfQueue = priorityQueue.GetLastItem();
        
        // Assert strings match
        Assert.AreEqual(endOfQueue, "Susan");
    }

    [TestMethod]
    // Scenario: Test if an exception will get thrown when the queue list is empty
    // Expected Result: Exception is thrown when the queue list is empty and someone tries to dequeue.
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jon",1);
        string[] results = new string[2];
        results[0] = priorityQueue.Dequeue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}