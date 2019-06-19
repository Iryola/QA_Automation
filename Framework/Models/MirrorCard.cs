using System;

namespace Framework.Models
{
    public class MirrorCard : Card
    {
        public override string Name => "Mirror";

        public override int Cost => 1;

        public override string Rarity => "Epic";

        public override string Type => "Spell";

        public override string Arena => "Arena 12";
    }
}
