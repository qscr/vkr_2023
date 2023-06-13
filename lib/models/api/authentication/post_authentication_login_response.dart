import 'package:freezed_annotation/freezed_annotation.dart';

part 'post_authentication_login_response.g.dart';
part 'post_authentication_login_response.freezed.dart';

/// Данные о созданном токене аутентификации.
@freezed
// ignore_for_file: invalid_annotation_target
class PostAuthenticationLoginResponse with _$PostAuthenticationLoginResponse {
  const factory PostAuthenticationLoginResponse({
    /// Идентификатор пользователя.
    @JsonKey(name: "userId") String? userId,

    /// Текст токена.
    @JsonKey(name: "token") String? token,

    /// Токен для обновления токена.
    @JsonKey(name: "refreshToken") String? refreshToken,

    /// Время создания токена.
    @JsonKey(name: "createdOn") String? createdOn,

    /// Тип токена.
    @JsonKey(name: "tokenType") String? tokenType,

    /// Идентификатор типа токена.
    @JsonKey(name: "tokenTypeId") int? tokenTypeId,

    /// Является ли пользователь владельцем какого-либо магазина
    @JsonKey(name: "isShopOwner") @Default(false) bool isShopOwner,
  }) = PostAuthenticationLoginResp;

  factory PostAuthenticationLoginResponse.fromJson(Map<String, dynamic> json) =>
      _$PostAuthenticationLoginResponseFromJson(json);
}
