Shader "UnityLibrary/Patterns/ScrollingFill" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		[ShowAsVector2] _Speed ("Speed", Vector) = (0,0,0,0)
		_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0
		_TintColor ("TintColor", Vector) = (1,1,1,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}