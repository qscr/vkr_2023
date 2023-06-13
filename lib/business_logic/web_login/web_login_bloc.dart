import 'package:dio/dio.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dynamic_store/helpers/dio_extensions.dart';
import 'package:flutter_dynamic_store/models/api/authentication/post_authentication_login_request.dart';
import 'package:flutter_dynamic_store/models/base_error_state.dart';
import 'package:flutter_dynamic_store/service/api/authentication_api_client.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'web_login_state.dart';
part 'web_login_event.dart';
part 'web_login_bloc.freezed.dart';

class WebLoginBloc extends Bloc<WebLoginEvent, WebLoginState> {
  final AuthenticationApiClient _apiClient;
  final Dio _dio;

  WebLoginBloc(this._apiClient, this._dio) : super(const WebLoginState.initial()) {
    on<Login>(
      (event, emit) async {
        await _login(
          emit: emit,
          email: event.email,
          password: event.password,
        );
      },
    );
  }

  Future<void> _login({
    required Emitter<WebLoginState> emit,
    required String email,
    required String password,
  }) async {
    emit(const LoginLoading());
    try {
      final response = await _apiClient.login(PostAuthenticationLoginRequest(email, password));
      if (response.token != null && response.refreshToken != null) {
        if (!response.isShopOwner) {
          emit(const LoginError("Пользователь не является владельцем какого-либо магазина"));
          return;
        }
        await const FlutterSecureStorage().write(key: "access_token", value: response.token);
        await const FlutterSecureStorage()
            .write(key: "refresh_token", value: response.refreshToken);
        _dio.setAuthorizationToken(response.token!);
        emit(const LoginSuccess());
      } else {
        emit(const LoginError("Не удалось получить токен аутентификации"));
      }
    } catch (e) {
      emit(const LoginError("Не удалось получить токен аутентификации"));
    }
  }
}
