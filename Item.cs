using System.Text;
public class Item
{
    public string Name { get; }
    public string Description { get; }
    public Stats StatsType { get; }
    public string StatsName { get; }
    public Equipment Type { get; set; }
    public int StatsValue { get; set; }
    public bool IsEquip { get; set; }
    public bool IsSale { get; set; }
    public int Price { get; set; }

    public Item(string name, string description, Equipment type, int statsValue, int price, bool isSale)
    {
        Name = name;
        Description = description;
        Type = type;
        StatsValue = statsValue;
        Price = price;
        IsEquip = false;
        IsSale = isSale;

        switch (Type)
        {
            case Equipment.Weapon:
                StatsName = "공격력";
                StatsType = Stats.Atk;
                break;
            case Equipment.Armor:
                StatsName = "방어력";
                StatsType = Stats.Def;
                break;
            default:
                StatsName = "체력";
                break;
        }
    }

    public bool BuyItem(Character player)
    {
        if (Price > player.Gold)
            return false;

        IsSale = false;
        player.Gold -= Price;
        player.AddItem(this);

        return true;
    }

    public void SaleItem(Character player)
    {
        IsSale = true;

        switch (Type)
        {
            case Equipment.Weapon:
                if (this.Equals(player.Weapon))
                {
                    player.UnEquipItem(Equipment.Weapon);
                }
                break;
            case Equipment.Armor:
                if (this.Equals(player.Armor))
                {
                    player.UnEquipItem(Equipment.Armor);
                }
                break;
        }

        player.Gold += (int)(Price * 0.85);
        player.RemoveItem(this);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(" ");
        if (IsEquip)
            sb.Append("[E]");
        sb.Append(Name.PadRight(10, ' '));
        sb.Append(" | ");
        sb.Append($"{StatsName} +{StatsValue}".PadRight(10, ' '));
        sb.Append(" | ");

        sb.Append(Description.PadRight(30, ' '));

        return sb.ToString();
    }

    public string ToStringBuy()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(ToString());
        sb.Append(" | ");

        if (IsSale)
        {
            sb.Append($"{Price} G");
        }
        else
        {
            sb.Append("구매완료");
        }
        return sb.ToString();
    }

    public string ToStringSale()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(ToString());
        sb.Append(" | ");
        sb.Append($"{Price} G");

        return sb.ToString();
    }
}