public class MainLevel : Level<object>
{
    public override void Load(object _)
    {
        gameObject.SetActive(true);
    }

    public override void Unload()
    {
        gameObject.SetActive(false);
    }
}