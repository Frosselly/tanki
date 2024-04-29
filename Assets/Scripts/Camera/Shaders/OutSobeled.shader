
Shader "Custom/OutSobeledShader"
{
    
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness ("_Thickness", Range(0, 1)) = 1
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

           
            #include "Sobel.hlsl" // Include your Sobel.hlsl file

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Thickness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float thickness = 1.0; // Set your desired thickness here
                float output;
               PackHeightmapSobel(i.uv, _Thickness, output); // Call the sobel_float function

                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= output; // Apply the Sobel filter to the texture

                return col;
            }
            ENDCG
        }
    }
}
