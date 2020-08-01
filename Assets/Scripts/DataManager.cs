// This is a static class, which makes it 
// possible to exchange information with scenes.
public static class DataManager
{
    private static string userName;

    public static string UserName
    {
        get
        {
            return userName;
        }
        set
        {
            userName = value;
        }
    }
}
