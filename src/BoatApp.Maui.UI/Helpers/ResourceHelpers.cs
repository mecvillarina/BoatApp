namespace BoatApp.Maui.UI.Helpers;

public static class ResourceHelpers
{
    public static object FindResource(this VisualElement o, string key)
    {
        while (o != null)
        {
            if (o.Resources.TryGetValue(key, out var r1)) return r1;
            if (o is Page) break;
            if (o is IElement e) o = e.Parent as VisualElement;
        }
        return FindResource(key);
    }

    public static object FindResource(string key)
    {
        if (Application.Current.Resources.TryGetValue(key, out var r2)) return r2;
        return null;
    }
}
