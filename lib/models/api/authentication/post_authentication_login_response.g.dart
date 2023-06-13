// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'post_authentication_login_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$PostAuthenticationLoginResp _$$PostAuthenticationLoginRespFromJson(
        Map<String, dynamic> json) =>
    _$PostAuthenticationLoginResp(
      userId: json['userId'] as String?,
      token: json['token'] as String?,
      refreshToken: json['refreshToken'] as String?,
      createdOn: json['createdOn'] as String?,
      tokenType: json['tokenType'] as String?,
      tokenTypeId: json['tokenTypeId'] as int?,
      isShopOwner: json['isShopOwner'] as bool? ?? false,
    );

Map<String, dynamic> _$$PostAuthenticationLoginRespToJson(
        _$PostAuthenticationLoginResp instance) =>
    <String, dynamic>{
      'userId': instance.userId,
      'token': instance.token,
      'refreshToken': instance.refreshToken,
      'createdOn': instance.createdOn,
      'tokenType': instance.tokenType,
      'tokenTypeId': instance.tokenTypeId,
      'isShopOwner': instance.isShopOwner,
    };
