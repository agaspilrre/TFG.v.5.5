// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33809,y:32738,varname:node_4013,prsc:2|diff-6492-OUT,transm-6571-OUT,lwrap-6571-OUT,voffset-8439-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32451,y:32489,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1621972,c2:0.3240215,c3:0.9191176,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3208,x:32172,y:32420,ptovrint:False,ptlb:WaterTex,ptin:_WaterTex,varname:node_3208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8f238cefa9b06644db7f34475c600377,ntxv:0,isnm:False|UVIN-6972-OUT;n:type:ShaderForge.SFN_Append,id:8664,x:30884,y:32468,varname:node_8664,prsc:2|A-3852-OUT,B-4068-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4068,x:30670,y:32564,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_4068,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:3852,x:30670,y:32468,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_3852,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4280,x:31173,y:32472,varname:node_4280,prsc:2|A-8664-OUT,B-4100-T;n:type:ShaderForge.SFN_Time,id:4100,x:30825,y:32688,varname:node_4100,prsc:2;n:type:ShaderForge.SFN_Add,id:6972,x:31357,y:32472,varname:node_6972,prsc:2|A-4280-OUT,B-6736-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6736,x:31159,y:32834,varname:node_6736,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Multiply,id:7824,x:32676,y:32342,varname:node_7824,prsc:2|A-3208-R,B-1304-RGB;n:type:ShaderForge.SFN_ValueProperty,id:6571,x:33409,y:33020,ptovrint:False,ptlb:Light,ptin:_Light,varname:node_6571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_OneMinus,id:6354,x:31438,y:32800,varname:node_6354,prsc:2|IN-6736-V;n:type:ShaderForge.SFN_Clamp01,id:7156,x:31628,y:32800,varname:node_7156,prsc:2|IN-6354-OUT;n:type:ShaderForge.SFN_Vector1,id:151,x:31671,y:32673,varname:node_151,prsc:2,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:3081,x:31830,y:32800,ptovrint:False,ptlb:Use gradient,ptin:_Usegradient,varname:node_3081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-151-OUT,B-7156-OUT;n:type:ShaderForge.SFN_Multiply,id:5910,x:32008,y:32921,varname:node_5910,prsc:2|A-3081-OUT,B-5013-R;n:type:ShaderForge.SFN_Tex2d,id:5013,x:31830,y:32996,ptovrint:False,ptlb:Wave,ptin:_Wave,varname:node_5013,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-6972-OUT;n:type:ShaderForge.SFN_RemapRange,id:3898,x:32210,y:32800,varname:node_3898,prsc:2,frmn:0,frmx:1,tomn:-5,tomx:10|IN-5910-OUT;n:type:ShaderForge.SFN_Clamp01,id:7740,x:32377,y:32800,varname:node_7740,prsc:2|IN-3898-OUT;n:type:ShaderForge.SFN_Add,id:5390,x:32870,y:32339,varname:node_5390,prsc:2|A-7824-OUT,B-7740-OUT;n:type:ShaderForge.SFN_Clamp01,id:6492,x:33090,y:32350,varname:node_6492,prsc:2|IN-5390-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4743,x:33226,y:32540,ptovrint:False,ptlb:Splash,ptin:_Splash,varname:node_4743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6492-OUT,B-1304-RGB;n:type:ShaderForge.SFN_Multiply,id:8207,x:32052,y:33260,varname:node_8207,prsc:2|A-5013-R,B-6736-Z;n:type:ShaderForge.SFN_SwitchProperty,id:1176,x:32327,y:33119,ptovrint:False,ptlb:Splash vertex,ptin:_Splashvertex,varname:node_1176,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5910-OUT,B-8207-OUT;n:type:ShaderForge.SFN_Multiply,id:8439,x:32648,y:33129,varname:node_8439,prsc:2|A-1176-OUT,B-3289-OUT,C-9467-OUT;n:type:ShaderForge.SFN_NormalVector,id:3289,x:32327,y:33276,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:9467,x:32340,y:33471,ptovrint:False,ptlb:Vertex_Power,ptin:_Vertex_Power,varname:node_9467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:1304-3208-4068-3852-6571-3081-5013-1176-9467;pass:END;sub:END;*/

