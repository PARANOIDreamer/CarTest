﻿Shader "Car/CarMirrors"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Mask("MaskTexture",2D) = "white"{}
	}
		SubShader
	{
		
		Tags { "RenderType" = "Transparent"}
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

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
			sampler2D _Mask;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float2 u = i.uv;
				u.x = 1 - i.uv.x;
                fixed4 col = tex2D(_MainTex, u);
				fixed4 mask = tex2D(_Mask, i.uv);
				col.a = mask.r;
				return col;
            }
            ENDCG
        }
    }
}
