using System;

namespace Framework.Models
{
    public class IceSpiritCard : Card
    {
        public override string Name => "Ice Spirit";

        public override int Cost => 1;

        public override string Rarity => "Common";

        public override string Type => "Troop";

        public override string Arena => "Arena 8";
    }
}