Shader "Shader Forge/Waterfall01" {
    Properties {
        _Color ("Color", Color) = (0.1621972,0.3240215,0.9191176,1)
        _WaterTex ("WaterTex", 2D) = "white" {}
        _V_Speed ("V_Speed", Float ) = 0.5
        _U_Speed ("U_Speed", Float ) = 0
        _Light ("Light", Float ) = 1.2
        [MaterialToggle] _Usegradient ("Use gradient", Float ) = 1
        _Wave ("Wave", 2D) = "white" {}
        [MaterialToggle] _Splashvertex ("Splash vertex", Float ) = 0
        _Vertex_Power ("Vertex_Power", Float ) = 1
		_Cutoff ("Alpha cutoff", Range(0,1)) =0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _WaterTex; uniform float4 _WaterTex_ST;
            uniform float _V_Speed;
            uniform float _U_Speed;
            uniform float _Light;
            uniform fixed _Usegradient;
            uniform sampler2D _Wave; uniform float4 _Wave_ST;
            uniform fixed _Splashvertex;
            uniform float _Vertex_Power;
			half _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4100 = _Time;
                float2 node_6972 = ((float2(_U_Speed,_V_Speed)*node_4100.g)+o.uv0);
                float4 _Wave_var = tex2Dlod(_Wave,float4(TRANSFORM_TEX(node_6972, _Wave),0.0,0));
                float node_5910 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_Wave_var.r);
                v.vertex.xyz += (lerp( node_5910, (_Wave_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertex_Power);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_Light,_Light,_Light)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_Light,_Light,_Light);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_4100 = _Time;
                float2 node_6972 = ((float2(_U_Speed,_V_Speed)*node_4100.g)+i.uv0);
                float4 _WaterTex_var = tex2D(_WaterTex,TRANSFORM_TEX(node_6972, _WaterTex));
                float4 _Wave_var = tex2D(_Wave,TRANSFORM_TEX(node_6972, _Wave));
                float node_5910 = (lerp( 1.0, saturate((1.0 - i.uv0.g)), _Usegradient )*_Wave_var.r);
                float3 node_6492 = saturate(((_WaterTex_var.r*_Color.rgb)+saturate((node_5910*15.0+-5.0))));
                float3 diffuseColor = node_6492;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _WaterTex; uniform float4 _WaterTex_ST;
            uniform float _V_Speed;
            uniform float _U_Speed;
            uniform float _Light;
            uniform fixed _Usegradient;
            uniform sampler2D _Wave; uniform float4 _Wave_ST;
            uniform fixed _Splashvertex;
            uniform float _Vertex_Power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4100 = _Time;
                float2 node_6972 = ((float2(_U_Speed,_V_Speed)*node_4100.g)+o.uv0);
                float4 _Wave_var = tex2Dlod(_Wave,float4(TRANSFORM_TEX(node_6972, _Wave),0.0,0));
                float node_5910 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_Wave_var.r);
                v.vertex.xyz += (lerp( node_5910, (_Wave_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertex_Power);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_Light,_Light,_Light)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_Light,_Light,_Light);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 node_4100 = _Time;
                float2 node_6972 = ((float2(_U_Speed,_V_Speed)*node_4100.g)+i.uv0);
                float4 _WaterTex_var = tex2D(_WaterTex,TRANSFORM_TEX(node_6972, _WaterTex));
                float4 _Wave_var = tex2D(_Wave,TRANSFORM_TEX(node_6972, _Wave));
                float node_5910 = (lerp( 1.0, saturate((1.0 - i.uv0.g)), _Usegradient )*_Wave_var.r);
                float3 node_6492 = saturate(((_WaterTex_var.r*_Color.rgb)+saturate((node_5910*15.0+-5.0))));
                float3 diffuseColor = node_6492;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
				//clip(node_5910.r - _Cutoff);
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            uniform float _V_Speed;
            uniform float _U_Speed;
            uniform fixed _Usegradient;
            uniform sampler2D _Wave; uniform float4 _Wave_ST;
            uniform fixed _Splashvertex;
            uniform float _Vertex_Power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4100 = _Time;
                float2 node_6972 = ((float2(_U_Speed,_V_Speed)*node_4100.g)+o.uv0);
                float4 _Wave_var = tex2Dlod(_Wave,float4(TRANSFORM_TEX(node_6972, _Wave),0.0,0));
                float node_5910 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_Wave_var.r);
                v.vertex.xyz += (lerp( node_5910, (_Wave_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertex_Power);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
