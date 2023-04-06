Shader "Custom/ScrollingFill2" {
	Properties {
		_BackTex ("Back Texture", 2D) = "clear" {}
		_BackColor ("Back Color", Vector) = (1,1,1,1)
		_FrontTex ("Front Texture", 2D) = "white" {}
		_FrontColor ("Front Color", Vector) = (1,1,1,1)
		_TintColor ("Tint Color", Vector) = (1,1,1,1)
		[ShowAsVector2] _Speed ("Speed", Vector) = (0,0,0,0)
		_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}