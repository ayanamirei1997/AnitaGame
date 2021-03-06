// This file is generated. Do not edit it manually. Please edit .shaderproto files.

Shader "Anita/VFX/Wiggle"
{
    Properties
    {
        [HideInInspector] _MainTex ("Main Texture", 2D) = "white" {}
        _T ("Time", Range(0.0, 1.0)) = 0.0
        _XAmp ("X Amplitude", Float) = 0.0
        _YAmp ("Y Amplitude", Float) = 0.0
        _XFreq ("X Frequency", Float) = 0.0
        _YFreq ("Y Frequency", Float) = 0.0
        _TFreq ("T Frequency", Float) = 0.0
    }
    SubShader
    {
        Cull Off ZWrite Off Blend SrcAlpha OneMinusSrcAlpha
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Assets/Anita/CGInc/Rand.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            sampler2D _MainTex;
            float _T, _XAmp, _YAmp, _XFreq, _YFreq, _TFreq;

            fixed4 frag(v2f i) : SV_Target
            {
                float2 deltaUV = float2(_XAmp, _YAmp) * snoise2(float3(_XFreq * i.uv.x, _YFreq * i.uv.y, _TFreq * _Time.y)) * _T;
                return tex2D(_MainTex, i.uv + deltaUV) * i.color;
            }
            ENDCG
        }
    }
}
