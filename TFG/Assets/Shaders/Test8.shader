// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32965,y:32858,varname:node_3138,prsc:2|emission-5515-OUT,clip-8015-OUT;n:type:ShaderForge.SFN_Slider,id:9340,x:30811,y:33523,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6206691,max:1;n:type:ShaderForge.SFN_RemapRange,id:1389,x:31327,y:33523,varname:node_1389,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.6|IN-3842-OUT;n:type:ShaderForge.SFN_OneMinus,id:3842,x:31143,y:33530,varname:node_3842,prsc:2|IN-9340-OUT;n:type:ShaderForge.SFN_UVTile,id:1952,x:31171,y:33788,varname:node_1952,prsc:2|UVIN-6927-UVOUT,WDT-8846-OUT,HGT-8846-OUT,TILE-8846-OUT;n:type:ShaderForge.SFN_TexCoord,id:6927,x:31022,y:33750,varname:node_6927,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:2650,x:31397,y:33788,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-1952-UVOUT;n:type:ShaderForge.SFN_Add,id:8015,x:31585,y:33509,varname:node_8015,prsc:2|A-1389-OUT,B-2650-R;n:type:ShaderForge.SFN_Vector1,id:8846,x:31022,y:33927,varname:node_8846,prsc:2,v1:5;n:type:ShaderForge.SFN_Tex2d,id:3318,x:31593,y:32738,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-8992-OUT,TEX-4264-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4264,x:31299,y:33215,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:8992,x:31309,y:32794,varname:node_8992,prsc:2|A-6499-OUT,B-7050-OUT;n:type:ShaderForge.SFN_Vector1,id:7050,x:31043,y:33199,varname:node_7050,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRange,id:865,x:30755,y:32885,varname:node_865,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-8015-OUT;n:type:ShaderForge.SFN_Clamp01,id:5297,x:30922,y:32885,varname:node_5297,prsc:2|IN-865-OUT;n:type:ShaderForge.SFN_OneMinus,id:6499,x:31134,y:32819,varname:node_6499,prsc:2|IN-5297-OUT;n:type:ShaderForge.SFN_Slider,id:1220,x:31706,y:32486,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:1078,x:32233,y:32523,varname:node_1078,prsc:2|A-1220-OUT,B-1259-OUT;n:type:ShaderForge.SFN_Multiply,id:1259,x:31971,y:32689,varname:node_1259,prsc:2|A-3318-RGB,B-6411-OUT;n:type:ShaderForge.SFN_Vector1,id:6411,x:31542,y:32646,varname:node_6411,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Tex2d,id:2532,x:32097,y:32819,ptovrint:False,ptlb:node_2532,ptin:_node_2532,varname:node_2532,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:9609,x:32097,y:33162,varname:node_9609,prsc:2;n:type:ShaderForge.SFN_Add,id:5515,x:32703,y:32748,varname:node_5515,prsc:2|A-1078-OUT,B-4472-OUT;n:type:ShaderForge.SFN_Color,id:1876,x:32097,y:33005,ptovrint:False,ptlb:node_1876,ptin:_node_1876,varname:node_1876,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:1124,x:32360,y:32852,varname:node_1124,prsc:2|A-2532-RGB,B-1876-RGB,C-9609-RGB;n:type:ShaderForge.SFN_Multiply,id:9836,x:32360,y:33065,varname:node_9836,prsc:2|A-2532-A,B-1876-A,C-9609-A;n:type:ShaderForge.SFN_Multiply,id:4472,x:32541,y:32852,varname:node_4472,prsc:2|A-1124-OUT,B-9836-OUT;proporder:4264-1220-9340-2650-2532-1876;pass:END;sub:END;*/

Shader "Shader Forge/Test8" {
    Properties {
        _node_7526 ("node_7526", 2D) = "white" {}
        _ControlDeath ("ControlDeath", Range(0, 1)) = 1
        _Displacement ("Displacement", Range(0, 1)) = 0.6206691
        _node_7414 ("node_7414", 2D) = "white" {}
        _node_2532 ("node_2532", 2D) = "white" {}
        _node_1876 ("node_1876", Color) = (0,0,0,1)
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            uniform sampler2D _node_7526; uniform float4 _node_7526_ST;
            uniform float _ControlDeath;
            uniform sampler2D _node_2532; uniform float4 _node_2532_ST;
            uniform float4 _node_1876;
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
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_8846 = 5.0;
                float2 node_1952_tc_rcp = float2(1.0,1.0)/float2( node_8846, node_8846 );
                float node_1952_ty = floor(node_8846 * node_1952_tc_rcp.x);
                float node_1952_tx = node_8846 - node_8846 * node_1952_ty;
                float2 node_1952 = (i.uv0 + float2(node_1952_tx, node_1952_ty)) * node_1952_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_1952, _node_7414));
                float node_8015 = (((1.0 - _Displacement)*1.2+-0.6)+_node_7414_var.r);
                clip(node_8015 - 0.5);
////// Lighting:
////// Emissive:
                float2 node_8992 = float2((1.0 - saturate((node_8015*8.0+-4.0))),1.0);
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(node_8992, _node_7526));
                float4 _node_2532_var = tex2D(_node_2532,TRANSFORM_TEX(i.uv0, _node_2532));
                float3 emissive = ((_ControlDeath*(node_1203.rgb*1.5))+((_node_2532_var.rgb*_node_1876.rgb*i.vertexColor.rgb)*(_node_2532_var.a*_node_1876.a*i.vertexColor.a)));
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
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_8846 = 5.0;
                float2 node_1952_tc_rcp = float2(1.0,1.0)/float2( node_8846, node_8846 );
                float node_1952_ty = floor(node_8846 * node_1952_tc_rcp.x);
                float node_1952_tx = node_8846 - node_8846 * node_1952_ty;
                float2 node_1952 = (i.uv0 + float2(node_1952_tx, node_1952_ty)) * node_1952_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_1952, _node_7414));
                float node_8015 = (((1.0 - _Displacement)*1.2+-0.6)+_node_7414_var.r);
                clip(node_8015 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
