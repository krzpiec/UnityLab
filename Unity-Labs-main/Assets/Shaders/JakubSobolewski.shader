Shader "Unlit/JakubSobolewski"
{
    Properties
    {

        //_MainTex("Texture", 2D) = "white" {}
        _Period("Color Change Period", Float) = 3
        _BlendStrenght("Blend Strength", Range(0.0, 1.0)) = 1
        /*_Color ("Color", Color) = (1,1,1,1)

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {



            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
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
            UNITY_FOG_COORDS(1)
            float4 vertex : SV_POSITION;
        };

        sampler2D _MainTex;
        float4 _MainTex_ST;


        fixed3 mix(fixed3 x, fixed3 y, fixed a) {
            return x * ((1 - a) + y) * a;
        }

        fixed3 hsv2rgb(fixed3 c)
        {
            fixed4 K = fixed4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
            //fixed3 p = abs(fract(c.rrr + K.rgb) * 6.0 - K.aaa);
            fixed3 tmp = c.xxx + K.xyz;
            fixed3 p = abs((tmp - floor(tmp)) * 6.0 - K.www);
            return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
            //return c;
        }

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            UNITY_TRANSFER_FOG(o,o.vertex);
            return o;
        }

        float _Period;
        float _BlendStrenght;
        fixed4 frag(v2f i) : SV_Target
        {
            // sample the texture
            //fixed4 col = tex2D(_MainTex, i.uv);
            // apply fog

            float t = _Time[1];

            t = t / _Period;
            t = t - floor(t);

            fixed3 hsv = fixed3(t, 1,1);
            fixed4 col = fixed4(hsv2rgb(hsv), 1);//fixed4(0, 1, 1, t);


            //UNITY_APPLY_FOG(i.fogCoord, col);
            return col;
        }
    ENDCG
    }
    }
}
