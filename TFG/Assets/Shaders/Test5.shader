// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33521,y:32709,varname:node_1873,prsc:2|emission-8424-OUT,clip-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32551,y:32733,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33002,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32988,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-4171-OUT;n:type:ShaderForge.SFN_Slider,id:4161,x:31536,y:33549,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6180904,max:1;n:type:ShaderForge.SFN_RemapRange,id:8422,x:32123,y:33577,varname:node_8422,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3813-OUT;n:type:ShaderForge.SFN_OneMinus,id:3813,x:31933,y:33565,varname:node_3813,prsc:2|IN-4161-OUT;n:type:ShaderForge.SFN_UVTile,id:3846,x:32017,y:33842,varname:node_3846,prsc:2|UVIN-2708-UVOUT,WDT-7066-OUT,HGT-7066-OUT,TILE-7066-OUT;n:type:ShaderForge.SFN_TexCoord,id:2708,x:31818,y:33804,varname:node_2708,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8292,x:32193,y:33842,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-3846-UVOUT;n:type:ShaderForge.SFN_Add,id:3365,x:32341,y:33606,varname:node_3365,prsc:2|A-8422-OUT,B-8292-RGB;n:type:ShaderForge.SFN_Vector1,id:7066,x:31818,y:33981,varname:node_7066,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:4171,x:32537,y:33498,varname:node_4171,prsc:2|IN-3365-OUT;n:type:ShaderForge.SFN_Vector1,id:1745,x:31783,y:33150,varname:node_1745,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:7132,x:31423,y:32928,varname:node_7132,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-4171-OUT;n:type:ShaderForge.SFN_Clamp01,id:8511,x:31602,y:32928,varname:node_8511,prsc:2|IN-7132-OUT;n:type:ShaderForge.SFN_OneMinus,id:3048,x:31804,y:32943,varname:node_3048,prsc:2|IN-8511-OUT;n:type:ShaderForge.SFN_Slider,id:2685,x:31984,y:32544,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:8424,x:33210,y:32711,varname:node_8424,prsc:2|A-8002-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Tex2d,id:3208,x:32258,y:32939,varname:node_8943,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-8024-OUT,TEX-1087-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1087,x:32049,y:33150,ptovrint:False,ptlb:node_3805,ptin:_node_3805,varname:node_3805,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:8024,x:32049,y:32972,varname:node_8024,prsc:2|A-3048-OUT,B-1745-OUT;n:type:ShaderForge.SFN_Multiply,id:8002,x:32395,y:32540,varname:node_8002,prsc:2|A-2685-OUT,B-4915-OUT;n:type:ShaderForge.SFN_Clamp01,id:8011,x:32535,y:32396,varname:node_8011,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4915,x:32285,y:32748,varname:node_4915,prsc:2|A-1545-OUT,B-3208-RGB;n:type:ShaderForge.SFN_Vector1,id:1545,x:31930,y:32729,varname:node_1545,prsc:2,v1:2;proporder:4805-5983-2685-4161-8292-1087;pass:END;sub:END;*/

Shader "Shader Forge/Test5" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _ControlDeath ("ControlDeath", Range(0, 1)) = 1
        _Displacement ("Displacement", Range(0, 1)) = 0.6180904
        _node_7414 ("node_7414", 2D) = "white" {}
        _node_3805 ("node_3805", 2D) = "white" {}
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
            Blend One OneMinusSrcAlpha
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
            uniform float _ControlDeath;
            uniform sampler2D _node_3805; uniform float4 _node_3805_ST;
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_7066 = 5.0;
                float2 node_3846_tc_rcp = float2(1.0,1.0)/float2( node_7066, node_7066 );
                float node_3846_ty = floor(node_7066 * node_3846_tc_rcp.x);
                float node_3846_tx = node_7066 - node_7066 * node_3846_ty;
                float2 node_3846 = (i.uv0 + float2(node_3846_tx, node_3846_ty)) * node_3846_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3846, _node_7414));
                float3 node_4171 = saturate((((1.0 - _Displacement)*2.0+-1.0)+_node_7414_var.rgb));
                float3 node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*node_4171); // A
                clip(node_603 - 0.5);
////// Lighting:
////// Emissive:
                float4 node_8024 = float4((1.0 - saturate((node_4171*8.0+-4.0))),1.0);
                float4 node_8943 = tex2D(_node_3805,TRANSFORM_TEX(node_8024, _node_3805));
                float3 emissive = ((_ControlDeath*(2.0*node_8943.rgb))+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_603));
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
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
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_7066 = 5.0;
                float2 node_3846_tc_rcp = float2(1.0,1.0)/float2( node_7066, node_7066 );
                float node_3846_ty = floor(node_7066 * node_3846_tc_rcp.x);
                float node_3846_tx = node_7066 - node_7066 * node_3846_ty;
                float2 node_3846 = (i.uv0 + float2(node_3846_tx, node_3846_ty)) * node_3846_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3846, _node_7414));
                float3 node_4171 = saturate((((1.0 - _Displacement)*2.0+-1.0)+_node_7414_var.rgb));
                float3 node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*node_4171); // A
                clip(node_603 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
