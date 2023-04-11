Shader "Unpacking/StuffOutline" {
	Properties {
		_OutlineColor1 ("Outline Color 1", Vector) = (1,1,1,1)
		_OutlineColor2 ("Outline Color 2", Vector) = (1,0,0,1)
		_OutlineWidth ("Outline Width", Range(0, 10)) = 2
		_FlickSpeed ("Flick Speed", Range(0, 10)) = 2
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