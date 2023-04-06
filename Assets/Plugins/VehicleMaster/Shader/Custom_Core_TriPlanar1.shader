Shader "Custom/Core/TriPlanar1" {
	Properties {
		[NoScaleOffset] _MainTex ("Top Texture", 2D) = "white" {}
		[NoScaleOffset] _MainTexSide ("Side/Bottom Texture", 2D) = "white" {}
		[NoScaleOffset] _Normal ("Normal/Noise", 2D) = "bump" {}
		_Scale ("Top Scale", Range(-2, 2)) = 1
		_SideScale ("Side Scale", Range(-2, 2)) = 1
		_NoiseScale ("Noise Scale", Range(-2, 2)) = 1
		_TopSpread ("TopSpread", Range(-2.5, 5)) = 1
		_ShadowColor ("Shadow Color", Vector) = (0,0,0,0)
		_ShadeColor ("Shade Color", Vector) = (0.5,0.5,0.5,0.5)
		_ShadeMin ("Shade Min", Range(-1, 1)) = 0
		_ShadeMax ("Shade Max", Range(-1, 1)) = 0
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
	Fallback "Diffuse"
}