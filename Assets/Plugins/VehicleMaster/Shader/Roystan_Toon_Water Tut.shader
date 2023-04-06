Shader "Roystan/Toon/Water Tut" {
	Properties {
		_DepthGradientDeep ("Depth Gradient Deep", Vector) = (0.086,0.407,1,0.749)
		_FoamColor ("Foam Color", Vector) = (1,1,1,1)
		_SurfaceNoise ("Surface Noise", 2D) = "white" {}
		_SurfaceNoiseScroll ("Surface Noise Scroll Amount", Vector) = (0.03,0.03,0,0)
		_SurfaceNoiseCutoff ("Surface Noise Cutoff", Range(0, 1)) = 0.777
		_SurfaceDistortion ("Surface Distortion", 2D) = "white" {}
		_SurfaceDistortionAmount ("Surface Distortion Amount", Range(0, 1)) = 0.27
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