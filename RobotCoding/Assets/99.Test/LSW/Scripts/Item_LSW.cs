using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Material,
    Game,
    Extra
}

[System.Serializable]
public class Item_LSW
{ 
    public string itemName;
    public string itemDiscription;
    public float itemWeight;
    public ItemType itemType;

    public Item_LSW(string name, float weight, string discription, ItemType type)
    {
        itemName = name;
        itemWeight = weight;
        itemDiscription = discription;
        itemType = type;
    }
}
[System.Serializable]
public class FoodItem : Item_LSW
{
    // 에너지, 수분, 스트레스
    public float energy;
    public float moisture;
    public float stress;
    public float expireDate;
    public FoodItem(string name, float weight, string discription, float er, float mr, float stress, float date)
        : base(name, weight, discription, ItemType.Food)
    {
        energy = er;
        moisture = mr;
        expireDate = date;
    }

}
[System.Serializable]
public class MaterialItem : Item_LSW
{

    public MaterialItem(string name, float weight, string discription)
        : base(name, weight, discription, ItemType.Material)
    {

    }


}
[System.Serializable]
public class GameItem : Item_LSW
{
    // 스트레스
    public float stress;
    public GameItem(string name, float weight, string discription, float stress)
        : base(name, weight, discription, ItemType.Game)
    {

    }


}
[System.Serializable]
public class ExtraItem : Item_LSW
{

    public ExtraItem(string name, float weight, string discription)
        : base(name, weight, discription, ItemType.Extra)
    {

    }


}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData_LSW: ScriptableObject
{
    public List<FoodItem> Foods = new List<FoodItem> ();
    public List<MaterialItem> Materials = new List<MaterialItem>();
    public List<GameItem> Games = new List<GameItem>();
    public List<ExtraItem> Extras = new List<ExtraItem>();

}
