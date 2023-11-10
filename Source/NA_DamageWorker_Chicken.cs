using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Nuff.Armory
{
    class NA_DamageWorker_Chicken : DamageWorker
    {
        /*
        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            Pawn chicken = PawnGenerator.GeneratePawn(new PawnGenerationRequest(NA_DefOf.NA_VoidChickenKind, faction: null, PawnGenerationContext.NonPlayer, forceGenerateNewPawn: true, fixedBiologicalAge: 1f));
            GenSpawn.Spawn(chicken, victim.Position, victim.Map);
            chicken.health.AddHediff(HediffDefOf.Scaria);
            chicken.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);

            return base.Apply(dinfo, victim);
        }
        */

        public override void ExplosionAffectCell(Explosion explosion, IntVec3 c, List<Thing> damagedThings, List<Thing> ignoredThings, bool canThrowMotes)
        {
            base.ExplosionAffectCell(explosion, c, damagedThings, ignoredThings, canThrowMotes);
            Pawn chicken = PawnGenerator.GeneratePawn(new PawnGenerationRequest(NA_DefOf.NA_VoidChickenKind, faction: null, PawnGenerationContext.NonPlayer, forceGenerateNewPawn: true, fixedBiologicalAge: 1f));
            GenSpawn.Spawn(chicken, c, explosion.Map);
            chicken.ClearMind();
            chicken.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, causedByDamage: true);
        }
    }
}
