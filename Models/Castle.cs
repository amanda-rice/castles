namespace castles.Models
{
  public class Castle
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int BuiltYear{ get; set; }
    private bool _destroyed;
    internal bool DestroyedWasSet { get; private set; }
    public bool Destroyed
    {
      get
      {
        return _destroyed;
      }
      set
      {
        _destroyed = value;
        DestroyedWasSet = true;
      }
    }
  }
}