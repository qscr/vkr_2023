import 'package:dio/dio.dart';
import 'package:flutter_dynamic_store/helpers/dependency_injection.dart';
import 'package:flutter_dynamic_store/helpers/dio_extensions.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_login_response.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_refresh_token_request.dart';
import 'package:flutter_dynamic_store/service/api/authentication_api_client.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class RefreshTokenInterceptor extends Interceptor {
  @override
  void onError(DioError err, ErrorInterceptorHandler handler) async {
    if (err.response?.statusCode != 401) {
      handler.next(err);
      return;
    }

    const flutterSecureStorage = FlutterSecureStorage();
    final accessToken = await flutterSecureStorage.read(key: "access_token");
    final refreshToken = await flutterSecureStorage.read(key: "refresh_token");

    if (accessToken == null || refreshToken == null) {
      handler.next(err);
      return;
    }

    final dio = Resolver.resolve<Dio>();
    dio.deleteAuthorizationToken();
    final apiClient = Resolver.resolve<AuthenticationApiClient>();
    PostAuthenticationLoginResponse? response;
    try {
      response = await apiClient.refreshToken(
        PostAuthenticationRefreshTokenRequest(
          accessToken: accessToken,
          refreshToken: refreshToken,
        ),
      );
    } catch (e) {
      handler.next(err);
      return;
    }

    if (response.token == null || response.refreshToken == null) {
      handler.next(err);
      return;
    }

    flutterSecureStorage.write(key: "access_token", value: response.token);
    flutterSecureStorage.write(key: "refresh_token", value: response.refreshToken);

    dio.setAuthorizationToken(response.token!);

    try {
      final options = err.requestOptions;
      options.headers["Authorization"] = "Bearer ${response.token}";
      final newResponse = await dio.fetch(options);
      handler.resolve(newResponse);
      return;
    } catch (e) {
      handler.next(err);
      return;
    }
  }
}
