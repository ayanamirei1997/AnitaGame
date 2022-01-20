// This file is generated. Do not edit it manually. Please edit .shaderproto files.

Shader "Anita/VFX/Glow"
{
    Properties
    {
        [HideInInspector] _MainTex ("Main Texture", 2D) = "white" {}
        _T ("Time", Range(0.0, 1.0)) = 0.0
        _Size ("Size", Float) = 1.0
        _Strength ("Strength", Float) = 1.0
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
            #include "Assets/Anita/CGInc/Blur.cginc"

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
            float4 _MainTex_TexelSize;
            float _T, _Size, _Strength;


            fixed4 frag(v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv) * i.color;
                float4 glow = tex2DGaussianBlur(_MainTex, _MainTex_TexelSize * 1.0, i.uv, _Size * _T);
                glow = glow * glow;
                glow = glow * glow;
                glow *= _Strength * _T;
                col = saturate(col + glow - col * glow);
                col.a = 1.0;
                return col;
            }
            ENDCG
        }
    }
}
