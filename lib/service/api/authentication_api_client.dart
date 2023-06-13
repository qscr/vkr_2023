import 'package:dio/dio.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_login_request.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_login_response.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_refresh_token_request.dart';
import 'package:retrofit/retrofit.dart';

part 'authentication_api_client.g.dart';

@RestApi()
abstract class IAuthenticationApiClient {
  factory IAuthenticationApiClient(Dio dio, {String baseUrl}) = _IAuthenticationApiClient;

  /// Авторизация
  @POST("/Login")
  Future<PostAuthenticationLoginResponse> login(@Body() PostAuthenticationLoginRequest request);

  /// Обновление токена
  @POST("/RefreshToken")
  Future<PostAuthenticationLoginResponse> refreshToken(
      @Body() PostAuthenticationRefreshTokenRequest request);
}

/// Апи-клиент приложения для Authentication-раздела
class AuthenticationApiClient extends _IAuthenticationApiClient {
  AuthenticationApiClient(Dio dio, String baseUrl)
      : super(dio, baseUrl: "$baseUrl/Authentication/");
}
