using System.Collections.Generic;
using System.Text;

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public double Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }
    public List<Item> Inventory { get; set; }

    public Item Weapon;
    public Item Armor;

    public Character(string name, string job, int level, double atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
        Weapon = null;
        Armor = null;
        Experience = 0;
        Inventory = new List<Item>();
    }

    public void inventorySort()
    {
        Inventory.Sort((x, y) =>
        {
            return x.Name.CompareTo(y.Name);
        });
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Inventory.Remove(item);
    }

    public void EquipItem(int index)
    {
        Item item = Inventory[index];

        item.IsEquip = true;

        switch (item.Type)
        {
            case Equipment.Weapon:
                if (!(Weapon is null))
                    UnEquipItem(Equipment.Weapon);

                Weapon = item;
                Atk += item.StatsValue;
                break;
            case Equipment.Armor:
                if (!(Armor is null))
                    UnEquipItem(Equipment.Armor);

                Armor = item;
                Def += item.StatsValue;
                break;
        }
    }

    public void UnEquipItem(Equipment equipment)
    {
        switch (equipment)
        {
            case Equipment.Weapon:
                Weapon.IsEquip = false;
                Atk -= Weapon.StatsValue;
                Weapon = null;
                break;
            case Equipment.Armor:
                Armor.IsEquip = false;
                Def -= Armor.StatsValue;
                Armor = null;
                break;
        }
    }

    public void Rest()
    {
        Gold -= 500;
        Hp += 50;

        if (Hp > 100)
            Hp = 100;
    }

    public void LevelUp()
    {
        Level++;
        Experience = 0;
        Atk += 0.5;
        Def += 1;
        Hp = 100;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();


        return sb.ToString();
    }
}