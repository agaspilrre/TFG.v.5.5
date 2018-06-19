// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33286,y:32727,varname:node_1873,prsc:2|emission-4379-OUT,alpha-7485-OUT,clip-9500-OUT;n:type:ShaderForge.SFN_Tex2d,id:1035,x:32324,y:32828,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6201,x:32590,y:32894,cmnt:RGB,varname:node_6201,prsc:2|A-1035-RGB,B-9756-RGB,C-3346-RGB;n:type:ShaderForge.SFN_Color,id:9756,x:32311,y:33040,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:3346,x:32327,y:33197,varname:node_3346,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3923,x:32808,y:32894,cmnt:Premultiply Alpha,varname:node_3923,prsc:2|A-6201-OUT,B-7485-OUT;n:type:ShaderForge.SFN_Slider,id:9661,x:31322,y:33631,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7054569,max:1;n:type:ShaderForge.SFN_RemapRange,id:6103,x:31862,y:33627,varname:node_6103,prsc:2,frmn:0,frmx:1,tomn:-0.48,tomx:0.48|IN-3589-OUT;n:type:ShaderForge.SFN_OneMinus,id:3589,x:31678,y:33634,varname:node_3589,prsc:2|IN-9661-OUT;n:type:ShaderForge.SFN_UVTile,id:3191,x:31756,y:33892,varname:node_3191,prsc:2|UVIN-6172-UVOUT,WDT-1909-OUT,HGT-1909-OUT,TILE-1909-OUT;n:type:ShaderForge.SFN_TexCoord,id:6172,x:31557,y:33854,varname:node_6172,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:2906,x:31932,y:33892,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-3191-UVOUT;n:type:ShaderForge.SFN_Add,id:2686,x:32146,y:33642,varname:node_2686,prsc:2|A-6103-OUT,B-2906-R;n:type:ShaderForge.SFN_Vector1,id:1909,x:31557,y:34031,varname:node_1909,prsc:2,v1:5;n:type:ShaderForge.SFN_Tex2d,id:3610,x:32036,y:33028,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-7608-OUT,TEX-6442-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6442,x:31783,y:33252,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:7608,x:31815,y:33001,varname:node_7608,prsc:2|A-4317-OUT,B-1289-OUT;n:type:ShaderForge.SFN_Vector1,id:1289,x:31578,y:33303,varname:node_1289,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:4144,x:31290,y:32989,varname:node_4144,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-9500-OUT;n:type:ShaderForge.SFN_Clamp01,id:7413,x:31456,y:32989,varname:node_7413,prsc:2|IN-4144-OUT;n:type:ShaderForge.SFN_OneMinus,id:4317,x:31617,y:32989,varname:node_4317,prsc:2|IN-7413-OUT;n:type:ShaderForge.SFN_Slider,id:2613,x:31825,y:32527,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:4794,x:32388,y:32580,varname:node_4794,prsc:2|A-2613-OUT,B-8877-OUT;n:type:ShaderForge.SFN_Vector1,id:7784,x:32856,y:32444,varname:node_7784,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:7485,x:32626,y:33067,varname:node_7485,prsc:2|A-1035-A,B-9756-A,C-3346-A;n:type:ShaderForge.SFN_Multiply,id:8877,x:32126,y:32708,varname:node_8877,prsc:2|A-3610-RGB,B-4651-OUT;n:type:ShaderForge.SFN_Vector1,id:4651,x:31650,y:32759,varname:node_4651,prsc:2,v1:3;n:type:ShaderForge.SFN_Clamp01,id:9500,x:32367,y:33586,varname:node_9500,prsc:2|IN-2686-OUT;n:type:ShaderForge.SFN_Vector1,id:3076,x:33091,y:33617,varname:node_3076,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:4379,x:33029,y:32834,varname:node_4379,prsc:2|A-4794-OUT,B-3923-OUT;n:type:ShaderForge.SFN_Multiply,id:2584,x:33180,y:33442,varname:node_2584,prsc:2;proporder:1035-9756-6442-2613-9661-2906;pass:END;sub:END;*/

Shader "Shader Forge/Door" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _node_7526 ("node_7526", 2D) = "white" {}
        _ControlDeath ("ControlDeath", Range(0, 1)) = 1
        _Displacement ("Displacement", Range(0, 1)) = 0.7054569
        _node_7414 ("node_7414", 2D) = "white" {}
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
                float node_1909 = 5.0;
                float2 node_3191_tc_rcp = float2(1.0,1.0)/float2( node_1909, node_1909 );
                float node_3191_ty = floor(node_1909 * node_3191_tc_rcp.x);
                float node_3191_tx = node_1909 - node_1909 * node_3191_ty;
                float2 node_3191 = (i.uv0 + float2(node_3191_tx, node_3191_ty)) * node_3191_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3191, _node_7414));
                float node_9500 = saturate((((1.0 - _Displacement)*0.96+-0.48)+_node_7414_var.r));
                clip(node_9500 - 0.5);
////// Lighting:
////// Emissive:
                float2 node_7608 = float2((1.0 - saturate((node_9500*8.0+-4.0))),1.0);
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(node_7608, _node_7526));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_7485 = (_MainTex_var.a*_Color.a*i.vertexColor.a);
                float3 emissive = ((_ControlDeath*(node_1203.rgb*3.0))+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_7485));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_7485);
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
                float node_1909 = 5.0;
                float2 node_3191_tc_rcp = float2(1.0,1.0)/float2( node_1909, node_1909 );
                float node_3191_ty = floor(node_1909 * node_3191_tc_rcp.x);
                float node_3191_tx = node_1909 - node_1909 * node_3191_ty;
                float2 node_3191 = (i.uv0 + float2(node_3191_tx, node_3191_ty)) * node_3191_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3191, _node_7414));
                float node_9500 = saturate((((1.0 - _Displacement)*0.96+-0.48)+_node_7414_var.r));
                clip(node_9500 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
