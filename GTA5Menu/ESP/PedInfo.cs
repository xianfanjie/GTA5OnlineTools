namespace GTA5Menu.ESP;

public class PedInfo
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float PCTGealth { get; set; }
    public string Name { get; set; }
    public Vector3 Position { get; set; }
    public float Distance { get; set; }
    public Vector2 Heading { get; set; }
    public Vector2 Screen { get; set; }
    public Vector2 Box { get; set; }

    public void Reset()
    {
        Health = 0;
        MaxHealth = 0;
        PCTGealth = 0;
        Name = string.Empty;
        Position = Vector3.Zero;
        Distance = 0;
        Heading = Vector2.Zero;
        Screen = Vector2.Zero;
        Box = Vector2.Zero;
    }
}
