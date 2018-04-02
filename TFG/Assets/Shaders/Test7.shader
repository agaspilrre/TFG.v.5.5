// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8943,x:32476,y:32806,varname:node_8943,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|UVIN-9809-OUT,TEX-3805-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:3805,x:32173,y:32960,ptovrint:False,ptlb:node_3805,ptin:_node_3805,varname:node_3805,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:6255,x:31562,y:32589,varname:node_6255,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:9474,x:31759,y:32613,varname:node_9474,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6255-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:2151,x:31906,y:32635,varname:node_2151,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9474-OUT;n:type:ShaderForge.SFN_ArcTan2,id:9698,x:32063,y:32601,varname:node_9698,prsc:2,attp:1|A-2151-G,B-2151-R;n:type:ShaderForge.SFN_Append,id:9809,x:32299,y:32646,varname:node_9809,prsc:2|A-9698-OUT,B-7326-OUT;n:type:ShaderForge.SFN_Vector1,id:7326,x:32073,y:32816,varname:node_7326,prsc:2,v1:0;pass:END;sub:END;*/

Shader "Shader Forge/Test7" {
    Properties {
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}