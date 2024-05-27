using System;

public class NumberGenerator
{
    private static Random s_random = new Random();

    public static int GenerateNumber(int min, int max)
    {
        return s_random.Next(min, max);
    }
}
