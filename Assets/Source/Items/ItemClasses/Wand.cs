using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses
{
    public enum WandsEnum
    {
        AdeptsWand,
        DruidsWand,
        ArchmagesWandOfWisdom,
        GreatWandOfAnnihilation,
        SailorMoonWand
    }
    public class Wand : Item, IEquippable
    {
        public override ItemType ItemType => ItemType.Weapon;
        public override bool IsEquippable => true;
        public bool IsEquipped { get; private set; } = false;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int Inteligence { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }

        
        public Wand(WandsEnum type)
        {
            switch (type)
            {
                case WandsEnum.AdeptsWand:
                    DefaultSpriteId = 233;
                    DefaultName = "Adept's Wand";
                    Inteligence = 1;
                    MaxDurability = 120;
                    CurrentDurability = 120;
                    break;
                case WandsEnum.DruidsWand:
                    DefaultSpriteId = 226;
                    DefaultName = "DruidsWand";
                    Inteligence = 4;
                    MaxDurability = 30;
                    CurrentDurability = 30;
                    break;
                case WandsEnum.ArchmagesWandOfWisdom:
                    DefaultSpriteId = 271;
                    DefaultName = "Archmage's Wand of Wisdom";
                    Inteligence = 10;
                    MaxDurability = 15;
                    CurrentDurability = 15;
                    break;
                case WandsEnum.GreatWandOfAnnihilation:
                    DefaultSpriteId = 272;
                    DefaultName = "Great Wand of Annihilation";
                    Inteligence = 15;
                    MaxDurability = 10;
                    CurrentDurability = 10;
                    break;
                case WandsEnum.SailorMoonWand:
                    DefaultSpriteId = 225;
                    DefaultName = "Sailor Moon Wand";
                    Inteligence = 25;
                    MaxDurability = 5;
                    CurrentDurability = 5;
                    break;
            }
        }

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += IsEquipped ? -Inteligence : Inteligence;
            IsEquipped = !IsEquipped;
            
            DecreaseItemDurability();
        }
        
    }
}