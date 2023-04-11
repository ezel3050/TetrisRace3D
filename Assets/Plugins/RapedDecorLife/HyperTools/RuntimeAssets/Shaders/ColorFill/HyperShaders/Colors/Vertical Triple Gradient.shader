Shader "HyperShaders/Colors/Vertical Triple Gradient" {
	Properties {
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_ColorTop ("Top Color", Vector) = (1,0,0,1)
		_ColorMiddle ("Middle Color", Vector) = (0,1,0,1)
		_ColorBottom ("Bottom Color", Vector) = (0,0,1,1)
		_TopMap ("Top Map", Float) = 0.5
		_BottomMap ("Bottom Map", Float) = 0.5
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