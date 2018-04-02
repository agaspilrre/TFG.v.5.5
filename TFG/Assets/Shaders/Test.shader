// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:1,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34084,y:33414,varname:node_3138,prsc:2|emission-1203-RGB,clip-5810-OUT;n:type:ShaderForge.SFN_Tex2d,id:1203,x:33707,y:33455,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-6254-OUT,TEX-7526-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7526,x:33467,y:33477,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:6254,x:33467,y:33265,varname:node_6254,prsc:2|A-4856-OUT,B-3180-OUT;n:type:ShaderForge.SFN_Vector1,id:3180,x:33211,y:33461,varname:node_3180,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:7907,x:32636,y:33804,ptovrint:False,ptlb:node_7907,ptin:_node_7907,varname:node_7907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-9935-UVOUT;n:type:ShaderForge.SFN_Slider,id:4866,x:32041,y:33474,ptovrint:False,ptlb:Disolve amount,ptin:_Disolveamount,varname:node_4866,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3081555,max:1;n:type:ShaderForge.SFN_Add,id:5810,x:32850,y:33670,varname:node_5810,prsc:2|A-6678-OUT,B-7907-RGB;n:type:ShaderForge.SFN_RemapRange,id:6678,x:32619,y:33512,varname:node_6678,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.6|IN-7802-OUT;n:type:ShaderForge.SFN_OneMinus,id:7802,x:32405,y:33500,varname:node_7802,prsc:2|IN-4866-OUT;n:type:ShaderForge.SFN_RemapRange,id:3512,x:32923,y:33147,varname:node_3512,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-5810-OUT;n:type:ShaderForge.SFN_Clamp01,id:2627,x:33090,y:33147,varname:node_2627,prsc:2|IN-3512-OUT;n:type:ShaderForge.SFN_OneMinus,id:4856,x:33277,y:33177,varname:node_4856,prsc:2|IN-2627-OUT;n:type:ShaderForge.SFN_Vector1,id:1354,x:34242,y:33265,varname:node_1354,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:416,x:33996,y:33176,ptovrint:False,ptlb:node_416,ptin:_node_416,varname:node_416,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d37b922c5a7d13a4897cf98d30565573,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:9281,x:33753,y:33342,varname:node_9281,prsc:2,v1:0;n:type:ShaderForge.SFN_TexCoord,id:278,x:32149,y:33663,varname:node_278,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_UVTile,id:9935,x:32365,y:33723,varname:node_9935,prsc:2|UVIN-278-UVOUT,WDT-8052-OUT,HGT-8477-OUT,TILE-336-OUT;n:type:ShaderForge.SFN_Vector1,id:8052,x:32181,y:33872,varname:node_8052,prsc:2,v1:4;n:type:ShaderForge.SFN_Vector1,id:8477,x:32181,y:33971,varname:node_8477,prsc:2,v1:4;n:type:ShaderForge.SFN_Vector1,id:336,x:32218,y:34054,varname:node_336,prsc:2,v1:4;n:type:ShaderForge.SFN_Vector1,id:318,x:33465,y:33838,varname:node_318,prsc:2,v1:1;n:type:ShaderForge.SFN_Sin,id:271,x:33684,y:33820,varname:node_271,prsc:2|IN-318-OUT;n:type:ShaderForge.SFN_Vector1,id:5889,x:33188,y:33900,varname:node_5889,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:167,x:33132,y:33821,varname:node_167,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ComponentMask,id:5993,x:33564,y:33036,varname:node_5993,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1;n:type:ShaderForge.SFN_Append,id:3285,x:33384,y:33001,varname:node_3285,prsc:2;n:type:ShaderForge.SFN_Color,id:9501,x:33792,y:33150,ptovrint:False,ptlb:node_9501,ptin:_node_9501,varname:node_9501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:0;proporder:7526-7907-4866-416-9501;pass:END;sub:END;*/

Shader "Shader Forge/Test" {
    Properties {
        _node_7526 ("node_7526", 2D) = "white" {}
        _node_7907 ("node_7907", 2D) = "white" {}
        _Disolveamount ("Disolve amount", Range(0, 1)) = 0.3081555
        _node_416 ("node_416", 2D) = "white" {}
        _node_9501 ("node_9501", Color) = (0.5,0.5,0.5,0)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Front
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_7526; uniform float4 _node_7526_ST;
            uniform sampler2D _node_7907; uniform float4 _node_7907_ST;
            uniform float _Disolveamount;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(-v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float node_8052 = 4.0;
                float node_336 = 4.0;
                float2 node_9935_tc_rcp = float2(1.0,1.0)/float2( node_8052, 4.0 );
                float node_9935_ty = floor(node_336 * node_9935_tc_rcp.x);
                float node_9935_tx = node_336 - node_8052 * node_9935_ty;
                float2 node_9935 = (i.uv1 + float2(node_9935_tx, node_9935_ty)) * node_9935_tc_rcp;
                float4 _node_7907_var = tex2D(_node_7907,TRANSFORM_TEX(node_9935, _node_7907));
                float3 node_5810 = (((1.0 - _Disolveamount)*1.2+-0.6)+_node_7907_var.rgb);
                clip(node_5810 - 0.5);
////// Lighting:
////// Emissive:
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(float4((1.0 - saturate((node_5810*8.0+-4.0))),0.0), _node_7526));
                float3 emissive = node_1203.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_7907; uniform float4 _node_7907_ST;
            uniform float _Disolveamount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv1 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_8052 = 4.0;
                float node_336 = 4.0;
                float2 node_9935_tc_rcp = float2(1.0,1.0)/float2( node_8052, 4.0 );
                float node_9935_ty = floor(node_336 * node_9935_tc_rcp.x);
                float node_9935_tx = node_336 - node_8052 * node_9935_ty;
                float2 node_9935 = (i.uv1 + float2(node_9935_tx, node_9935_ty)) * node_9935_tc_rcp;
                float4 _node_7907_var = tex2D(_node_7907,TRANSFORM_TEX(node_9935, _node_7907));
                float3 node_5810 = (((1.0 - _Disolveamount)*1.2+-0.6)+_node_7907_var.rgb);
                clip(node_5810 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
