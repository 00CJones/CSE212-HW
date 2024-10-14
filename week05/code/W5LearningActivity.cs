using System;

public class W5LearningActivity
{

    public int addnNumbers(int n)
    {
        if (n<=0)
        {
            return 0;
        }
        else
        {
            return n + addnNumbers(n - 1);
        }
    }
}