public class ChanceGenerator 
{
    private static int _maxChance = 100;

    public static bool CheckChance(int chance)
    {
        int randomNumber = NumberGenerator.GenerateNumber(0, _maxChance);

        return randomNumber < chance;
    }
}