Shader "HyperShaders/Default With Clip" {
	Properties {
		_MainColor ("Main Color", Vector) = (1,1,1,1)
		_ShadowColor ("Shadow Color", Vector) = (0.5,0.5,0.5,1)
		_MainTex ("Main Texture", 2D) = "white" {}
		_MainColorRampTex ("Diffuse Ramp Map", 2D) = "white" {}
		_RimColor ("Rim Color", Vector) = (1,1,1,1)
		_RimLightPower ("Rim Light Power", Float) = 1
		_SpecTex ("Specular Texture", 2D) = "white" {}
		_SpecShininess ("Specular Shininess", Range(0, 1)) = 0.5
		_SpecIntensity ("Specular Intensity", Vector) = (1,1,1,1)
		_ReflectionTex ("Reflection Texture", 2D) = "white" {}
		_ReflectionCube ("Reflection Cube", Cube) = "" {}
		_EmissionMap ("Emission Map", 2D) = "black" {}
		_EmissionIntensity ("Emission Intensity", Range(0, 1)) = 1
		_ColorToLerp ("Color To Lerp", Vector) = (1,1,1,1)
		_LerpValue ("Lerp Value", Range(0, 1)) = 0
		_ColorR ("Color R", Vector) = (1,1,1,1)
		_ColorG ("Color G", Vector) = (1,1,1,1)
		_ColorB ("Color B", Vector) = (1,1,1,1)
		_FillAmount ("Fill Amount", Range(0, 1)) = 0
		_FillMaxAmount ("Fill Max Amount", Range(0, 5)) = 0
		_BottomPos ("Bottom Position", Vector) = (0,0,0,0)
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