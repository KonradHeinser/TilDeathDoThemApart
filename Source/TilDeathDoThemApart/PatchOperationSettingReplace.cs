using System;
using System.Linq;
using System.Xml;
using Verse;

namespace TilDeathDoThemApart
{
    public class PatchOperationSettingReplace : PatchOperationPathed
    {
        public string setting;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            if (setting == null)
                Log.Error("setting not set in xml");
            var value = typeof(TilDeathDoThemApart_Settings).GetField(setting)?.GetValue(typeof(TilDeathDoThemApart_Settings));
            if (value == null)
                Log.Error("setting not found");
            else
            {
                XmlNode[] array = xml.SelectNodes(xpath)?.Cast<XmlNode>()?.ToArray() ?? Array.Empty<XmlNode>();
                if (!array.NullOrEmpty())
                    foreach (XmlNode xmlNode in array)
                        xmlNode.InnerText = value.ToString();
                else
                    Log.Warning("No valid targets found at " + xpath);
            }
        
            return true;
        }
    }
}
