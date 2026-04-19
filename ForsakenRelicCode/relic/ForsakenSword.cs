using BaseLib.Abstracts;
using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.RelicPools;
using MegaCrit.Sts2.Core.Nodes.Rooms;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using MegaCrit.Sts2.Core.HoverTips;

namespace ForsakenRelic.ForsakenRelicCode.relic;



[Pool(typeof(SharedRelicPool))]
public class ForsakenSword() : ForsakenRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Common;
    
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<PoisonPower>(4M)];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<PoisonPower>()];


    public override async Task AfterDeath(
        PlayerChoiceContext choiceContext,
        Creature target,
        bool wasRemovalPrevented,
        float deathAnimLength)
    {
        ForsakenSword twistedFunnel = this;
        if (target.Side == twistedFunnel.Owner.Creature.Side)
            return;
        twistedFunnel.Flash();
        foreach (Creature hittableEnemy in (IEnumerable<Creature>) twistedFunnel.Owner.Creature.CombatState.HittableEnemies)
        {
            NCombatRoom instance = NCombatRoom.Instance;
            if (instance != null)
                instance.CombatVfxContainer.AddChildSafely((Node) NSmokePuffVfx.Create(hittableEnemy, NSmokePuffVfx.SmokePuffColor.Green));
        }
        await Cmd.CustomScaledWait(0.2f, 0.4f);
        foreach (Creature hittableEnemy in (IEnumerable<Creature>) twistedFunnel.Owner.Creature.CombatState.HittableEnemies)
        {
            PoisonPower poisonPower = await PowerCmd.Apply<PoisonPower>(hittableEnemy, (Decimal) twistedFunnel.DynamicVars["PoisonPower"].IntValue, twistedFunnel.Owner.Creature, (CardModel) null);
        }
    }
    

    
}
    
