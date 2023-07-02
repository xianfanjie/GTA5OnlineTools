namespace GTA5Core.GTA.Objects;

public static class CCTV
{
    /// <summary>
    /// 太空坐标
    /// </summary>
    public static readonly Vector3 SpacePos = new(9999.0f, 9999.0f, 9999.0f);

    /// <summary>
    /// 全部 cctv_cam Hash值 
    /// https://gtahash.ru/?s=cctv_cam
    /// </summary>
    public static readonly List<long> CameraHashs = new()
    {
        168901740,      // prop_cctv_cam_06a
        3199670845,     // prop_cctv_cam_04a
        4121760380,     // prop_cctv_cam_05a
        3135545872,     // prop_cctv_cam_02a
        548760764,      // prop_cctv_cam_01a
        2954561821,     // prop_cctv_cam_07a
        3940745496,     // prop_cctv_cam_01b
        1919058329,     // prop_cctv_cam_04b
        1449155105,     // prop_cctv_cam_03a
        2410265639      // prop_cctv_cam_04c
    };
}
