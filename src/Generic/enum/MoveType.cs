public enum MoveType {
    None,
    ByInput,
    ByLine_Shooter,     // 面向发射者的方向
    ByLine_FaceTarget,  // 面向目标的方向
    ByTrack, //追踪
    StaticDirection,    // 静态方向
    RightLeft,
    DontMove
}