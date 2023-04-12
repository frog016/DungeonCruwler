public static class StructureExtensions
{
    public static int Sign(this int value)
    {
        return value == 0 ? 0 : value > 0 ? 1 : -1;
    }

    public static int Sign(this float value)
    {
        return value == 0 ? 0 : value > 0 ? 1 : -1;
    }
}