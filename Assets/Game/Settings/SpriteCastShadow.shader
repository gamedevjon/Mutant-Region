half4 mainColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * IN.color;
half shadowAlpha = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv + half2(_ShadowX, _ShadowY)).a;
half4 shadowColor = _ShadowColor * shadowAlpha * (1 - mainColor.a);
mainColor.rgb += shadowColor;
mainColor.a = max(shadowAlpha * _ShadowAlpha * IN.color.a, mainColor.a);