Shader "Custom/Core/TintColorAlpha" {
	Properties {
		_TintColor ("Tint Color", Vector) = (1,1,1,1)
		_AlphaFactor ("Alpha Factor", Range(0, 1)) = 1
		[Header(Blending)] [Enum(UnityEngine.Rendering.BlendMode)] _BlendSrc ("Blend Mode Source", Float) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _BlendDst ("Blend Mode Destination", Float) = 10
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