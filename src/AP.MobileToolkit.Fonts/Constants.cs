namespace AP.MobileToolkit.Fonts
{
    internal static class Constants
    {
        internal const string ResolutionGroupName = "AvantiPoint";

        internal const string ImageEntryEffect = nameof(ImageEntryEffect);

        internal static string GetEffectName(string effect) =>
            $"{ResolutionGroupName}.{effect}";
    }
}
