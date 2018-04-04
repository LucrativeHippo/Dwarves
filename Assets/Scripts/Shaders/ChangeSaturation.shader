Shader "Hidden/ChangeSaturation"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SatMagnitude("SatMagnitude", Range(0, 1)) = 1
		_Displace("Displace", Range(0, 1)) = 0 // Boolean. 1 = True.
		_DisMagnitude("DisMagnitude", Range(0, 0.1)) = 0.0
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_Halo("Halo", Range(0, 1)) = 0 // Boolean. 1 = True.
		_HaloMagnitude("HaloMagnitude", Range(0, 1)) = 0

	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float3 rgb2hsv (float3 rgb) 
			{
				float4 k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = rgb.g < rgb.b ? float4(rgb.b, rgb.g, k.w, k.z) : float4(rgb.gb, k.xy);
				float4 q = rgb.r < p.x ? float4(p.x, p.y, p.w, rgb.r) : float4(rgb.r, p.yzx);
				float d = q.x - min(q.w, q.y);
				float e = 1.0e-10;
				float3 hsv = float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);

				return hsv;
			}

			float3 hsv2rgb(float3 hsv) 
			{
				float4 k = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
				float3 p = abs(frac(hsv.xxx + k.xyz) * 6.0 - k.www);
				float3 rgb = hsv.z * lerp(k.xxx, clamp(p - k.xxx, 0.0, 1.0), hsv.y);

				return rgb;
			}

			// Vertex Shader
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _SatMagnitude;
			float _DisMagnitude;
			float _Displace;
			float _Halo;
			float _HaloMagnitude;

			// Fragment Shader
			fixed4 frag (v2f i) : SV_Target
			{
				float2 disp = float2(0, 0);

				if (_Displace == 1) 
				{
					float2 distuv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);

					disp = tex2D(_DisplaceTex, distuv).xy;
					disp = ((disp * 2) - 1) * _DisMagnitude;
				}

				float4 col = tex2D(_MainTex, i.uv + (disp));

				// Change saturation
				float3 hsv = rgb2hsv(col.rgb);
				hsv.y *= _SatMagnitude;

				// Halo Effect on outside of screen.
				if (_Halo == 1) {
					float distX = abs(0.5 - i.uv.x);
					float distY = abs(0.5 - i.uv.y);

					float dist = sqrt((distX * distX) + (distY * distY)) * _HaloMagnitude;
					float darkenAmount = (1 - dist);

					hsv.z *= darkenAmount;
				}
				
				float3 rgb = hsv2rgb(hsv);
				col.rgb = float3(rgb.r, rgb.g, rgb.b);

				return col;
			}
			ENDCG
		}
	}
}
