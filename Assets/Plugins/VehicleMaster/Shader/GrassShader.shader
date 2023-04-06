Shader "GrassShader" {
	Properties {
		[Header(Gradients)] _AlbedoColor ("AlbedoColor", 2D) = "white" {}
		[Header(Wind)] _WindIntensity ("WindIntensity", Float) = 0
		_WindScroll ("WindScroll", Float) = 0
		_WindStrength ("WindStrength", Float) = 10
		_WindScale ("WindScale", Float) = 2
		_Albedo ("Albedo", Vector) = (1,1,1,1)
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