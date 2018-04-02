// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-4364-OUT,transm-6187-OUT,lwrap-6187-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32249,y:32621,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3321799,c2:0.5631786,c3:0.9411765,c4:1;n:type:ShaderForge.SFN_Tex2d,id:379,x:31114,y:32956,varname:node_379,prsc:2,tex:f700d7fde488a784887afde554fe8e50,ntxv:0,isnm:False|TEX-6082-TEX;n:type:ShaderForge.SFN_Tex2d,id:6114,x:31102,y:32762,varname:node_6114,prsc:2,tex:f700d7fde488a784887afde554fe8e50,ntxv:0,isnm:False|UVIN-4011-OUT,TEX-6082-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6082,x:30799,y:32836,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_6082,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f700d7fde488a784887afde554fe8e50,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:5429,x:30431,y:33054,varname:node_5429,prsc:2|A-7324-OUT,B-6692-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6692,x:30217,y:33150,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_4068,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.2;n:type:ShaderForge.SFN_ValueProperty,id:7324,x:30217,y:33054,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_3852,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.25;n:type:ShaderForge.SFN_Multiply,id:1319,x:30720,y:33058,varname:node_1319,prsc:2|A-5429-OUT,B-9161-T;n:type:ShaderForge.SFN_Time,id:9161,x:30372,y:33273,varname:node_9161,prsc:2;n:type:ShaderForge.SFN_Add,id:4011,x:30892,y:33058,varname:node_4011,prsc:2|A-1319-OUT,B-5891-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5891,x:30680,y:33267,varname:node_5891,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Append,id:5586,x:30420,y:33465,varname:node_5586,prsc:2|A-4106-OUT,B-4281-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4281,x:30206,y:33561,ptovrint:False,ptlb:V_Speed_copy,ptin:_V_Speed_copy,varname:_V_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.3;n:type:ShaderForge.SFN_ValueProperty,id:4106,x:30206,y:33465,ptovrint:False,ptlb:U_Speed_copy,ptin:_U_Speed_copy,varname:_U_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:2427,x:30709,y:33469,varname:node_2427,prsc:2|A-5586-OUT,B-9161-T;n:type:ShaderForge.SFN_Add,id:5480,x:30881,y:33469,varname:node_5480,prsc:2|A-2427-OUT,B-5891-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5021,x:31328,y:32808,varname:node_5021,prsc:2|A-6114-R,B-379-G,C-479-OUT;n:type:ShaderForge.SFN_RemapRange,id:6141,x:31520,y:32808,varname:node_6141,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5021-OUT;n:type:ShaderForge.SFN_Clamp01,id:9573,x:31712,y:32808,varname:node_9573,prsc:2|IN-6141-OUT;n:type:ShaderForge.SFN_Vector1,id:479,x:31217,y:33123,varname:node_479,prsc:2,v1:3;n:type:ShaderForge.SFN_OneMinus,id:8625,x:31342,y:33301,varname:node_8625,prsc:2|IN-5891-V;n:type:ShaderForge.SFN_Add,id:4364,x:32384,y:32825,varname:node_4364,prsc:2|A-1304-RGB,B-718-OUT;n:type:ShaderForge.SFN_Power,id:4329,x:31602,y:33303,varname:node_4329,prsc:2|VAL-8625-OUT,EXP-5613-OUT;n:type:ShaderForge.SFN_Vector1,id:5613,x:31329,y:33461,varname:node_5613,prsc:2,v1:1.4;n:type:ShaderForge.SFN_Multiply,id:4317,x:31786,y:33303,varname:node_4317,prsc:2|A-4329-OUT,B-2103-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2103,x:31602,y:33479,ptovrint:False,ptlb:Center_Glow,ptin:_Center_Glow,varname:node_2103,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:7218,x:31939,y:32823,varname:node_7218,prsc:2|A-9573-OUT,B-4317-OUT;n:type:ShaderForge.SFN_Clamp01,id:718,x:32129,y:32835,varname:node_718,prsc:2|IN-7218-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6187,x:32370,y:33023,ptovrint:False,ptlb:Light,ptin:_Light,varname:node_6187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:1304-6082-6692-7324-2103-6187;pass:END;sub:END;*/

Shader "Shader Forge/Waterfall02" {
    Properties {
        _Color ("Color", Color) = (0.3321799,0.5631786,0.9411765,1)
        _Noise ("Noise", 2D) = "white" {}
        _V_Speed ("V_Speed", Float ) = -0.2
        _U_Speed ("U_Speed", Float ) = -0.25
        _Center_Glow ("Center_Glow", Float ) = 3
        _Light ("Light", Float ) = 0
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _V_Speed;
            uniform float _U_Speed;
            uniform float _Center_Glow;
            uniform float _Light;
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
                float4 node_9161 = _Time;
                float2 node_4011 = ((float2(_U_Speed,_V_Speed)*node_9161.g)+i.uv0);
                float4 node_6114 = tex2D(_Noise,TRANSFORM_TEX(node_4011, _Noise));
                float4 node_379 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 diffuseColor = (_Color.rgb+saturate((saturate(((node_6114.r*node_379.g*3.0)*2.0+-1.0))*(pow((1.0 - i.uv0.g),1.4)*_Center_Glow))));
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
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _V_Speed;
            uniform float _U_Speed;
            uniform float _Center_Glow;
            uniform float _Light;
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
                float4 node_9161 = _Time;
                float2 node_4011 = ((float2(_U_Speed,_V_Speed)*node_9161.g)+i.uv0);
                float4 node_6114 = tex2D(_Noise,TRANSFORM_TEX(node_4011, _Noise));
                float4 node_379 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 diffuseColor = (_Color.rgb+saturate((saturate(((node_6114.r*node_379.g*3.0)*2.0+-1.0))*(pow((1.0 - i.uv0.g),1.4)*_Center_Glow))));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
