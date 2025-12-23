using UnityEngine;
using Verse;

namespace TilDeathDoThemApart
{
    public class TilDeathDoThemApart_Mod : Mod
    {
        internal static TilDeathDoThemApart_Settings settings;
    
        public TilDeathDoThemApart_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<TilDeathDoThemApart_Settings>();
        }
    
        public override string SettingsCategory()
        {
            return "TDDTA".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            settings.DoWindowContents(inRect);
        }
    }

    public class TilDeathDoThemApart_Settings : ModSettings
    {
        public static int marriageOpinion = 200;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref marriageOpinion, "marriageOpinion", 200);
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard optionsMenu = new Listing_Standard();
            var innerContainer = inRect.ContractedBy(1);
            Widgets.DrawBoxSolid(innerContainer, new ColorInt(37, 37, 37).ToColor);
            var frameRect = innerContainer.ContractedBy(5);
            var contentRect = frameRect.ContractedBy(10);
            optionsMenu.Begin(contentRect);

            marriageOpinion = Mathf.FloorToInt(optionsMenu.SliderLabeled("Opinion".Translate() + $" ({marriageOpinion})", marriageOpinion, 35, 200, 0.2f, "OpinionOverride".Translate()));
        
            optionsMenu.End();
            Write();
        }
    }
}