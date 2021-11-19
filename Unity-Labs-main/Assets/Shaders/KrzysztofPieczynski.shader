// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/KrzysztofPieczynski"
{
    Properties
    {
        _TopColor("Top Color", Color) = (1,1,1,1)
        _BottomColor("Bottom Color", Color) = (1,0,0,1)
        _MaxValue("Max Value", Range(0,1)) = 1
        _MinValue("Min Value", Range(0,1)) = 0
        _StripWidth("Strip Width", Range(0,1)) = 0.3
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 uv : TEXCOORD0;
            };

            float4 _TopColor;
            float4 _BottomColor;
            float _MaxValue;
            float _MinValue;
            float _StripWidth;
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
               
            
            float t = _Time[1];

            t = t / 3;
            t = t - floor(t);
            
            float3 blend = float3(1,1,1);

            if (i.uv.y <t)
            {
                blend = float3(1, 0, 0);
            }
            if (i.uv.y < t - _StripWidth)
            {
                blend = float3(1, 1, 1);
            }
               
                return float4(blend, 1);
            }
            ENDCG
        }
    }
}
