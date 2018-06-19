// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-9986-OUT,alpha-603-OUT,clip-6693-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32199,y:32713,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32460,y:32802,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32199,y:32899,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32199,y:33063,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:32673,y:32802,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32460,y:32976,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Slider,id:4630,x:30675,y:33605,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7054569,max:1;n:type:ShaderForge.SFN_RemapRange,id:5097,x:31215,y:33601,varname:node_5097,prsc:2,frmn:0,frmx:1,tomn:-0.48,tomx:0.48|IN-1890-OUT;n:type:ShaderForge.SFN_OneMinus,id:1890,x:31031,y:33608,varname:node_1890,prsc:2|IN-4630-OUT;n:type:ShaderForge.SFN_UVTile,id:3785,x:31109,y:33866,varname:node_3785,prsc:2|UVIN-9190-UVOUT,WDT-9240-OUT,HGT-9240-OUT,TILE-9240-OUT;n:type:ShaderForge.SFN_TexCoord,id:9190,x:30910,y:33828,varname:node_9190,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:756,x:31285,y:33866,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-3785-UVOUT;n:type:ShaderForge.SFN_Add,id:9689,x:31499,y:33616,varname:node_9689,prsc:2|A-5097-OUT,B-756-R;n:type:ShaderForge.SFN_Vector1,id:9240,x:30910,y:34005,varname:node_9240,prsc:2,v1:5;n:type:ShaderForge.SFN_Tex2d,id:3956,x:31389,y:33002,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-8442-OUT,TEX-59-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:59,x:31136,y:33226,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:8442,x:31168,y:32975,varname:node_8442,prsc:2|A-2589-OUT,B-4054-OUT;n:type:ShaderForge.SFN_Vector1,id:4054,x:30931,y:33277,varname:node_4054,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:4300,x:30643,y:32963,varname:node_4300,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-6693-OUT;n:type:ShaderForge.SFN_Clamp01,id:3329,x:30809,y:32963,varname:node_3329,prsc:2|IN-4300-OUT;n:type:ShaderForge.SFN_OneMinus,id:2589,x:30970,y:32963,varname:node_2589,prsc:2|IN-3329-OUT;n:type:ShaderForge.SFN_Slider,id:2629,x:31178,y:32501,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:6048,x:31741,y:32554,varname:node_6048,prsc:2|A-2629-OUT,B-1281-OUT;n:type:ShaderForge.SFN_Lerp,id:7542,x:31289,y:32315,varname:node_7542,prsc:2|A-1720-UVOUT,B-378-R,T-6870-OUT;n:type:ShaderForge.SFN_TexCoord,id:1720,x:31026,y:32064,varname:node_1720,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:378,x:31037,y:32298,ptovrint:False,ptlb:node_7414_copy,ptin:_node_7414_copy,varname:_node_7414_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1266-UVOUT;n:type:ShaderForge.SFN_Panner,id:1266,x:30849,y:32298,varname:node_1266,prsc:2,spu:0,spv:0|UVIN-8652-UVOUT;n:type:ShaderForge.SFN_Slider,id:6870,x:30666,y:32544,ptovrint:False,ptlb:DisplacementDeath,ptin:_DisplacementDeath,varname:node_7057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:1533,x:30460,y:32373,varname:node_1533,prsc:2,v1:5;n:type:ShaderForge.SFN_TexCoord,id:8652,x:30595,y:32313,varname:node_8652,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:8924,x:32209,y:32418,varname:node_8924,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:1281,x:31479,y:32682,varname:node_1281,prsc:2|A-3956-RGB,B-4128-OUT;n:type:ShaderForge.SFN_Vector1,id:4128,x:31003,y:32733,varname:node_4128,prsc:2,v1:3;n:type:ShaderForge.SFN_Clamp01,id:6693,x:31720,y:33560,varname:node_6693,prsc:2|IN-9689-OUT;n:type:ShaderForge.SFN_Vector1,id:5844,x:32444,y:33591,varname:node_5844,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:9986,x:32883,y:32723,varname:node_9986,prsc:2|A-6048-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Multiply,id:3457,x:32533,y:33416,varname:node_3457,prsc:2;proporder:4805-5983-4630-756-59-2629;pass:END;sub:END;*/

Shader "Shader Forge/Doorr" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Displacement ("Displacement", Range(0, 1)) = 0.7054569
        _node_7414 ("node_7414", 2D) = "white" {}
        _node_7526 ("node_7526", 2D) = "white" {}
        _ControlDeath ("ControlDeath", Range(0, 1)) = 1
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
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
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
            #pragma multi_compile_fwdbase
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
                float node_9240 = 5.0;
                float2 node_3785_tc_rcp = float2(1.0,1.0)/float2( node_9240, node_9240 );
                float node_3785_ty = floor(node_9240 * node_3785_tc_rcp.x);
                float node_3785_tx = node_9240 - node_9240 * node_3785_ty;
                float2 node_3785 = (i.uv0 + float2(node_3785_tx, node_3785_ty)) * node_3785_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3785, _node_7414));
                float node_6693 = saturate((((1.0 - _Displacement)*0.96+-0.48)+_node_7414_var.r));
                clip(node_6693 - 0.5);
////// Lighting:
////// Emissive:
                float2 node_8442 = float2((1.0 - saturate((node_6693*8.0+-4.0))),1.0);
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(node_8442, _node_7526));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                float3 emissive = ((_ControlDeath*(node_1203.rgb*3.0))+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_603));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
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
                float node_9240 = 5.0;
                float2 node_3785_tc_rcp = float2(1.0,1.0)/float2( node_9240, node_9240 );
                float node_3785_ty = floor(node_9240 * node_3785_tc_rcp.x);
                float node_3785_tx = node_9240 - node_9240 * node_3785_ty;
                float2 node_3785 = (i.uv0 + float2(node_3785_tx, node_3785_ty)) * node_3785_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3785, _node_7414));
                float node_6693 = saturate((((1.0 - _Displacement)*0.96+-0.48)+_node_7414_var.r));
                clip(node_6693 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
