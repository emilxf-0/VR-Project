Shader "Shade_Fog"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FogColor ("Fog Color", Color) = (0.5, 0.5, 0.5, 1)
        _FogDensity ("Fog Density", Range(0, 1)) = 0.05
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            sampler2D _MainTex;
            float4 _FogColor;
            float _FogDensity;

            half4 frag (v2f i) : SV_Target
            {
                // Calculate fog density based on distance
                float distance = length(i.worldPos - _WorldSpaceCameraPos);
                float fogFactor = 1.0 - exp(-_FogDensity * distance);

                // Blend fog color with the object's color
                half4 col = tex2D(_MainTex, i.worldPos.xy * _MainTex_TexelSize.xy + _MainTex_ST.xy);
                half4 foggedColor = lerp(col, _FogColor, fogFactor);

                return foggedColor;
            }
            ENDCG
        }
    }
}