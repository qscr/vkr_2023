// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'post_authentication_refresh_token_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$PostAuthenticationRefreshTokenReq
    _$$PostAuthenticationRefreshTokenReqFromJson(Map<String, dynamic> json) =>
        _$PostAuthenticationRefreshTokenReq(
          accessToken: json['token'] as String?,
          refreshToken: json['refreshToken'] as String?,
        );

Map<String, dynamic> _$$PostAuthenticationRefreshTokenReqToJson(
        _$PostAuthenticationRefreshTokenReq instance) =>
    <String, dynamic>{
      'token': instance.accessToken,
      'refreshToken': instance.refreshToken,
    };
