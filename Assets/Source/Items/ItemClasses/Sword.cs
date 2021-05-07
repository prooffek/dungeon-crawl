using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Items
{
    enum SwordsEnum
    {
        SoldiersSword,
        KnightSword,
        KingsSwordOfPower,
        EthernalSwordOfDestruction
    }
    public class Sword : Item
    {
        public override ItemType ItemType => ItemType.Weapon;
        public override bool IsEquippable => true;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }
        public int DamagePoints { get; }
        
    
        public Sword(string type)
        {
            switch (type)
            {
                case "SoldiersSword":
                    DefaultSpriteId = 320;
                    DefaultName = "Soldier's Sword";
                    DamagePoints = 1;
                    MaxDurability = 50;
                    CurrentDurability = 50;
                    break;
                case "KnightSword":
                    DefaultSpriteId = 416;
                    DefaultName = "Knight Sword";
                    DamagePoints = 4;
                    MaxDurability = 30;
                    CurrentDurability = 30;
                    break;
                case "KingsSwordOfPower":
                    DefaultSpriteId = 417;
                    DefaultName = "King's Sword of Power";
                    DamagePoints = 10;
                    MaxDurability = 15;
                    CurrentDurability = 15;
                    break;
                case "EthernalSwordOfDestruction":
                    DefaultSpriteId = 464;
                    DefaultName = "Ethernal Sword of Destruction";
                    DamagePoints = 15;
                    MaxDurability = 10;
                    CurrentDurability = 10;
                    break;
            }
        }
        
        
        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            if (isEquipted)
                player.AttackPoints += DamagePoints;
            else
                player.AttackPoints -= DamagePoints;
            
            DecreaseItemDurability();
        }
    }
}