public class StatPerk
{
    public string perkName;
    public System.Action applyPerk;

    public StatPerk(string name, System.Action perk)
    {
        this.perkName = name;
        this.applyPerk = perk;
    }
}
