Shader "Unlit/Occluder" {
    SubShader{
        Tags { "Queue" = "Geometry-1" }
        ColorMask 0
        ZWrite On
        Pass { }
    }
}