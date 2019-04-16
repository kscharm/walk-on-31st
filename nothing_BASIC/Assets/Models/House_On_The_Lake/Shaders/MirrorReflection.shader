
Shader "FX/Mirror Reflection" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_BumpMap("Normalmap", 2D) = "bump" {}

	_ReflAmount("Reflection amount", float) = 0.5
		_ReflDistort("Reflection distort", float) = 0.25
		_ReflectionTex("Reflection", 2D) = "white" { TexGen ObjectLinear }
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf Lambert
		//#pragma surface surf BlinnPhong

		struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float4 screenPos;
	};

	uniform fixed4 _Color;
	uniform sampler2D _MainTex;
	uniform sampler2D _BumpMap;
	uniform float _ReflAmount;
	uniform float _ReflDistort;
	uniform sampler2D _ReflectionTex;

	void surf(Input IN, inout SurfaceOutput o) {

		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
		fixed3 nor = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

		fixed2 screenUV = (IN.screenPos.xy) / (IN.screenPos.w);
		screenUV.xy += nor *_ReflDistort;

		fixed4 refl = tex2D(_ReflectionTex, screenUV);

		o.Albedo = tex.rgb *_Color.rgb;
		o.Normal = nor.rgb;
		o.Emission = refl *_ReflAmount *tex.a;
		o.Specular = _Color.a;
		o.Gloss = tex.a;
		o.Alpha = tex.a;

	}
	ENDCG
	}

		FallBack "Diffuse"
}

