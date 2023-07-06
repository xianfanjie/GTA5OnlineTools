namespace GTA5Core.Features;

public static class Outfits
{
    // Outfit Editor Globals from VenomKY
    private const int oWardrobeG = 2359296;
    private const int oWPointA = 5568;
    private const int oWPointB = 681;
    private const int oWComponent = 1336;
    private const int oWComponentTex = 1610;
    private const int oWProp = 1884;
    private const int oWPropTex = 2095;

    /// <summary>
    /// 范围0~19
    /// </summary>
    public static int OutfitIndex = 0;

    /// <summary>
    /// 通过索引获取服装名字
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string GetOutfitNameByIndex()
    {
        return Globals.Get_Global_String(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 1126 - OutfitIndex * 5);
    }

    /// <summary>
    /// 通过索引设置服装名字
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    public static void SetOutfitNameByIndex(string name)
    {
        Globals.Set_Global_String(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 1126 - OutfitIndex * 5, name);
    }

    //////////////////////// TOP ////////////////////////

    public static int TOP
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 14);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 14, value);
    }

    public static int TOP_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 14);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 14, value);
    }

    //////////////////////// UNDERSHIRT ////////////////////////

    public static int UNDERSHIRT
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 11);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 11, value);
    }

    public static int UNDERSHIRT_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 11);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 11, value);
    }

    //////////////////////// LEGS ////////////////////////

    public static int LEGS
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 7);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 7, value);
    }

    public static int LEGS_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 7);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 7, value);
    }

    //////////////////////// FEET ////////////////////////

    public static int FEET
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 9);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 9, value);
    }

    public static int FEET_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 9);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 9, value);
    }

    //////////////////////// ACCESSORIES ////////////////////////

    public static int ACCESSORIES
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 10);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 10, value);
    }

    public static int ACCESSORIES_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 10);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 10, value);
    }

    //////////////////////// BAGS ////////////////////////

    public static int BAGS
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 8);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 8, value);
    }

    public static int BAGS_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 8);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 8, value);
    }

    //////////////////////// GLOVES ////////////////////////

    public static int GLOVES
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 6);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 6, value);
    }

    public static int GLOVES_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 6);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 6, value);
    }

    //////////////////////// DECALS ////////////////////////

    public static int DECALS
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 13);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 13, value);
    }

    public static int DECALS_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 13);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 13, value);
    }

    //////////////////////// MASK ////////////////////////

    public static int MASK
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 4);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 4, value);
    }

    public static int MASK_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 4);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 4, value);
    }

    //////////////////////// ARMOR ////////////////////////

    public static int ARMOR
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 12);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponent + OutfitIndex * 13 + 12, value);
    }

    public static int ARMOR_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 12);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWComponentTex + OutfitIndex * 13 + 12, value);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////////////////////// HATS ////////////////////////

    public static int HATS
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 3);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 3, value);
    }

    public static int HATS_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 3);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 3, value);
    }

    //////////////////////// GLASSES ////////////////////////

    public static int GLASSES
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 4);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 4, value);
    }

    public static int GLASSES_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 4);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 4, value);
    }

    //////////////////////// EARS ////////////////////////

    public static int EARS
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 5);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 5, value);
    }

    public static int EARS_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 5);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 5, value);
    }

    //////////////////////// WATCHES ////////////////////////

    public static int WATCHES
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 9);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 9, value);
    }

    public static int WATCHES_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 9);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 9, value);
    }

    //////////////////////// WRIST ////////////////////////

    public static int WRIST
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 10);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWProp + OutfitIndex * 10 + 10, value);
    }

    public static int WRIST_TEX
    {
        get => Globals.Get_Global_Value<int>(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 10);
        set => Globals.Set_Global_Value(oWardrobeG + 0 * oWPointA + oWPointB + oWPropTex + OutfitIndex * 10 + 10, value);
    }
}
