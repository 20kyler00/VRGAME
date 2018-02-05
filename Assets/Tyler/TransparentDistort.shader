Shader "Unlit/Transparent Distort"
{
    Properties
    {
        _ColorA("Main Color A", Color) = (1,1,1)
        _ColorB("Main Color B", Color) = (1,1,1)
        _Tint("Extra Texture Tint", Color) = (1,1,1)
        _MainTex("Texture", 2D) = "white" {}
    _MainScroll("MainTex Scroll/Distort", Range(-2,2)) = 1
        _ExtraTex("ExtraTexture", 2D) = "white" {}
    _DistortTex("Distort Texture", 2D) = "white" {}
    _Offset("Offset Gradient A/B", Range(-2,2)) = 1
        _XSpeed("X Scrolling Speed", Range(-2,2)) = 1
        _YSpeed("Y Scrolling Speed", Range(-4,4)) = 1
        _XDistort("X Distortion Amount", Range(0,2)) = 1
        _YDistort("Y Distortion Amount", Range(0,2)) = 0
        [MaterialToggle] DISTORTMAIN("Distort Main Tex", Float) = 0
    }
        SubShader
    {
        Tags{ "RenderType" = "Opaque" }
        LOD 100
        Zwrite Off
        Blend One One // additive blending
 
        Pass
    {
        CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile _ DISTORTMAIN_ON
        // make fog work
#pragma multi_compile_fog
 
#include "UnityCG.cginc"
 
    struct appdata
    {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };
 
    struct v2f
    {
        float2 uv : TEXCOORD0;
        float2 uv2 : TEXCOORD1;
        UNITY_FOG_COORDS(1)
            float4 vertex : SV_POSITION;
        float4 col : COLOR;
    };
 
    sampler2D _MainTex, _DistortTex, _ExtraTex;
    float4 _MainTex_ST, _ExtraTex_ST;
    float4 _ColorA, _ColorB, _Tint;
    float _Offset, _XDistort, _YDistort, _XSpeed, _YSpeed, _MainScroll;
    v2f vert(appdata v)
    {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        o.uv2 = TRANSFORM_TEX(v.uv, _ExtraTex);
        o.col = lerp(_ColorA, _ColorB, v.vertex.y + _Offset); // gradient over vertex
        UNITY_TRANSFER_FOG(o,o.vertex);
        return o;
    }
 
    fixed4 frag(v2f i) : SV_Target
    {
        // sample the texture
        fixed distort = tex2D(_DistortTex, i.uv - _Time.x).a;// distortion alpha
    fixed4 maintex = tex2D(_MainTex, i.uv + (_Time.x * _MainScroll)) * i.col; // first texture
#ifdef DISTORTMAIN_ON
    maintex = tex2D(_MainTex, i.uv + (distort * _MainScroll)) * i.col; // first texture with distortion
#endif
    fixed4 extratex = tex2D(_ExtraTex, fixed2(i.uv2.x - (distort * _XDistort) - (_Time.x * _XSpeed), i.uv2.y + (distort * _YDistort) + (_Time.x * _YSpeed))); // extra texture distortion
 
    maintex = lerp(extratex * _Tint, maintex, maintex.a);// lerp of first and extra texture
                                                         // apply fog
    UNITY_APPLY_FOG(i.fogCoord, maintex);
    return maintex;
    }
        ENDCG
    }
    }
}