// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Scan"
{
	Properties
	{
		_RimColor("RimColor", Color) = (0,0,0,0)
		_InnerColor("InnerColor", Color) = (0,0,0,0)
		_RimIntensity("RimIntensity", Float) = 0
		_FlowEmiss("FlowEmiss", 2D) = "white" {}
		_Speed("Speed", Vector) = (0,0,0,0)
		_FlowIntensity("FlowIntensity", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float3 worldPos;
		};

		uniform float4 _InnerColor;
		uniform float4 _RimColor;
		uniform float _RimIntensity;
		uniform sampler2D _FlowEmiss;
		uniform float2 _Speed;
		uniform float _FlowIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Albedo = _InnerColor.rgb;
			float3 ase_worldPos = i.worldPos;
			float2 appendResult30 = (float2(ase_worldPos.x , ase_worldPos.y));
			float3 objToWorld31 = mul( unity_ObjectToWorld, float4( float3(0,0,0), 1 ) ).xyz;
			float2 appendResult35 = (float2(objToWorld31.x , objToWorld31.y));
			o.Emission = ( ( _RimColor * _RimIntensity ) + ( tex2D( _FlowEmiss, ( ( appendResult30 - appendResult35 ) + ( _Speed * _Time.y ) ) ) * _FlowIntensity ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
0;0;1920;1018;2661.379;527.9429;1.623093;True;False
Node;AmplifyShaderEditor.Vector3Node;34;-1849.968,249.8119;Inherit;False;Constant;_Vector0;Vector 0;10;0;Create;True;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TransformPositionNode;31;-1663.97,250.8119;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode;29;-1647.418,92.55324;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;30;-1431.419,110.5533;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;28;-1425.009,553.5754;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;25;-1422.56,383.4199;Inherit;False;Property;_Speed;Speed;4;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DynamicAppendNode;35;-1425.97,277.8119;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;32;-1204.401,175.6911;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-1210.793,373.6637;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;26;-1037.61,256.8217;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;39;-815.2932,437.0077;Inherit;False;Property;_FlowIntensity;FlowIntensity;5;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;23;-890.0764,223.4106;Inherit;True;Property;_FlowEmiss;FlowEmiss;3;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;22;-861.933,112.9674;Inherit;False;Property;_RimIntensity;RimIntensity;2;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;19;-887.3831,-84.42654;Inherit;False;Property;_RimColor;RimColor;0;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;-546.42,243.6857;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-605.2328,57.78121;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;18;-416.7931,-80.79204;Inherit;False;Property;_InnerColor;InnerColor;1;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;42;-370.2993,114.2941;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-120.3038,58.52264;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Scan;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;31;0;34;0
WireConnection;30;0;29;1
WireConnection;30;1;29;2
WireConnection;35;0;31;1
WireConnection;35;1;31;2
WireConnection;32;0;30;0
WireConnection;32;1;35;0
WireConnection;27;0;25;0
WireConnection;27;1;28;0
WireConnection;26;0;32;0
WireConnection;26;1;27;0
WireConnection;23;1;26;0
WireConnection;40;0;23;0
WireConnection;40;1;39;0
WireConnection;21;0;19;0
WireConnection;21;1;22;0
WireConnection;42;0;21;0
WireConnection;42;1;40;0
WireConnection;0;0;18;0
WireConnection;0;2;42;0
ASEEND*/
//CHKSM=C75F7C5C0DE9AAFB088E11D9D0A58AF53881154B