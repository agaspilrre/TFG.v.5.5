// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33699,y:32722,varname:node_1873,prsc:2|emission-9465-OUT,clip-959-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32548,y:32710,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32814,y:32776,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32535,y:32922,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33032,y:32776,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-3082-OUT;n:type:ShaderForge.SFN_Slider,id:3129,x:31546,y:33513,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7054569,max:1;n:type:ShaderForge.SFN_RemapRange,id:719,x:32086,y:33509,varname:node_719,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.6|IN-5889-OUT;n:type:ShaderForge.SFN_OneMinus,id:5889,x:31902,y:33516,varname:node_5889,prsc:2|IN-3129-OUT;n:type:ShaderForge.SFN_UVTile,id:5614,x:31980,y:33774,varname:node_5614,prsc:2|UVIN-7213-UVOUT,WDT-4483-OUT,HGT-4483-OUT,TILE-4483-OUT;n:type:ShaderForge.SFN_TexCoord,id:7213,x:31781,y:33736,varname:node_7213,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:7414,x:32156,y:33774,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-5614-UVOUT;n:type:ShaderForge.SFN_Add,id:9524,x:32370,y:33524,varname:node_9524,prsc:2|A-719-OUT,B-7414-R;n:type:ShaderForge.SFN_Vector1,id:4483,x:31781,y:33913,varname:node_4483,prsc:2,v1:5;n:type:ShaderForge.SFN_Tex2d,id:9412,x:32260,y:32910,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-4531-OUT,TEX-9095-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9095,x:32007,y:33134,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:4531,x:32039,y:32883,varname:node_4531,prsc:2|A-6906-OUT,B-2480-OUT;n:type:ShaderForge.SFN_Vector1,id:2480,x:31802,y:33185,varname:node_2480,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:248,x:31514,y:32871,varname:node_248,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-959-OUT;n:type:ShaderForge.SFN_Clamp01,id:6332,x:31680,y:32871,varname:node_6332,prsc:2|IN-248-OUT;n:type:ShaderForge.SFN_OneMinus,id:6906,x:31841,y:32871,varname:node_6906,prsc:2|IN-6332-OUT;n:type:ShaderForge.SFN_Slider,id:1616,x:32049,y:32409,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:1005,x:32612,y:32462,varname:node_1005,prsc:2|A-1616-OUT,B-8842-OUT;n:type:ShaderForge.SFN_Lerp,id:8093,x:32160,y:32223,varname:node_8093,prsc:2|A-3967-UVOUT,B-7927-R,T-7057-OUT;n:type:ShaderForge.SFN_TexCoord,id:3967,x:31897,y:31972,varname:node_3967,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:7927,x:31908,y:32206,ptovrint:False,ptlb:node_7414_copy,ptin:_node_7414_copy,varname:_node_7414_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8152-UVOUT;n:type:ShaderForge.SFN_Panner,id:8152,x:31720,y:32206,varname:node_8152,prsc:2,spu:0,spv:0|UVIN-4341-UVOUT;n:type:ShaderForge.SFN_Slider,id:7057,x:31537,y:32452,ptovrint:False,ptlb:DisplacementDeath,ptin:_DisplacementDeath,varname:node_7057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:5130,x:31331,y:32281,varname:node_5130,prsc:2,v1:5;n:type:ShaderForge.SFN_TexCoord,id:4341,x:31466,y:32221,varname:node_4341,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:2651,x:33080,y:32326,varname:node_2651,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:3082,x:32850,y:32949,varname:node_3082,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Multiply,id:8842,x:32350,y:32590,varname:node_8842,prsc:2|A-9412-RGB,B-1060-OUT;n:type:ShaderForge.SFN_Vector1,id:1060,x:31874,y:32641,varname:node_1060,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Clamp01,id:959,x:32591,y:33468,varname:node_959,prsc:2|IN-9524-OUT;n:type:ShaderForge.SFN_Vector1,id:5015,x:33315,y:33499,varname:node_5015,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:9465,x:33253,y:32716,varname:node_9465,prsc:2|A-1005-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Multiply,id:9980,x:33404,y:33324,varname:node_9980,prsc:2;proporder:4805-5983-3129-7414-9095-1616-7927-7057;pass:END;sub:END;*/

Shader "Shader Forge/Test2" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Displacement ("Displacement", Range(0, 1)) = 0.7054569
        _node_7414 ("node_7414", 2D) = "white" {}
        _node_7526 ("node_7526", 2D) = "white" {}
        _ControlDeath ("ControlDeath", Range(0, 1)) = 1
        _node_7414_copy ("node_7414_copy", 2D) = "white" {}
        _DisplacementDeath ("DisplacementDeath", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            uniform sampler2D _node_7526; uniform float4 _node_7526_ST;
            uniform float _ControlDeath;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_4483 = 5.0;
                float2 node_5614_tc_rcp = float2(1.0,1.0)/float2( node_4483, node_4483 );
                float node_5614_ty = floor(node_4483 * node_5614_tc_rcp.x);
                float node_5614_tx = node_4483 - node_4483 * node_5614_ty;
                float2 node_5614 = (i.uv0 + float2(node_5614_tx, node_5614_ty)) * node_5614_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_5614, _node_7414));
                float node_959 = saturate((((1.0 - _Displacement)*1.2+-0.6)+_node_7414_var.r));
                clip(node_959 - 0.5);
////// Lighting:
////// Emissive:
                float2 node_4531 = float2((1.0 - saturate((node_959*8.0+-4.0))),1.0);
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(node_4531, _node_7526));
                float3 node_1005 = (_ControlDeath*(node_1203.rgb*1.5));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_1749 = ((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*(_MainTex_var.a*_Color.a*i.vertexColor.a)); // Premultiply Alpha
                float3 emissive = (node_1005+node_1749);
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_4483 = 5.0;
                float2 node_5614_tc_rcp = float2(1.0,1.0)/float2( node_4483, node_4483 );
                float node_5614_ty = floor(node_4483 * node_5614_tc_rcp.x);
                float node_5614_tx = node_4483 - node_4483 * node_5614_ty;
                float2 node_5614 = (i.uv0 + float2(node_5614_tx, node_5614_ty)) * node_5614_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_5614, _node_7414));
                float node_959 = saturate((((1.0 - _Displacement)*1.2+-0.6)+_node_7414_var.r));
                clip(node_959 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
