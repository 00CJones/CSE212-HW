public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            // No duplicates
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else 
                return Left.Contains(value);
        }
        else
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Check if the node has left and right pointers to null
        if (Left == null && Right == null)
        {
            return 1; // Height of a single node tree is 1
        }
        int leftHeight;
        int rightHeight;
        // Recursive calls to calculate the height of left and right subtrees
        if (Left != null)
            leftHeight = Left.GetHeight();  // more nodes => keep going!
        else
            leftHeight = 0;                 // we reached the end of a branch
        if (Right != null)
            rightHeight = Right.GetHeight();
        else
            rightHeight = 0;

        // Alternate shorthand way of doing this, but I preferred the above form so that I could better visualize what was happening.
        // int leftHeight = Left?.GetHeight() ?? 0;    // this will set the value to 0 unless there is something to the left, in which case the method will be recursively called
        // int rightHeight = Right?.GetHeight() ?? 0;

        // Return the greater of the two heights + 1 (for the current node). This is how we keep track of the height as we go through the tree each time we reach the end of a branch.
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}