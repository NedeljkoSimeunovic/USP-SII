using USP.Domain.Enums;

namespace USP.Domain.Extensions;

public class EnumeExtension
{
    public static readonly string ValidCategoryLisst = 
        string.Join(",", Category.List.Select(x => x.Name + "-" + x.Value));
}