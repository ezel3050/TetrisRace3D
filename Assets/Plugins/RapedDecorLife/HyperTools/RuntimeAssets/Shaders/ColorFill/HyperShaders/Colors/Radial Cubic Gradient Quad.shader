Shader "HyperShaders/Colors/Radial Cubic Gradient Quad" {
	Properties {
		_ColorA ("Inner Color", Vector) = (1,1,1,1)
		_ColorB ("Outer Color", Vector) = (0,0,0,1)
		_Value ("Gradient Value", Range(0, 1)) = 0.5
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