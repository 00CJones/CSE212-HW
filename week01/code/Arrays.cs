using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // First, I will create an array variable of size "length" that will be the final
        // result to return that is of double type
        // Next, I will create a for loop that will run "length" amount of times
        // Lastly, in that for loop, I will multiply "number" by "length" in each loop
        // and add it to the array

        var result = new double[length];
        for (int i = 1; i <= length; i++){
            result[i - 1] = number * i;
        }
        Debug.WriteLine(result);
        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // First I will create two empty lists for list slicing. One for the first half
        // and one for the second half of the list.
        // I will need to use data.Count - amount to the end of data as my first
        // half and index 0 to data.Count - amount as my new second half.
        // Next I will use the property amount to define the first empty list and the second empty
        // list.
        // Next, I will concatinate the two lists together in the rotated order, adding
        // items from second half onto first half
        // Lastly, I will clear data and use the AddRange function to put in modified first 
        // half for the new data list

        List<int> newFirstHalf = data.GetRange(data.Count - amount, amount);
        List<int> newSecondHalf = data.GetRange(0,data.Count - amount);
        Debug.Write("Rotated newSecondHalf: ");
        foreach (int num in newSecondHalf)
        {
            Debug.Write(num);
        }
        foreach (int i in newSecondHalf)
        {
            newFirstHalf.Add(i);
        }
        data.Clear();
        data.AddRange(newFirstHalf);
        Debug.Write("Rotated Data: ");
        foreach (int num in data)
        {
            Debug.Write(num);
        }
        
    }
}
