namespace Diamond.Generators;

public class CharacterDiamond
{
    public CharacterDiamond(IEnumerable<Tuple<uint, char[]>> data)
    {
        Data = data;
    }

    public IEnumerable<Tuple<uint, char[]>> Data { get;  }
}