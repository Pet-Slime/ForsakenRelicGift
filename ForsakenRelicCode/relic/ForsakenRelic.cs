using BaseLib.Abstracts;
using BaseLib.Extensions;
using ForsakenRelic.ForsakenRelicCode.Extensions.StringExtensions;

namespace ForsakenRelic.ForsakenRelicCode.relic;

public abstract class ForsakenRelic : CustomRelicModel
{
    
    protected override string BigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();
    public override string PackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".SmallRelicImagePath();

    protected override string PackedIconOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".OutlineRelicImagePath();
    
    
    
}
