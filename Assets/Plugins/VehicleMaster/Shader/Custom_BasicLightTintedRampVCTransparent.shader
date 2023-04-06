Shader "Custom/BasicLightTintedRampVCTransparent" {
	Properties {
		_ShadowColor ("Shadow Color", Vector) = (0,0,0,0)
		_VariationColor ("Variation Color", Vector) = (1,1,1,1)
		_ShadeColor ("Shade Color", Vector) = (0.5,0.5,0.5,0.5)
		_ShadeMin ("Shade Min", Range(-1, 1)) = 0
		_ShadeMax ("Shade Max", Range(-1, 1)) = 0
		_TintColor ("TintColor", Vector) = (1,1,1,1)
		_Transparency ("Transparency", Range(0, 1)) = 1
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
	Fallback "Diffuse"
}