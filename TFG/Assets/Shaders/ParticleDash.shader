// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33695,y:32674,varname:node_3138,prsc:2|emission-8335-OUT,alpha-6880-A;n:type:ShaderForge.SFN_Color,id:7241,x:31978,y:32505,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7821441,c2:0.2724913,c3:0.9264706,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6880,x:31940,y:32949,ptovrint:False,ptlb:node_6880,ptin:_node_6880,varname:node_6880,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9ef27351523e3fb4db2d8009b708d4d9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:736,x:32139,y:33181,ptovrint:False,ptlb:0.8m,ptin:_08m,varname:node_736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0386d2334515eec498c5d73e691de3f5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1646,x:32696,y:33099,varname:node_1646,prsc:2|A-736-RGB,B-4728-OUT;n:type:ShaderForge.SFN_Vector1,id:9877,x:32927,y:33302,varname:node_9877,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:2770,x:32594,y:32366,varname:node_2770,prsc:2;n:type:ShaderForge.SFN_Vector3,id:4728,x:32547,y:33334,varname:node_4728,prsc:2,v1:0.3088235,v2:0.00681229,v3:0.2260139;n:type:ShaderForge.SFN_Multiply,id:2839,x:32888,y:33110,varname:node_2839,prsc:2|A-1646-OUT,B-736-A;n:type:ShaderForge.SFN_Vector3,id:2691,x:32149,y:32565,varname:node_2691,prsc:2,v1:0.9264706,v2:0.3201773,v3:0.7559506;n:type:ShaderForge.SFN_Multiply,id:4204,x:32756,y:32752,varname:node_4204,prsc:2|A-2691-OUT,B-1088-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1088,x:32426,y:32835,varname:node_1088,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6880-RGB;n:type:ShaderForge.SFN_Multiply,id:1564,x:32481,y:32303,varname:node_1564,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:7562,x:32261,y:32029,varname:node_7562,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:413,x:32457,y:32046,varname:node_413,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7562-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:2278,x:32569,y:32153,varname:node_2278,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-413-OUT;n:type:ShaderForge.SFN_Length,id:3225,x:32794,y:32153,varname:node_3225,prsc:2|IN-413-OUT;n:type:ShaderForge.SFN_Lerp,id:2154,x:33029,y:32189,varname:node_2154,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:4829,x:33205,y:32238,varname:node_4829,prsc:2|IN-2154-OUT;n:type:ShaderForge.SFN_RemapRange,id:3751,x:33422,y:32375,varname:node_3751,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1;n:type:ShaderForge.SFN_OneMinus,id:8710,x:32361,y:33257,varname:node_8710,prsc:2|IN-736-A;n:type:ShaderForge.SFN_Add,id:1063,x:33217,y:32854,varname:node_1063,prsc:2|A-1936-OUT,B-6714-OUT;n:type:ShaderForge.SFN_Multiply,id:6714,x:33088,y:33110,varname:node_6714,prsc:2|A-2839-OUT,B-9877-OUT;n:type:ShaderForge.SFN_Multiply,id:1936,x:32948,y:32799,varname:node_1936,prsc:2|A-4204-OUT,B-8710-OUT;n:type:ShaderForge.SFN_Multiply,id:8335,x:33473,y:32804,varname:node_8335,prsc:2|A-1063-OUT,B-2392-OUT;n:type:ShaderForge.SFN_Vector1,id:2392,x:33315,y:32997,varname:node_2392,prsc:2,v1:1.7;proporder:6880-7241-736;pass:END;sub:END;*/

Shader "Shader Forge/ParticleDash" {
    Properties {
        _node_6880 ("node_6880", 2D) = "white" {}
        _Color ("Color", Color) = (0.7821441,0.2724913,0.9264706,1)
        _08m ("0.8m", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_6880; uniform float4 _node_6880_ST;
            uniform sampler2D _08m; uniform float4 _08m_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_6880_var = tex2D(_node_6880,TRANSFORM_TEX(i.uv0, _node_6880));
                float4 _08m_var = tex2D(_08m,TRANSFORM_TEX(i.uv0, _08m));
                float3 emissive = ((((float3(0.9264706,0.3201773,0.7559506)*_node_6880_var.rgb.r)*(1.0 - _08m_var.a))+(((_08m_var.rgb*float3(0.3088235,0.00681229,0.2260139))*_08m_var.a)*2.0))*1.7);
                float3 finalColor = emissive;
                return fixed4(finalColor,_node_6880_var.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
